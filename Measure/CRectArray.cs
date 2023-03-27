using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using Measure.UserDefine;
using AcqDevice;
using CPublicDefine;
using System.Runtime.Serialization;

namespace Measure
{
    /// <summary>
    /// 创建矩形阵列
    /// </summary>
    [Serializable]
    public class CRectArray : CMeasureCell
    {
        /// <summary>
        /// 当前图像名称
        /// </summary>
        public string m_CurrentImgName = string.Empty;

        /// <summary>
        /// 位置补正的单元ID
        /// </summary>
        public int m_homMatUnitID;

        /// <summary>
        ///矩阵列表
        /// </summary>
        public List<Rectangle2_INFO> m_RectArray;

        /// <summary>
        /// 图像预处理
        /// </summary>
        public PreTreatMent m_PreTreatment;

        /// <summary>
        /// 返回3D点 Z为grayvalue or Height
        /// </summary>
        public List<RectInfo> m_RectInfo = new List<RectInfo>();//这里使用3D点并不一定是最明智的，使用分开的x，y，grayvalue， max，min或许更好

        /// <summary>
        /// 区域颜色
        /// </summary>
        public string m_DrawColor = "#00FF00";


        public CRectArray() : base()
        {
        }

        public CRectArray(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        private HXLDCont getRectXLD(List<Rectangle2_INFO> rectList)
        {
            HTuple rows = new HTuple();
            HTuple cols = new HTuple();
            HTuple phis = new HTuple();
            HTuple length1 = new HTuple();
            HTuple length2 = new HTuple();
            foreach (Rectangle2_INFO rect in rectList)
            {
                rows.Append(rect.CenterY);
                cols.Append(rect.CenterX);
                phis.Append(rect.Phi);
                length1.Append(rect.Length1);
                length2.Append(rect.Length2);
            }
            HXLDCont hobj = new HXLDCont();
            if (rows.Length > 0)
            {
                hobj.GenRectangle2ContourXld(rows, cols, phis, length1, length2);
            }
            return hobj;
        }

        /// <summary>
        /// 查询矩形阵列的信息
        /// </summary>
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                List<Rectangle2_INFO> tempRectInfo = new List<Rectangle2_INFO>();
                m_Owner.QueryImage(ImageCatagory.当前图像, m_CurrentImgName, out m_Image);
                Coordinate_INFO coord = new Coordinate_INFO();
                if (m_homMatUnitID > -1)
                {
                    F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == m_homMatUnitID && c.m_Data_Name == ConstVavriable.outCoord);
                    coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
                }
                HMeasureSet.RectPosition(m_Image, m_RectArray, coord, out tempRectInfo);
                HMeasureSet.QueryRectInfo(m_Image, tempRectInfo, m_PreTreatment, out m_RectInfo);

                HXLDCont CoordXLD = HMeasureSet.GetCoord(m_Image, coord);
                MeasureROI roi坐标系 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.参考坐标系.ToString(), "green", new HObject(CoordXLD));
                m_Image.UpdateRoiList(roi坐标系);

                //添加检测roi  magical 20170821
                MeasureROI roi检测范围 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(getRectXLD(tempRectInfo)));
                m_Image.UpdateRoiList(roi检测范围);
                //end magical
                F_DATA_CELL dataRect = new F_DATA_CELL(m_CellID, DataGroup.数组, DataType.矩形阵列, ConstVavriable.outRectInfo
                                            , "检测矩形区域信息", "0", m_RectInfo.Count, m_RectInfo, DataAtrribution.全局变量);

                m_Owner.UpdateVariableValue(dataRect);
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                F_DATA_CELL dataRect = new F_DATA_CELL();
                dataRect.InitValue(m_CellID, ConstVavriable.outRectInfo, DataType.矩形阵列, "");
                m_Owner.UpdateVariableValue(dataRect);
                blnSuccessed = false;
            }
        }
    }
}
