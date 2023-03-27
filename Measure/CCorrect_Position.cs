using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using Measure.UserDefine;
using System.Runtime.Serialization;
using CPublicDefine;

namespace Measure
{
    [Serializable]
    public class CCorrect_Position : CMeasureCell
    {
        /// <summary>
        /// 当前图像名称
        /// </summary>
        public string m_CurrentImgName = string.Empty;

        /// <summary>
        /// 模板类型
        /// </summary>
        public ModelType m_ModelType;

        /// <summary>
        /// 模板
        /// </summary>
        public HHandle m_Model;

        /// <summary>
        /// 模板区域
        /// </summary>
        public ROI m_ModelRegion;
        /// <summary>
        /// 搜索区域
        /// </summary>
        public ROI m_SearchRegion;

        /// <summary>
        /// 注册模板位置信息 像素坐标
        /// </summary>
        public Coordinate_INFO m_PositionInfo = new Coordinate_INFO();

        /// <summary>
        /// 是否屏蔽角度,如果屏蔽,则角度返回的是0 magical 20171012
        /// </summary>
        public bool disableAngle = false;

        /// <summary>
        /// 创建模板角度范围 kelly 20180119
        /// </summary>
        public double dStartPhi = 0f;

        public double dEndPhi = 0f;

        public CCorrect_Position()
            : base()
        {
        }

        public CCorrect_Position(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
        }
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, m_CurrentImgName, out m_Image);

                Coordinate_INFO coord = new Coordinate_INFO();
                if (!m_Model.IsInitialized())
                {
                    HMeasureSet.CreateModel(m_ModelType, ref m_Model, dStartPhi, dEndPhi, m_Image, m_ModelRegion);
                    HMeasureSet.FindModel(m_ModelType, m_Model, dStartPhi, dEndPhi, m_Image, m_SearchRegion, out m_PositionInfo);
                }
                HMeasureSet.FindModel(m_ModelType, m_Model, dStartPhi, dEndPhi, m_Image, m_SearchRegion, out coord);
                if (disableAngle)
                {
                    coord.Phi = 0;//屏蔽角度 magical 20171012
                }
                HHomMat2D homMat2D = new HHomMat2D();
                homMat2D.VectorAngleToRigid(m_PositionInfo.Y, m_PositionInfo.X, m_PositionInfo.Phi, coord.Y, coord.X, coord.Phi);
                
                //轮廓匹配显示轮廓 magical 20170821
                if (m_ModelType == ModelType.形状模板)
                {
                    HHomMat2D tempMat2D = new HHomMat2D();
                    tempMat2D.VectorAngleToRigid(0,0,0, coord.Y, coord.X, coord.Phi);
                    HXLDCont contour_xld = ((HShapeModel)this.m_Model).GetShapeModelContours(1);
                    contour_xld = contour_xld.AffineTransContourXld(tempMat2D);

                    MeasureROI roi检测结果 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测结果.ToString(), "red", new HObject(contour_xld));
                    m_Image.UpdateRoiList(roi检测结果);
                }
                //匹配中心
                HXLDCont cross = new HXLDCont();
                cross.GenCrossContourXld(coord.Y, coord.X, 6, coord.Phi);
                MeasureROI roi检测点 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测点.ToString(), "blue", new HObject(cross));
                //搜索范围
                MeasureROI roi搜索范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.搜索范围.ToString(), "red", new HObject(m_SearchRegion.genXLD()));
                //检测范围
                HXLDCont modelRegionXLD = m_ModelRegion.genXLD().AffineTransContourXld(homMat2D);
                MeasureROI roi检测范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(modelRegionXLD));

                m_Image.UpdateRoiList(roi检测点);
                m_Image.UpdateRoiList(roi搜索范围);
                m_Image.UpdateRoiList(roi检测范围);
                //end magical

                //坐标转换为世界坐标
                HMeasureSet.Points2WorldPlane(m_Image, coord.Y, coord.X, out coord.X, out coord.Y);
                object NewValue = new List<Coordinate_INFO>() { new Coordinate_INFO(coord.Y,coord.X,coord.Phi-m_PositionInfo.Phi) };
                F_DATA_CELL datacell = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.坐标系, ConstVavriable.outCoord
                            , "位置补正坐标系", "0", 1
                            , NewValue, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(datacell);
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                //位置补正失败，返回 无变换矩阵
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                //object NewValue = new List<HHomMat2D>() { new HHomMat2D() };
                //m_Owner.UpdateVariableValue(m_CellID, ConstVavriable.outHomMat2D, NewValue);
                blnSuccessed = false;
            }
        }
    }
}
