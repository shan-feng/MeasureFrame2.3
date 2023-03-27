using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_Measure : frm_Unit
    {
        protected Metrology_INFO m_MetrologyInfo = new Metrology_INFO();
        //protected HImageExt m_Image = new HImageExt();//辅助显示图像

        [NonSerialized]
        protected HRegion disableRegion = new HRegion();//屏蔽区域 magical 20171028
        [NonSerialized]
        protected HRegion tempDisableRegion = new HRegion();

        /// <summary>
        /// 补正坐标系
        /// </summary>
        [NonSerialized]
        public Coordinate_INFO Coord = new Coordinate_INFO();
        public frm_Unit_Measure()
            : base()
        {
            InitializeComponent();
        }

        public frm_Unit_Measure(ref CMeasureCell CellBase)
            : base(ref CellBase)
        {
            InitializeComponent();
        }

        //加载窗体时
        protected virtual void frm_OnLoad()
        {
            InitCurrentCmbImgList();
            InitCmb_Position();
            string m_FlowID = "U" + ((CMeasure_2D)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CMeasure_2D)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CMeasure_2D)m_Unit).m_CellDesCribe;

            ///初始化文本框
            cmb_PositionUnitID.SelectedIndex = 0;
            string temp_color = ((CMeasure_2D)m_Unit).m_drawColor.Substring(1, 2);
            int r = Convert.ToInt32(temp_color, 16);
            temp_color = ((CMeasure_2D)m_Unit).m_drawColor.Substring(3, 2);
            int g = Convert.ToInt32(temp_color, 16);
            temp_color = ((CMeasure_2D)m_Unit).m_drawColor.Substring(5, 2);
            int b = Convert.ToInt32(temp_color, 16);
            bt_Color.BackColor = Color.FromArgb(r, g, b);
            if (!blnNewUnit)
            {
                chkCorrect.Checked = ((CMeasure_2D)m_Unit).isCorrect;
                disableRegion = ((CMeasure_2D)m_Unit).disableRegion;
                m_MetrologyInfo = ((CMeasure_2D)m_Unit).m_MetrologyInfo;
                if (null != m_MetrologyInfo.ParamName)
                {
                    num_Length1.Text = ((CMeasure_2D)m_Unit).m_MetrologyInfo.Length1.ToString();
                    num_Length2.Text = ((CMeasure_2D)m_Unit).m_MetrologyInfo.Length2.ToString();
                    num_Threshold.Text = ((CMeasure_2D)m_Unit).m_MetrologyInfo.Threshold.ToString();
                    num_MeasureDis.Text = ((CMeasure_2D)m_Unit).m_MetrologyInfo.MeasureDis.ToString();
                    cb_Direction.SelectedIndex = m_MetrologyInfo.PointsOrder;

                    string mTransition = ((CMeasure_2D)m_Unit).m_MetrologyInfo.ParamValue[0].S;
                    string mSelect = ((CMeasure_2D)m_Unit).m_MetrologyInfo.ParamValue[1].S;

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

                    //初始化下拉列表
                    cmb_CurrentImg.Text = ((CMeasure_2D)m_Unit).m_CurrentImgName;
                }
                if (((CMeasure_2D)m_Unit).m_homMatUnitID == -1)
                {
                    cmb_PositionUnitID.Text = "无";
                }
                else
                {
                    cmb_PositionUnitID.Text = "U" + ((CMeasure_2D)m_Unit).m_homMatUnitID.ToString("D4");
                }
            }
            else
            {
                cb_Transition.SelectedIndex = 3;
                cb_Direction.SelectedIndex = 0;
                cb_Select.SelectedIndex = 0;
            }
            this.num_Length1.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.num_Length2.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.num_Threshold.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.num_MeasureDis.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.cb_Select.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            this.cb_Direction.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            this.cb_Transition.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            this.chkCorrect.CheckedChanged += new System.EventHandler(this.UpdateParam);
            this.cmb_CurrentImg.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            this.cmb_PositionUnitID.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);

            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);

        }

        private void bt_Color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                Color color_from = colorDialog.Color;
                bt_Color.BackColor = color_from;
                string m_DrawColor = color_from.ToArgb().ToString("X02");
                m_DrawColor = m_DrawColor.Substring(2);
                m_DrawColor = m_DrawColor.Insert(0, "#");
                ((CMeasure_2D)m_Unit).m_drawColor = m_DrawColor;
            }
        }


        /// <summary>
        /// 读取文本框中的Metrology信息
        /// </summary>
        private void setMetrologInfo()
        {
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
        }

        protected virtual void UpdateParam(object sender, EventArgs e)
        {
            setMetrologInfo();
            ((CMeasure_2D)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            ((CMeasure_2D)m_Unit).m_MetrologyInfo = this.m_MetrologyInfo;
            ((CMeasure_2D)m_Unit).m_CurrentImgName = cmb_CurrentImg.Text;
            if (cmb_PositionUnitID.Text.Trim() == "无")
            {
                ((CMeasure_2D)m_Unit).m_homMatUnitID = -1;
                chkCorrect.Checked = false;
                chkCorrect.Enabled = false;
                Coord = new Coordinate_INFO();
            }
            else
            {
                chkCorrect.Enabled = true;
                ((CMeasure_2D)m_Unit).m_homMatUnitID = int.Parse(cmb_PositionUnitID.Text.Substring(1));

                F_DATA_CELL data = m_Unit.m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == ((CMeasure_2D)m_Unit).m_homMatUnitID);
                Coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
            }
            ((CMeasure_2D)m_Unit).isCorrect = chkCorrect.Checked;
            m_Unit.Execute();//再检测
            PaintMetrology();
        }


        private void frm_Unit_Measure_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }

        /// <summary>
        /// 初始化位置补正列表
        /// </summary>
        public void InitCmb_Position()
        {
            List<string> m_PositionList = new List<string>() { "无" };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.坐标系// ||datacell.m_Data_Type == DataType.位置转换2D && datacell.m_Data_CellID != HMeasureSYS.U000
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_PositionUnitID.DataSource = m_PositionList;
        }

        /// <summary>
        /// 初始化当前图像列表
        /// </summary>
        protected void InitCurrentCmbImgList()
        {
            List<string> m_CurrentImageNames = new List<string>();//当前图像名称列表
            List<F_DATA_CELL> imgList = new List<F_DATA_CELL>();
            HMeasureSet.getVariableImageList(HMeasureSYS.Cur_Project.m_VariableList, out imgList);
            foreach (F_DATA_CELL datacell in imgList)
            {
                m_CurrentImageNames.Add(datacell.m_Data_Name);
            }
            cmb_CurrentImg.DataSource = m_CurrentImageNames;
        }

        /// <summary>
        /// 涂抹模板区域 kelly 20170107
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_DisableRegion_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (disableRegion == null || !disableRegion.IsInitialized())
            {
                disableRegion = new HRegion();
            }
            disableRegion = frm_Main.thisHandle.hWindow_Fit.SetROI(disableRegion);
            if (disableRegion != null && disableRegion.IsInitialized())
            {
                double row, col, x, y, phi;
                //disableRegion.EllipticAxis(out x, out phi);
                disableRegion.AreaCenter(out row, out col);
                HMeasureSet.Points2WorldPlane(m_Unit.m_Image, row, col, out x, out y);
                HHomMat2D hom = VBA_Function.setOrig(Coord.X, Coord.Y, -Coord.Phi);
                x = hom.AffineTransPoint2d(x, y, out y);
                ((CMeasure_2D)m_Unit).RegCoor = new Coordinate_INFO(y, x, Coord.Phi);
                ((CMeasure_2D)m_Unit).disableRegion = disableRegion;

                m_Unit.Execute();//再检测
                PaintMetrology();
            }
            
            this.Visible = true;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            m_Unit.Execute();
            PaintMetrology();
        }
    }
}
