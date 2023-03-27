using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_Coordinate : frm_Unit
    {
        HHomMat2D m_temp = new HHomMat2D();
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_Coordinate()
            : base()
        {
            InitializeComponent();
            m_Unit = new CCoordinate(CellCatagory.坐标系, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_Coordinate(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_Coordinate_Load(object sender, EventArgs e)
        {
            rad_CheckedChanged(sender, e);
            InitCurrentCmbImgList();
            InitFirstUnitIDCmbList();
            InitSecondUnitIDCmbList();
            InitThirdUnitIDCmbList();
            string m_FlowID = "U" + ((CCoordinate)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CCoordinate)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CCoordinate)m_Unit).m_CellDesCribe;
            if (!blnNewUnit)
            {
                if (((CCoordinate)m_Unit).CreateCoordMode == 0)
                    rad_PassX.Checked = true;
                else if (((CCoordinate)m_Unit).CreateCoordMode == 1)
                    rad_PassY.Checked = true;
                else if (((CCoordinate)m_Unit).CreateCoordMode == 2)
                    rad_PointLine.Checked = true;
                else if (((CCoordinate)m_Unit).CreateCoordMode == 3)
                    rad_3Points.Checked = true;
                cmb_FirstUnitID.Text = "U" + ((CCoordinate)m_Unit).FirstUnitID.ToString("D4");
                cmb_SecondUnitID.Text = "U" + ((CCoordinate)m_Unit).SecondUnitID.ToString("D4");
                cmb_ThirdUnitID.Text = "U" + ((CCoordinate)m_Unit).ThirdUnitID.ToString("D4");//magical 201804119增加
                cmb_CurrentImg.Text = ((CCoordinate)m_Unit).CurrentImgName;

                bt_Save_Click(sender, e);
            }

            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
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
        

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (rad_PassX.Checked)
                ((CCoordinate)m_Unit).CreateCoordMode = 0;
            else if (rad_PassY.Checked)
                ((CCoordinate)m_Unit).CreateCoordMode = 1;
            else if (rad_PointLine.Checked)
                ((CCoordinate)m_Unit).CreateCoordMode = 2;
            else if (rad_3Points.Checked)
                ((CCoordinate)m_Unit).CreateCoordMode = 3;

            if (cmb_FirstUnitID.SelectedIndex >= 0)
                ((CCoordinate)m_Unit).FirstUnitID = int.Parse(cmb_FirstUnitID.Text.Substring(1));
            if (cmb_SecondUnitID.SelectedIndex >= 0)
                ((CCoordinate)m_Unit).SecondUnitID = int.Parse(cmb_SecondUnitID.Text.Substring(1));
            if (cmb_ThirdUnitID.SelectedIndex >= 0)
                ((CCoordinate)m_Unit).ThirdUnitID = int.Parse(cmb_ThirdUnitID.Text.Substring(1));

            ((CCoordinate)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            ((CCoordinate)m_Unit).CurrentImgName = cmb_CurrentImg.Text;

            m_Unit.Execute();
            PaintMetrology();
        }
        

        private void frm_Unit_Coordinate_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }
        
        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_3Points.Checked)
                cmb_ThirdUnitID.Enabled = true;
            else
                cmb_ThirdUnitID.Enabled = false;
            InitSecondUnitIDCmbList();
        }

        /// <summary>
        /// 初始化第一点单元ID列表
        /// </summary>
        protected void InitFirstUnitIDCmbList()
        {
            List<string> m_LineUnitIDList = new List<string>();//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.点2D || datacell.m_Data_Type == DataType.直线 || datacell.m_Data_Type == DataType.圆 || datacell.m_Data_Type == DataType.椭圆
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_LineUnitIDList = resultList.ToList();
            cmb_FirstUnitID.DataSource = m_LineUnitIDList;
        }

        /// <summary>
        /// 初始化第二点单元ID列表
        /// </summary>
        protected void InitSecondUnitIDCmbList()
        {
            List<string> m_PointUnitIDList = new List<string>();//点单元ID列表
            IEnumerable<string> resultList;
            if (rad_PointLine.Checked)
                resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                             where datacell.m_Data_Type == DataType.直线
                             select "U" + datacell.m_Data_CellID.ToString("D4");
            else
                resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                             where datacell.m_Data_Type == DataType.点2D || datacell.m_Data_Type == DataType.直线 || datacell.m_Data_Type == DataType.圆 || datacell.m_Data_Type == DataType.椭圆
                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PointUnitIDList = resultList.Distinct().ToList();
            cmb_SecondUnitID.DataSource = m_PointUnitIDList;
        }

        /// <summary>
        /// 初始化第三点单元ID列表
        /// </summary>
        protected void InitThirdUnitIDCmbList()
        {
            List<string> m_PointUnitIDList = new List<string>();//点单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.点2D || datacell.m_Data_Type == DataType.直线 || datacell.m_Data_Type == DataType.圆 || datacell.m_Data_Type == DataType.椭圆
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PointUnitIDList = resultList.Distinct().ToList();
            cmb_ThirdUnitID.DataSource = m_PointUnitIDList;
        }
        

    }
}
