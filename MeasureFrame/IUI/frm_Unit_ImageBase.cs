using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_ImageBase : frm_Unit
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_ImageBase()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_ImageBase(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载的时候加载的程序
        /// </summary>
        /// <remarks>本来放在父窗口load的重载事件中，那样子窗体就视图在非调试情况下不能显示</remarks>
        protected void frm_OnLoad()
        {

            InitCurrentCmbImgList();
            ///初始化文本框

            this.cmb_CurrentImg.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
        }

        protected virtual void UpdateParam(object sender, EventArgs e)
        {
            m_Unit.m_CellDesCribe = txt_UnitDescrible.Text.Trim();
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

        private void frm_Unit_ImageBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }

    }
}
