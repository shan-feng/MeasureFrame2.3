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
    public class CMeasure_Ellipse : CMeasure_2D
    {
        private Ellipse_INFO _inEllipseInfo = new Ellipse_INFO();
        private Ellipse_INFO _outEllipseInfo = new Ellipse_INFO();

        /// <summary>
        /// 绘制圆
        /// </summary>
        public Ellipse_INFO m_InEllipse
        {
            set { this._inEllipseInfo = value; }
            get { return this._inEllipseInfo; }
        }

        /// <summary>
        /// 输出圆
        /// </summary>
        public Ellipse_INFO m_OutEllipse
        {
            get { return _outEllipseInfo; }
        }

        public CMeasure_Ellipse() : base()
        {
        }

        public CMeasure_Ellipse(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        //使用metrology_model来检测圆
        public override void Execute(bool blnByHand = false)
        {
            Ellipse_INFO tempEllipse = new Ellipse_INFO();
            HRegion tempDisableRegion = new HRegion();//仿射变换后的屏蔽区域
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, m_CurrentImgName, out m_Image);
                Coordinate_INFO coord = new Coordinate_INFO();
                if (m_homMatUnitID != -1)
                {
                    F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == m_homMatUnitID);
                    coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
                    HHomMat2D homMat2D = new HHomMat2D();
                    homMat2D=homMat2D.HomMat2dRotateLocal(-coord.Phi);
                    homMat2D=homMat2D.HomMat2dTranslate(coord.X, coord.Y);
                    tempEllipse = (Ellipse_INFO)m_InEllipse.Clone();
                    tempEllipse.CenterX = homMat2D.AffineTransPoint2d(tempEllipse.CenterX, tempEllipse.CenterY, out tempEllipse.CenterY);
                    tempEllipse = HMeasureSet.Ellipse2PixelPlane(m_Image, tempEllipse);
                 }
                else
                {
                    coord = new Coordinate_INFO();
                    tempEllipse = HMeasureSet.Ellipse2PixelPlane(m_Image, m_InEllipse);
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
                
                HMeasureSet.MeasureEllipse(m_Image, tempEllipse, m_MetrologyInfo, out _outEllipseInfo, out m_row, out m_col, out m_MeasureXLD);
                m_MeasureCross.GenCrossContourXld(m_row, m_col, (HTuple)m_MetrologyInfo.Length2, new HTuple(45).TupleRad());
                m_ResultXLD.GenEllipseContourXld(_outEllipseInfo.CenterY, _outEllipseInfo.CenterX, _outEllipseInfo.Phi, _outEllipseInfo.Radius1, _outEllipseInfo.Radius2, 0, 6.28318, "positive", 1);
                
                //世界坐标系
                Ellipse_INFO EllipseW = HMeasureSet.Ellipse2WorldPlane(m_Image, _outEllipseInfo);
                List<Ellipse_INFO> temp_EllipseW = new List<Ellipse_INFO>() { EllipseW };

                F_DATA_CELL dataEllipseW = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.圆, ConstVavriable.outEllipse
                            , "检测直线", "0", 1, temp_EllipseW, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataEllipseW);

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
                m_MeasureXLD = tempEllipse.genXLD();
                MeasureROI roi检测范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(m_MeasureXLD));
                MeasureROI roi屏蔽范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.屏蔽范围.ToString(), "red", new HObject(tempDisableRegion));
                m_Image.UpdateRoiList(roi检测范围);
                m_Image.UpdateRoiList(roi屏蔽范围);

                F_DATA_CELL dataEllipseW = new F_DATA_CELL();
                dataEllipseW.InitValue(m_CellID, ConstVavriable.outEllipse, DataType.椭圆, "");
                m_Owner.UpdateVariableValue(dataEllipseW);

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
