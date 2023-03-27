using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using Measure.UserDefine;

namespace Measure
{
    //1D 测量点
    [Serializable]
    public class CMeasure1D : CMeasureCell
    {
        [NonSerialized]
        private HImage _image;
        private int h_width, h_height;
        //输出检测点
        protected HTuple m_row, m_col;

        public HImage hv_image
        {
            set
            {
                _image = value;
                _image.GetImageSize(out h_width, out h_height);
            }
            get { return _image; }
        }

        public HTuple point_Row
        {
            get { return m_row; }
        }

        public HTuple points_Col
        {
            get { return m_col; }
        }

        public CMeasure1D(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        /// <summary>
        /// 获取点数据
        /// </summary>
        /// <param name="Rec2_INFO">取点的矩形框</param>
        /// <param name="threshold">阈值</param>
        /// <param name="transition">"all" "positive" "negitive" 详见halcon解释</param>
        /// <param name="select">"all" "first" "last" 详见halcon解释</param>
        public void Measure_Pos(Rectangle2_INFO Rec2_INFO, double threshold, string transition, string select)
        {
            try
            {
                HMeasure hMeasure = new HMeasure();
                hMeasure.GenMeasureRectangle2(Rec2_INFO.CenterY, Rec2_INFO.CenterX, Rec2_INFO.Phi, Rec2_INFO.Length1
                    , Rec2_INFO.Length2, h_width, h_height, "nearest_neighbor");
                HTuple amplitude, distance;
                _image.MeasurePos(hMeasure, 1.0, threshold, transition, select, out m_row, out m_col, out amplitude, out distance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Measure.CMeasure1D.Measure_Pos:" + ex.Message);
            }
        }
    }
}
