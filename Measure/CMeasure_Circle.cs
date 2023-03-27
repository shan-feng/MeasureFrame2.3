using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using Measure.UserDefine;
using CPublicDefine;

namespace Measure
{
    [Serializable]
    public class CMeasure_Circle : CMeasure_2D
    {
        private Circle_INFO _inCircleInfo = new Circle_INFO();
        private Circle_INFO _outCircleInfo = new Circle_INFO();

        /// <summary>
        /// 绘制圆
        /// </summary>
        public Circle_INFO m_InCircle
        {
            set { this._inCircleInfo = value; }
            get { return this._inCircleInfo; }
        }

        /// <summary>
        /// 输出圆
        /// </summary>
        public Circle_INFO m_OutCircle
        {
            get { return _outCircleInfo; }
        }

        public CMeasure_Circle() : base()
        {
        }

        public CMeasure_Circle(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        //使用metrology_model来检测圆
        public override void Execute(bool blnByHand = false)
        {
            Circle_INFO tempCircle = new Circle_INFO();
            HRegion tempDisableRegion = new HRegion();//仿射变换后的屏蔽区域
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, m_CurrentImgName, out m_Image);

                //开始运行时候没有图像数据就直接返回 yoga 2018-9-1 17:25:03
                if (m_Image==null||m_Image.IsInitialized()==false)
                {
                    return;
                }
                Coordinate_INFO coord = new Coordinate_INFO();
                if (m_homMatUnitID != -1)
                {
                    F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == m_homMatUnitID);
                    coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
                    HHomMat2D homMat2D = new HHomMat2D();
                    homMat2D = homMat2D.HomMat2dRotateLocal(-coord.Phi);
                    homMat2D = homMat2D.HomMat2dTranslate(coord.X, coord.Y);
                    tempCircle = (Circle_INFO)m_InCircle.Clone();
                    tempCircle.CenterX = homMat2D.AffineTransPoint2d(m_InCircle.CenterX, m_InCircle.CenterY, out tempCircle.CenterY);
                    tempCircle = HMeasureSet.Circle2PixelPlane(m_Image, tempCircle);

                }
                else
                {
                    coord = new Coordinate_INFO();
                    tempCircle = HMeasureSet.Circle2PixelPlane(m_Image, m_InCircle);
                }
                HXLDCont CoordXLD = HMeasureSet.GetCoord(m_Image, coord);
                MeasureROI roi坐标系 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.参考坐标系.ToString(), "green", new HObject(CoordXLD));
                m_Image.UpdateRoiList(roi坐标系);
                //获取图像坐标
                if (isCorrect)
                {
                    if (disableRegion.IsInitialized())
                    {
                        double row, col, regRow, regCol;
                        F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == m_homMatUnitID);
                        coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
                        HHomMat2D homMat2D = new HHomMat2D();
                        homMat2D = homMat2D.HomMat2dRotateLocal(-coord.Phi);
                        homMat2D = homMat2D.HomMat2dTranslate(coord.X, coord.Y);
                        regCol = homMat2D.AffineTransPoint2d(RegCoor.X, RegCoor.Y, out regRow);
                        HMeasureSet.WorldPlane2Point(m_Image, regCol, regRow, out regRow, out regCol);

                        HHomMat2D homMat = new HHomMat2D();
                        disableRegion.AreaCenter(out row, out col);
                        homMat.VectorAngleToRigid(row, col, RegCoor.Phi, regRow, regCol, coord.Phi);

                        tempDisableRegion = homMat.AffineTransRegion(disableRegion, "nearest_neighbor");
                    }

                }
                else
                {
                    tempDisableRegion = disableRegion;
                }

                HMeasureSet.MeasureCircle(m_Image, tempCircle, m_MetrologyInfo, tempDisableRegion, out _outCircleInfo, out m_row, out m_col, out m_MeasureXLD);
                m_MeasureCross.GenCrossContourXld(m_row, m_col, (HTuple)m_MetrologyInfo.Length2, new HTuple(45).TupleRad());
                m_ResultXLD.GenCircleContourXld(_outCircleInfo.CenterY, _outCircleInfo.CenterX, _outCircleInfo.Radius, 0, 6.28318, "positive", 1);

                //世界坐标系
                Circle_INFO circleW = HMeasureSet.Circle2WorldPlane(m_Image, _outCircleInfo);
                List<Circle_INFO> temp_CircleW = new List<Circle_INFO>() { circleW };
                F_DATA_CELL dataCircleW = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.圆, ConstVavriable.outCircle
                            , "检测圆", "0", 1, temp_CircleW, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataCircleW);

                List<Double> xW, yW;
                HMeasureSet.Points2WorldPlane(m_Image, m_row.ToDArr().ToList(), m_col.ToDArr().ToList(), out xW, out yW);
                F_DATA_CELL dataRowW = new F_DATA_CELL(m_CellID, DataGroup.数组, DataType.数值型, ConstVavriable.outY
                                            , "轮廓行序列号", "0", yW.Count
                                            , yW, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataRowW);

                F_DATA_CELL dataColW = new F_DATA_CELL(m_CellID, DataGroup.数组, DataType.数值型, ConstVavriable.outX
                                            , "轮廓列序列号", "0", xW.Count
                                            , xW, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataColW);

                //添加检测roi  magical 20170821
                MeasureROI roi检测范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(m_MeasureXLD));
                MeasureROI roi检测点 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测点.ToString(), "blue", new HObject(m_MeasureCross));
                MeasureROI roi检测结果 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测结果.ToString(), "red", new HObject(m_ResultXLD));
                MeasureROI roi屏蔽范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.屏蔽范围.ToString(), "red", new HObject(tempDisableRegion));

                m_Image.UpdateRoiList(roi检测范围);
                m_Image.UpdateRoiList(roi检测点);
                m_Image.UpdateRoiList(roi检测结果);
                m_Image.UpdateRoiList(roi屏蔽范围);
                //end magical

                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                //更新一个当前检测ROI
                m_MeasureXLD = tempCircle.genXLD();
                MeasureROI roi检测范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(m_MeasureXLD));
                MeasureROI roi屏蔽范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.屏蔽范围.ToString(), "red", new HObject(tempDisableRegion));
                m_Image.UpdateRoiList(roi检测范围);
                m_Image.UpdateRoiList(roi屏蔽范围);

                F_DATA_CELL dataCircleW = new F_DATA_CELL();
                dataCircleW.InitValue(m_CellID, ConstVavriable.outCircle, DataType.圆, "");
                m_Owner.UpdateVariableValue(dataCircleW);

                F_DATA_CELL dataRowW = new F_DATA_CELL();
                dataRowW.InitValue(m_CellID, ConstVavriable.outY, DataType.数值型, "0");
                m_Owner.UpdateVariableValue(dataRowW);

                F_DATA_CELL dataColW = new F_DATA_CELL();
                dataColW.InitValue(m_CellID, ConstVavriable.outX, DataType.数值型, "0");
                m_Owner.UpdateVariableValue(dataColW);
                blnSuccessed = false;
            }
        }
    }
}
