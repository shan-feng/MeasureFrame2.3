using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using Measure.UserDefine;
using CPublicDefine;
using System.Runtime.Serialization;

namespace Measure
{
    [Serializable]
    public class CMeasure_Show : CMeasure_2D
    {
        private List<MeasureROIText> roiTextList = new List<MeasureROIText>();
        public CMeasure_Show() : base()
        {
        }

        public CMeasure_Show(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        /// <summary>
        /// 显示点
        /// </summary>
        /// <param name="rowList"></param>
        /// <param name="colList"></param>
        /// <param name="size"></param>
        public void genCrossShow(List<double> rowList, List<double> colList,double size = 10,double angle = 0)
        {
          m_MeasureCross.GenCrossContourXld(new HTuple(rowList.ToArray()), new HTuple(colList.ToArray()), (int)size, angle);
        }

        /// <summary>
        /// 增加线显示
        /// </summary>
        /// <param name="rowList"></param>
        /// <param name="colList"></param>
        public void genLineShow(double start_row,double start_col, double end_row, double end_col)
        {
            m_ResultXLD.GenContourPolygonXld(new HTuple(start_row, end_row), new HTuple(start_col, end_col));
        }

        public void genTextShow(ROIText rotText)
        {

            if (roiTextList == null)
            {
                roiTextList = new List<MeasureROIText>();
            }
                MeasureROIText roi文字 = new MeasureROIText(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.文字显示.ToString(), rotText.color,
            rotText.text, rotText.font , rotText.row, rotText.col , rotText.size);
            roiTextList.Add(roi文字);
        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                m_Owner.QueryImage(ImageCatagory.当前图像, m_CurrentImgName, out m_Image);
                MeasureROI roi检测点 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测点.ToString(), "blue", new HObject(m_MeasureCross));
                MeasureROI roi线 = new MeasureROI(m_CellID.ToString(), m_CellCatagory.ToString(), m_CellDesCribe, enMeasureROIType.检测结果.ToString(), "red", new HObject(m_ResultXLD));

                m_Image.UpdateRoiList(roi检测点);
                m_Image.UpdateRoiList(roi线);

                if (roiTextList!=null)
                {
                    foreach (MeasureROIText item in roiTextList)
                    {
                        m_Image.measureROIlist.Add(item);
                    }
                    roiTextList.Clear();
                }


                blnSuccessed = true;

            }
            catch (System.Exception ex)
            {
                roiTextList.Clear();
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }
        }
    }
}
