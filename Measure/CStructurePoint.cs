using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace Measure
{
    [Serializable]
    public class CStructurePoint : CMeasureCell
    {
        /// <summary>
        /// 构造点模式 0-鼠标构造点 1--点到线锤点 2--线线交点 
        /// </summary>
        public int CreateCoordMode = 0;

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
        /// 构造点
        /// </summary>
        public PointF Point = new PointF();
        public CStructurePoint() : base()
        {

        }
        public CStructurePoint(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {

        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, CurrentImgName, out m_Image);
                //查找对应的直线
                F_DATA_CELL FirstData = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == FirstUnitID);
                F_DATA_CELL SecondData = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == SecondUnitID);
                PointF firstPoint = new PointF();
                Line_INFO line1 = new Line_INFO();
                Line_INFO line2 = new Line_INFO();
                switch (FirstData.m_Data_Type)
                {
                    case DataType.点2D:
                        firstPoint= ((List<PointF>)FirstData.m_Data_Value)[0];
                        break;
                    case DataType.直线:
                        line1 = ((List<Line_INFO>)FirstData.m_Data_Value)[0];
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
                    case DataType.直线:
                        line2 = ((List<Line_INFO>)SecondData.m_Data_Value)[0];
                        break;
                    case DataType.圆:
                        Circle_INFO circle1 = ((List<Circle_INFO>)SecondData.m_Data_Value)[0];
                        break;
                    case DataType.椭圆:
                        Ellipse_INFO ellipse1 = ((List<Ellipse_INFO>)SecondData.m_Data_Value)[0];
                        break;
                }
                double x, y;
                switch (CreateCoordMode)
                {
                    case 0:
                        break;
                    case 1:
                        VBA_Function.CalPointLinePedal(firstPoint.Y, firstPoint.X, line2, out y, out x);
                        Point = new PointF((float)x, (float)y);
                        break;
                    case 2:
                        int isP;
                        HMisc.IntersectionLl(line1.StartY, line1.StartX, line1.EndY, line1.EndX, line2.StartY, line2.StartX, line2.EndY, line2.EndX, out y, out x, out isP);
                        Point = new PointF((float)x, (float)y);
                        break;
                }
                HMeasureSet.WorldPlane2Point(m_Image, Point.X, Point.Y, out y, out x);

                HXLDCont xld = new HXLDCont();
                xld.GenCrossContourXld(y, x, 10, 0);
                Rectangle2_INFO rect = new Rectangle2_INFO(y, x, 0, 2.5, 2.5);
                xld = xld.ConcatObj(rect.genXLD());
                MeasureROI roi坐标系 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.参考坐标系.ToString(), "green", new HObject(xld));
                m_Image.UpdateRoiList(roi坐标系);

                object NewValue = new List<PointF>() { Point };
                F_DATA_CELL data = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.点2D, ConstVavriable.outPointF
                                            , "创建点", "0", 1, NewValue, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(data);

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
