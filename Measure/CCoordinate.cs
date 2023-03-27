using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace Measure
{
    /// <summary>
    /// 创建直角坐标系
    /// </summary>
    [Serializable]
    public class CCoordinate : CMeasureCell
    {
        /// <summary>
        /// 当前图像中寻找的坐标
        /// </summary>
        public Coordinate_INFO CoordinateInfo = new Coordinate_INFO();

        public int CreateCoordMode = 0; //0--过X轴 1--过Y轴 2--原点加直线角度 3--原点加 2 3 两点直线角度

        /// <summary>
        /// 当前图像名称
        /// </summary>
        public string CurrentImgName = string.Empty;

        /// <summary>
        /// 第一个点的单元ID
        /// </summary>
        public int FirstUnitID;

        /// <summary>
        /// 第二个点的单元ID
        /// </summary>
        public int SecondUnitID;

        /// <summary>
        /// 第三个点的单元ID
        /// </summary>
        public int ThirdUnitID;
        
        public CCoordinate() : base()
        {

        }
        public CCoordinate(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {

        }

        /// <summary>
        /// 建立直角坐标系
        /// </summary>
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, CurrentImgName, out m_Image);

               
                F_DATA_CELL FirstData = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == FirstUnitID);
                F_DATA_CELL SecondData = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == SecondUnitID);
                F_DATA_CELL ThirdData = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == ThirdUnitID);
                PointF firstPoint = new PointF(), SecondPoint = new PointF(), ThirdPoint = new PointF();
                Line_INFO line = new Line_INFO();
                switch (FirstData.m_Data_Type)
                {
                    case DataType.点2D:
                        firstPoint = ((List<PointF>)FirstData.m_Data_Value)[0];
                        break;
                    case DataType.直线:
                        Line_INFO line1 = ((List<Line_INFO>)FirstData.m_Data_Value)[0];
                        firstPoint = new PointF((float)line1.MidX, (float)line1.MidY);
                        break;
                    case DataType.圆:
                        Circle_INFO circle1 = ((List<Circle_INFO>)FirstData.m_Data_Value)[0];
                        firstPoint = new PointF((float)circle1.CenterX, (float)circle1.CenterY);
                        break;
                    case DataType.椭圆:
                        Ellipse_INFO ellipse1 = ((List<Ellipse_INFO>)FirstData.m_Data_Value)[0];
                        firstPoint = new PointF((float)ellipse1.CenterX, (float)ellipse1.CenterY);
                        break;
                }
                switch (SecondData.m_Data_Type)
                {
                    case DataType.点2D:
                        SecondPoint = ((List<PointF>)FirstData.m_Data_Value)[0];
                        break;
                    case DataType.直线:
                        line = ((List<Line_INFO>)SecondData.m_Data_Value)[0];
                        SecondPoint = new PointF((float)line.MidX, (float)line.MidY);
                        break;
                    case DataType.圆:
                        Circle_INFO circle1 = ((List<Circle_INFO>)SecondData.m_Data_Value)[0];
                        SecondPoint = new PointF((float)circle1.CenterX, (float)circle1.CenterY);
                        break;
                    case DataType.椭圆:
                        Ellipse_INFO ellipse1 = ((List<Ellipse_INFO>)SecondData.m_Data_Value)[0];
                        SecondPoint = new PointF((float)ellipse1.CenterX, (float)ellipse1.CenterY);
                        break;
                }
                switch (ThirdData.m_Data_Type)
                {
                    case DataType.点2D:
                        ThirdPoint = ((List<PointF>)FirstData.m_Data_Value)[0];
                        break;
                    case DataType.直线:
                        Line_INFO line1 = ((List<Line_INFO>)ThirdData.m_Data_Value)[0];
                        ThirdPoint = new PointF((float)line1.MidX, (float)line1.MidY);
                        break;
                    case DataType.圆:
                        Circle_INFO circle1 = ((List<Circle_INFO>)ThirdData.m_Data_Value)[0];
                        ThirdPoint = new PointF((float)circle1.CenterX, (float)circle1.CenterY);
                        break;
                    case DataType.椭圆:
                        Ellipse_INFO ellipse1 = ((List<Ellipse_INFO>)ThirdData.m_Data_Value)[0];
                        ThirdPoint = new PointF((float)ellipse1.CenterX, (float)ellipse1.CenterY);
                        break;
                }

                CoordinateInfo.Y = firstPoint.Y;
                CoordinateInfo.X = firstPoint.X;
                switch (CreateCoordMode)
                {
                    case 0:
                        CoordinateInfo.Phi = HMisc.AngleLx((double)firstPoint.Y, firstPoint.X, SecondPoint.Y, SecondPoint.X);
                        break;
                    case 1:
                        CoordinateInfo.Phi = HMisc.AngleLx((double)firstPoint.Y, firstPoint.X, SecondPoint.Y, SecondPoint.X) - Math.PI / 2;
                        break;
                    case 2:
                        CoordinateInfo.Phi = line.Phi;
                        break;
                    case 3:
                        CoordinateInfo.Phi = HMisc.AngleLx((double)SecondPoint.Y, SecondPoint.X, ThirdPoint.Y, ThirdPoint.X);
                        break;
                }

                HXLDCont CoordXLD = HMeasureSet.GetCoord(m_Image, CoordinateInfo);
                MeasureROI roi坐标系 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.参考坐标系.ToString(), "green", new HObject(CoordXLD));
                m_Image.UpdateRoiList(roi坐标系);

                object NewValue = new List<Coordinate_INFO>() { CoordinateInfo };
                F_DATA_CELL dataLine = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.坐标系, ConstVavriable.outCoord
                                            , "参考坐标系", "0", 1, NewValue, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataLine);
                
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }

        }
    }
}
