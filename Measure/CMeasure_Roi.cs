using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;

namespace Measure
{
    [Serializable]
    public class CMeasure_Roi : CMeasureCell
    {
        [NonSerialized]
        protected HImage hv_image;
        [NonSerialized]
        protected HImage hv_image_roi;
        protected HRegion hv_region;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CMeasure_Roi()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inImage"></param>
        public CMeasure_Roi(HImage inImage)
        {
            if (inImage != null)
            {
                this.hv_image = inImage;
                if (hv_region != null)
                {
                    hv_image_roi = hv_image.ReduceDomain(hv_region);
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inImage"></param>
        /// <param name="inRegion"></param>
        public CMeasure_Roi(HImage inImage, HRegion inRegion)
        {
            if (inImage != null)
            {
                this.hv_image = inImage;
                if (inRegion != null)
                {
                    this.hv_region = inRegion;
                    hv_image_roi = hv_image.ReduceDomain(hv_region);
                }
            }
        }

        public HImage Image
        {
            get { return this.hv_image; }
            set
            {
                if (value != null)
                {
                    this.hv_image = value;
                    if (hv_region != null)
                    {
                        hv_image_roi = hv_image.ReduceDomain(hv_region);
                    }
                }
            }
        }

        public HRegion Region
        {
            get { return this.hv_region; }
            set
            {
                if (value != null)
                {
                    this.hv_region = value;
                    if (hv_image != null)
                    {
                        hv_image_roi = hv_image.ReduceDomain(hv_region);
                    }
                }
            }
        }

        public HImage Image_Roi
        {
            get { return this.hv_image_roi; }
        }

        /// <summary>
        /// 兴趣区域的值特征  均值
        /// </summary>
        /// <returns></returns>
        public HTuple getGray_Mean()
        {
            HTuple Mean = new HTuple();
            try
            {
                HTuple Deviation = new HTuple();
                Mean = hv_region.Intensity(hv_image, out Deviation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Mean;
        }

        /// <summary>
        /// 中值
        /// </summary>
        /// <returns></returns>
        public HTuple getGray_Median()
        {

            HTuple Median = HTuple.TupleGenConst(0, 0);
            try
            {
                HTuple row, col, temp_value;
                int cout = hv_region.CountObj();
                for (int i = 0; i < cout; i++)
                {
                    hv_region[i].GetRegionPoints(out row, out col);
                    temp_value = hv_image.GetGrayval(row, col);
                    Median.Append(temp_value.TupleMedian());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Median;
        }

        /// <summary>
        /// 中通滤波
        /// </summary>
        /// <param name="_percent"></param>
        /// <returns></returns>
        public HTuple getGray_midAllowFilter(double _percent)
        {
            double percent = (100 - (_percent % 100)) / 2.0;
            HTuple h_Gray = HTuple.TupleGenConst(0, 0);
            try
            {
                HTuple row, col, temp_value;
                int cout = hv_region.CountObj();
                for (int i = 0; i < cout; i++)
                {
                    double _min = 0.0, _max = 0.0, _range = 0.0;
                    hv_region[i].GetRegionPoints(out row, out col);
                    temp_value = hv_image.GetGrayval(row, col);
                    hv_region[i].MinMaxGray(hv_image, percent, out _min, out _max, out _range);

                    HTuple _mask = temp_value.TupleLessElem(_max);
                    temp_value = temp_value.TupleSelectMask(_mask);
                    _mask = temp_value.TupleGreaterElem(_min);
                    temp_value = temp_value.TupleSelectMask(_mask);

                    h_Gray.Append(temp_value.TupleMean());
                }
            }
            catch (Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
            }
            return h_Gray;
        }


        /// <summary>
        /// 高通滤波 eg 40 最高的40%通过
        /// </summary>
        /// <param name="_percent"></param>
        /// <returns></returns>
        public HTuple getGray_highAllowFilter(double _percent)
        {
            double percent = _percent % 100;
            double temp_percent = percent > 50 ? 100 - percent : percent;
            HTuple h_Gray = HTuple.TupleGenConst(0, 0);
            try
            {
                HTuple row, col, temp_value;
                int cout = hv_region.CountObj();
                for (int i = 0; i < cout; i++)
                {
                    double _min = 0.0, _max = 0.0, _range = 0.0;
                    HTuple _mask;
                    hv_region[i].GetRegionPoints(out row, out col);
                    temp_value = hv_image.GetGrayval(row, col);
                    hv_region[i].MinMaxGray(hv_image, temp_percent, out _min, out _max, out _range);
                    if (percent > 50)
                        _mask = temp_value.TupleGreaterElem(_min);
                    else
                        _mask = temp_value.TupleGreaterElem(_max);
                    temp_value = temp_value.TupleSelectMask(_mask);

                    h_Gray.Append(temp_value.TupleMean());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return h_Gray;
        }

        /// <summary>
        /// 低通滤波 eg 40 最低的40%通过
        /// </summary>
        /// <param name="_percent"></param>
        /// <returns></returns>
        public HTuple getGray_lowAllowFilter(double _percent)
        {
            double percent = _percent % 100;
            double temp_percent = percent > 50 ? 100 - percent : percent;
            HTuple h_Gray = HTuple.TupleGenConst(0, 0);
            try
            {
                HTuple row, col, temp_value;
                int cout = hv_region.CountObj();
                for (int i = 0; i < cout; i++)
                {
                    double _min = 0.0, _max = 0.0, _range = 0.0;
                    HTuple _mask;
                    hv_region[i].GetRegionPoints(out row, out col);
                    temp_value = hv_image.GetGrayval(row, col);
                    hv_region[i].MinMaxGray(hv_image, temp_percent, out _min, out _max, out _range);
                    if (percent > 50)
                        _mask = temp_value.TupleLessElem(_max);
                    else
                        _mask = temp_value.TupleLessElem(_min);
                    temp_value = temp_value.TupleSelectMask(_mask);

                    h_Gray.Append(temp_value.TupleMean());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return h_Gray;
        }
    }
}
