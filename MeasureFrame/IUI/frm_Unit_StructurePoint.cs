using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;
using System.Drawing;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_StructurePoint : frm_Unit_ImageBase
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_StructurePoint()
            : base()
        {
            InitializeComponent();
            m_Unit = new CStructurePoint(CellCatagory.构造点, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_StructurePoint(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_StructurePoint_Load(object sender, EventArgs e)
        {
            rad_CheckedChanged(sender, e);
            InitCurrentCmbImgList();
            InitFirstUnitIDCmbList();
            InitSecondUnitIDCmbList();
            string m_FlowID = "U" + ((CStructurePoint)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CStructurePoint)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CStructurePoint)m_Unit).m_CellDesCribe;
            if (!blnNewUnit)
            {
                if (((CStructurePoint)m_Unit).CreateCoordMode == 0)
                    rad_StructurePoint.Checked = true;
                else if (((CStructurePoint)m_Unit).CreateCoordMode == 1)
                    rad_Pedal.Checked = true;
                else if (((CStructurePoint)m_Unit).CreateCoordMode == 2)
                    rad_Cross.Checked = true;
                cmb_FirstUnitID.Text = "U" + ((CStructurePoint)m_Unit).FirstUnitID.ToString("D4");
                cmb_SecondUnitID.Text = "U" + ((CStructurePoint)m_Unit).SecondUnitID.ToString("D4");

                cmb_CurrentImg.Text = ((CStructurePoint)m_Unit).CurrentImgName;
                
                m_Unit.Execute();//再检测
                PaintMetrology();
            }
            this.cmb_CurrentImg.SelectedIndexChanged += new System.EventHandler(this.bt_Save_Click);

            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
        }


        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (rad_StructurePoint.Checked)
                ((CStructurePoint)m_Unit).CreateCoordMode = 0;
            else if (rad_Pedal.Checked)
                ((CStructurePoint)m_Unit).CreateCoordMode = 1;
            else if (rad_Cross.Checked)
                ((CStructurePoint)m_Unit).CreateCoordMode = 2;

            if (cmb_FirstUnitID.SelectedIndex >= 0)
                ((CStructurePoint)m_Unit).FirstUnitID = int.Parse(cmb_FirstUnitID.Text.Substring(1));
            if (cmb_SecondUnitID.SelectedIndex >= 0)
                ((CStructurePoint)m_Unit).SecondUnitID = int.Parse(cmb_SecondUnitID.Text.Substring(1));

            ((CStructurePoint)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            ((CStructurePoint)m_Unit).CurrentImgName = cmb_CurrentImg.Text;

            m_Unit.Execute();
            PaintMetrology();
        }


        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_StructurePoint.Checked)
            {
                groupBox1.Enabled = false;
                bt_GetPoint.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = true;
                bt_GetPoint.Enabled = false;
            }
            InitFirstUnitIDCmbList();
            }

        /// <summary>
        /// 初始化第一点单元ID列表
        /// </summary>
        protected void InitFirstUnitIDCmbList()
        {
            List<string> m_LineUnitIDList = new List<string>();//直线单元ID列表
            IEnumerable<string> resultList;
            if (rad_Cross.Checked)
                resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                             where datacell.m_Data_Type == DataType.直线
                             select "U" + datacell.m_Data_CellID.ToString("D4");
            else
                resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
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
            resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                         where datacell.m_Data_Type == DataType.直线
                         select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PointUnitIDList = resultList.Distinct().ToList();
            cmb_SecondUnitID.DataSource = m_PointUnitIDList;
        }

        private void bt_GetPoint_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            PointF Point = new PointF();
            double row, col, X, Y;
            frm_Main.thisHandle.hWindow_Fit.DrawPoint("green", out row, out col);

            //像素坐标转世界坐标
            HMeasureSet.Points2WorldPlane(m_Unit.m_Image, row, col, out X, out Y);
            ////世界坐标转当前相对坐标
            Point = new PointF((float)X, (float)Y);
            ((CStructurePoint)m_Unit).Point = Point;
            m_Unit.Execute();//再检测
            PaintMetrology();
            this.Visible = true;
        }
    }
}
