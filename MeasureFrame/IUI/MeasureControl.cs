using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Measure.UserDefine;
using HalconDotNet;

namespace MeasureFrame.IUI
{
    public partial class MeasureControl : UserControl
    {
        public MeasureControl()
        {
            InitializeComponent();
        }
        public Metrology_INFO GetMetrologInfo()
        {
            Metrology_INFO m_MetrologyInfo = new Metrology_INFO();
            try
            {
                m_MetrologyInfo.Length1 = Convert.ToDouble(num_Length1.Text.Trim());
                m_MetrologyInfo.Length2 = Convert.ToDouble(num_Length2.Text.Trim());
                m_MetrologyInfo.Threshold = Convert.ToDouble(num_Threshold.Text.Trim());
                m_MetrologyInfo.MeasureDis = Convert.ToDouble(num_MeasureDis.Text.Trim());
                m_MetrologyInfo.PointsOrder = cb_Direction.SelectedIndex;
                string mTransition = "negative";
                //string m_PointsOrder = "positive"; //传输点的方向是顺时针还是逆时针暂时还没有设计
                string mSelect = "first";
                if (cb_Transition.SelectedIndex == 0)
                    mTransition = "negative";
                else if (cb_Transition.SelectedIndex == 1)
                    mTransition = "positive";
                else if (cb_Transition.SelectedIndex == 2)
                    mTransition = "all";
                else if (cb_Transition.SelectedIndex == 3)
                    mTransition = "uniform";

                if (cb_Select.SelectedIndex == 0)
                    mSelect = "first";
                else if (cb_Select.SelectedIndex == 1)
                    mSelect = "last";
                else if (cb_Select.SelectedIndex == 2)
                    mSelect = "all";
                else if (cb_Select.SelectedIndex == 3)
                    mSelect = "strongest";//magical 20180405 增加最强边边缘

                m_MetrologyInfo.ParamName = new HTuple();
                m_MetrologyInfo.ParamName.Append("measure_transition");
                m_MetrologyInfo.ParamName.Append("measure_select");
                m_MetrologyInfo.ParamName.Append("measure_distance");
                //m_MetrologyInfo.ParamName.Append("max_num_iterations");
                //m_MetrologyInfo.ParamName.Append("measure_interpolation");

                m_MetrologyInfo.ParamValue = new HTuple();
                m_MetrologyInfo.ParamValue.Append(mTransition);
                m_MetrologyInfo.ParamValue.Append(mSelect);
                m_MetrologyInfo.ParamValue.Append(m_MetrologyInfo.MeasureDis);
                //m_MetrologyInfo.ParamValue.Append(-1);
                //m_MetrologyInfo.ParamValue.Append("nearest_neighbor");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            return m_MetrologyInfo;
        }
        public void UpdateUI(Metrology_INFO m_MetrologyInfo)
        {
            if (null != m_MetrologyInfo.ParamName)
            {
                num_Length1.Text = m_MetrologyInfo.Length1.ToString();
                num_Length2.Text = m_MetrologyInfo.Length2.ToString();
                num_Threshold.Text = m_MetrologyInfo.Threshold.ToString();
                num_MeasureDis.Text = m_MetrologyInfo.MeasureDis.ToString();
                cb_Direction.SelectedIndex = m_MetrologyInfo.PointsOrder;

                string mTransition = m_MetrologyInfo.ParamValue[0].S;
                string mSelect = m_MetrologyInfo.ParamValue[1].S;

                if (mTransition == "negative")
                    cb_Transition.SelectedIndex = 0;
                else if (mTransition == "positive")
                    cb_Transition.SelectedIndex = 1;
                else if (mTransition == "all")
                    cb_Transition.SelectedIndex = 2;
                else if (mTransition == "uniform")
                    cb_Transition.SelectedIndex = 3;

                if (mSelect == "first")
                    cb_Select.SelectedIndex = 0;
                else if (mSelect == "last")
                    cb_Select.SelectedIndex = 1;
                else if (mSelect == "all")
                    cb_Select.SelectedIndex = 2;
                else if (mSelect == "strongest")
                    cb_Select.SelectedIndex = 3;
            }
        }

        public void ShowDefultValue()
        {
            num_Length1.Text = "15";
            num_Length2.Text = "4";
            num_Threshold.Text = "30";
            num_MeasureDis.Text = "4";
            cb_Transition.SelectedIndex = 0;
            cb_Select.SelectedIndex = 0;
            cb_Direction.SelectedIndex = 0;
        }
    }
}
