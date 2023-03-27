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
using System.Linq;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_MeasureShow : frm_Unit
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_MeasureShow()
            : base()
        {
            InitializeComponent();
            m_Unit = new CMeasure_Show(CellCatagory.显示单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_MeasureShow(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }


        private void frm_Unit_MeasureLine_Load(object sender, EventArgs e)
        {

            InitCurrentCmbImgList();


            PaintMetrology();

            //初始化下拉列表
            cmb_CurrentImg.Text = ((CMeasure_2D)m_Unit).m_CurrentImgName;
            this.cmb_CurrentImg.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);

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

        protected virtual void UpdateParam(object sender, EventArgs e)
        {
            ((CMeasure_2D)m_Unit).m_CurrentImgName = cmb_CurrentImg.Text;
        }


        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (blnNewUnit)
            {
                ((CMeasure_Show)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }

            this.UpdateParam(sender,e);
        }
    }
}
