using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using Measure;
using System.IO;
using System.Globalization;
using AcqDevice;
using Measure.UserDefine;
using System.Reflection;
using System.Diagnostics;
using CPublicDefine;
using HEViewer;
using Helper;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace MeasureFrame.IUI
{
    public partial class frm_Main : Form
    {

        private frm_Flow m_frm_Flow;
        private frm_AutoRun m_frm_AutoRun;


        private DeserializeDockContent m_deserializeDockContent;

        private DataTable m_dtFlowList;///流程列表
        private frm_Unit m_frm_Unit;
        private frm_VariableSetting m_frm_VariableSetting;
        private frm_Acquipment m_frm_Acquipment;
        private frm_ViewLog m_frm_ViewLog;
        public frm_ResultView2 m_frm_ResultView;
        public Frm_HEViewer frm_HEViewer;

        private frm_TCP_IP_Server m_frm_TCP_IP_Server;
        private frm_ProjectList m_frm_ProjectList;
        private ContextMenuStrip m_MenuStrip = new ContextMenuStrip();
        private int Cutindex = -1;//记录剪切的索引ID
        private Stopwatch sw = new Stopwatch();//计时器
        private int curListIndex = 0;

        public static frm_Main thisHandle;//由主程序赋值 magical 20171122 用以嵌入到主程序使用

        private DataGridView dgv_FlowList
        {
            get
            {
                return m_frm_Flow.dgv_FlowList;
            }
        }

        public HalconControl.HWindow_Fit hWindow_Fit
        {
            get
            {
                return m_frm_Flow.hWindow_Fit;
            }
        }
        public frm_Main()
        {
            InitializeComponent();

            m_frm_Flow = new frm_Flow();
            m_frm_ViewLog = new frm_ViewLog();
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            m_frm_Flow.dgv_FlowList.CellDoubleClick += dgv_FlowList_CellDoubleClick;
            m_frm_AutoRun = new frm_AutoRun();
            InitMenuStrip();
            m_dtFlowList = FlowListDT();
            CHelper.g_MainWnd = this.Handle;
            //ShowInTaskbar = false;
            hWindow_Fit.i3DMaxvalue = 74000;
            hWindow_Fit.i3DMinvalue = -65000;

            //
            CHelper.UpdateProject = new CHelper.DlgUpdateProjectList(LoadProject);

        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(frm_Flow).ToString())
            {
                return m_frm_Flow;
            }
            else if (persistString == typeof(frm_ViewLog).ToString())
            {
                return m_frm_ViewLog;
            }
            else if (persistString == typeof(frm_AutoRun).ToString())
            {
                return m_frm_AutoRun;
            }
            return null;
        }
        /// <summary>
        /// 往heviewer插入he magical 20170823
        /// </summary>
        /// <param name="name"></param>
        /// <param name="he"></param>
        private void insertHe2HeViewer(string name, HImageExt he)
        {
            if (frm_HEViewer != null && !frm_HEViewer.IsDisposed)
                frm_HEViewer.insertHE(name, he);
        }

        #region 列表

        private void dgv_FlowList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow m_CurrentRow = dgv_FlowList.Rows[e.RowIndex];
                int CellID = int.Parse(m_CurrentRow.Cells[0].Value.ToString().Substring(1));
                IEnumerable<CMeasureCell> resultList = from UnitCell in HMeasureSYS.Cur_Project.m_CellList
                                                       where UnitCell.m_CellID == CellID
                                                       select UnitCell;
                CMeasureCell m_CurrentCell = resultList.ToList()[0];

                ShowUnitForm(ref m_CurrentCell);
                curListIndex = e.RowIndex;
            }

        }

        private void dgv_FlowList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FlowList.CurrentRow != null && dgv_FlowList.CurrentRow.Index >= 0)
                {
                    DataGridViewRow m_CurrentRow = dgv_FlowList.Rows[dgv_FlowList.CurrentRow.Index];
                    int CellID = int.Parse(m_CurrentRow.Cells[0].Value.ToString().Substring(1));
                    IEnumerable<CMeasureCell> resultList = from UnitCell in HMeasureSYS.Cur_Project.m_CellList
                                                           where UnitCell.m_CellID == CellID
                                                           select UnitCell;
                    CMeasureCell m_CurrentCell = resultList.ToList()[0];

                    UpdateWindow(m_CurrentCell);
                    curListIndex = dgv_FlowList.CurrentRow.Index;
                }
            }
            catch (System.Exception ex)
            {

            }

        }
        #endregion

        #region 单元工具

        /// <summary>
        /// 打开单元窗口
        /// </summary>
        /// <param name="m_CurrentCell"></param>
        private void ShowUnitForm(ref CMeasureCell m_MeasureCell)
        {
            if (m_frm_Unit == null || m_frm_Unit.IsDisposed)
            {
                switch (m_MeasureCell.m_CellCatagory)
                {
                    case CellCatagory.构造点:
                        m_frm_Unit = new frm_Unit_StructurePoint(ref m_MeasureCell);
                        break;
                    case CellCatagory.直线单元:
                        m_frm_Unit = new frm_Unit_MeasureLine(ref m_MeasureCell);
                        break;
                    case CellCatagory.圆单元:
                        m_frm_Unit = new frm_Unit_MeasureCircle(ref m_MeasureCell);
                        break;
                    case CellCatagory.椭圆单元:
                        m_frm_Unit = new frm_Unit_MeasureEllipse(ref m_MeasureCell);
                        break;
                    case CellCatagory.坐标系:
                        m_frm_Unit = new frm_Unit_Coordinate(ref m_MeasureCell);
                        break;
                    case CellCatagory.矩形阵列:
                        m_frm_Unit = new frm_Unit_RectArray(ref m_MeasureCell);
                        break;
                    case CellCatagory.面阵图像单元:
                        m_frm_Unit = new frm_Unit_ImageAreaReg(ref m_MeasureCell);
                        break;
                    case CellCatagory.线阵图像单元:
                        m_frm_Unit = new frm_Unit_ImageLineReg(ref m_MeasureCell);
                        break;
                    case CellCatagory.数据存储:
                        m_frm_Unit = new frm_Unit_DataSave(ref m_MeasureCell);
                        break;
                    case CellCatagory.数据计算:
                        m_frm_Unit = new frm_Unit_Calculate(ref m_MeasureCell);
                        break;
                    case CellCatagory.数值补偿和判定:
                        m_frm_Unit = new frm_Unit_DataCalculate(ref m_MeasureCell);
                        break;
                    case CellCatagory.位置补正:
                        m_frm_Unit = new frm_Unit_CorrectPosition(ref m_MeasureCell);
                        break;
                    case CellCatagory.畸变标定:
                        m_frm_Unit = new frm_Unit_DistortionCalib(ref m_MeasureCell);
                        break;
                    case CellCatagory.结果显示2:
                        m_frm_Unit = new frm_Unit_ResultView2(ref m_MeasureCell);
                        break;
                    case CellCatagory.串口通讯:
                        m_frm_Unit = new frm_Unit_SerialComm(ref m_MeasureCell);
                        break;
                    case CellCatagory.TCP_IP通讯:
                        m_frm_Unit = new frm_Unit_TcpSend(ref m_MeasureCell);
                        break;
                    case CellCatagory.相机机械坐标转换:
                        m_frm_Unit = new frm_Unit_CalibCoord(ref m_MeasureCell);
                        break;
                    case CellCatagory.显示单元:
                        m_frm_Unit = new frm_Unit_MeasureShow(ref m_MeasureCell);
                        break;
                    case CellCatagory.旋转中心标定:
                        m_frm_Unit = new frm_Unit_RoteCenterCalib(ref m_MeasureCell);
                        break;
                    case CellCatagory.延时单元:
                        m_frm_Unit = new frm_Unit_Delay(ref m_MeasureCell);
                        break;
                    case CellCatagory.Halcon引擎:
                        m_frm_Unit = new frm_Unit_HalconEngine(ref m_MeasureCell);
                        break;
                    default:
                        break;
                }
                m_frm_Unit.Show(this);

            }
            else
                m_frm_Unit.Activate();
        }
        /// <summary>
        /// 打开单元窗口
        /// </summary>
        private void ShowUnitForm(CellCatagory _Catagory)
        {
            if (m_frm_Unit == null || m_frm_Unit.IsDisposed)
            {
                curListIndex = -1;
                switch (_Catagory)
                {
                    case CellCatagory.构造点:
                        m_frm_Unit = new frm_Unit_StructurePoint();
                        break;
                    case CellCatagory.直线单元:
                        m_frm_Unit = new frm_Unit_MeasureLine();
                        break;
                    case CellCatagory.圆单元:
                        m_frm_Unit = new frm_Unit_MeasureCircle();
                        break;
                    case CellCatagory.椭圆单元:
                        m_frm_Unit = new frm_Unit_MeasureEllipse();
                        break;
                    case CellCatagory.坐标系:
                        m_frm_Unit = new frm_Unit_Coordinate();
                        break;
                    case CellCatagory.矩形阵列:
                        m_frm_Unit = new frm_Unit_RectArray();
                        break;
                    case CellCatagory.面阵图像单元:
                        m_frm_Unit = new frm_Unit_ImageAreaReg();
                        break;
                    case CellCatagory.线阵图像单元:
                        m_frm_Unit = new frm_Unit_ImageLineReg();
                        break;
                    case CellCatagory.数据存储:
                        m_frm_Unit = new frm_Unit_DataSave();
                        break;
                    case CellCatagory.数据计算:
                        m_frm_Unit = new frm_Unit_Calculate();
                        break;
                    case CellCatagory.数值补偿和判定:
                        m_frm_Unit = new frm_Unit_DataCalculate();
                        break;
                    case CellCatagory.位置补正:
                        m_frm_Unit = new frm_Unit_CorrectPosition();
                        break;
                    case CellCatagory.畸变标定:
                        m_frm_Unit = new frm_Unit_DistortionCalib();
                        break;
                    case CellCatagory.结果显示2:
                        m_frm_Unit = new frm_Unit_ResultView2();
                        break;
                    case CellCatagory.串口通讯:
                        m_frm_Unit = new frm_Unit_SerialComm();
                        break;
                    case CellCatagory.TCP_IP通讯:
                        m_frm_Unit = new frm_Unit_TcpSend();
                        break;
                    case CellCatagory.相机机械坐标转换:
                        m_frm_Unit = new frm_Unit_CalibCoord();
                        break;
                    case CellCatagory.显示单元:
                        m_frm_Unit = new frm_Unit_MeasureShow();
                        break;
                    case CellCatagory.旋转中心标定:
                        m_frm_Unit = new frm_Unit_RoteCenterCalib();
                        break;
                    case CellCatagory.延时单元:
                        m_frm_Unit = new frm_Unit_Delay();
                        break;
                    case CellCatagory.Halcon引擎:
                        m_frm_Unit = new frm_Unit_HalconEngine();
                        break;
                    default:
                        break;
                }
                m_frm_Unit.Show(this);
                UpdateFlowList();
                curListIndex = dgv_FlowList.Rows.Count - 1;
                this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[curListIndex].Cells[0];
            }
            else
                m_frm_Unit.Activate();
        }

        private void tStripMenu_ImageUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.面阵图像单元);
        }

        private void tStripMenu_LineImageUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.线阵图像单元);
        }

        private void tStripMenu_PointUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.构造点);
        }
        private void tStripMenu_LineUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.直线单元);
        }

        private void tStripMenu_CircleUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.圆单元);
        }

        private void tStripMenu_EllipseUnit_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.椭圆单元);
        }


        private void tStripMenu_Coordinate_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.坐标系);
        }

        private void tStripMenu_RectArray_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.矩形阵列);
        }

        private void tStripMenu_SaveData_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.数据存储);
        }

        private void tStripMenu_Calculate_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.数据计算);
        }

        private void tStripMenu_DataCalculate_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.数值补偿和判定);
        }

        private void tStripMenu_CorrectPosition_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.位置补正);
        }
        private void tStripMenu_DistortionCalib_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.畸变标定);
        }

        private void tStripMenu_CalibCoord_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.相机机械坐标转换);
        }

        private void tStripMenu_CalibRoteCenter_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.旋转中心标定);

        }
        private void tStripMenu_ResultView_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.结果显示);
        }

        private void tStripMenu_ResultView2_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.结果显示2);
        }

        private void tStripMenu_SerialComm_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.串口通讯);
        }
        private void tStripMenu_TCP_IP_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.TCP_IP通讯);
        }

        private void dgv_FlowList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(this.dgv_FlowList.RowHeadersDefaultCellStyle.ForeColor);
            int num = e.RowIndex + 1;
            e.Graphics.DrawString(num.ToString(CultureInfo.CurrentUICulture), this.dgv_FlowList.DefaultCellStyle.Font, brush, (float)(e.RowBounds.Location.X + 16), (float)(e.RowBounds.Location.Y + 4));
        }

        #endregion

        #region 文件
        private void tStripMenu_SaveSetting_Click(object sender, EventArgs e)
        {
            CProgress process = new CProgress();
            HMeasureSYS.SaveConfig(HMeasureSYS.sConfigPath);
            process.SetProgressValue(100, this);
        }


        #endregion
        /// <summary>
        /// 单步运行
        /// </summary>
        private void tStripBt_Step_Click(object sender, EventArgs e)
        {
            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.单步运行;
        }
        /// <summary>
        /// 执行一次
        /// </summary>
        private void tStripBt_Once_Click(object sender, EventArgs e)
        {
            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.执行一次;
            HMeasureSYS.Cur_Project.Thread_Start();
        }
        /// <summary>
        /// 循环执行
        /// </summary>
        private void tStripBt_Loop_Click(object sender, EventArgs e)
        {
            if (HMeasureSYS.Cur_Project.m_Status)
            {
                int index = HMeasureSYS.g_ProjectList.FindIndex(c => c.m_ProjectID == HMeasureSYS.Cur_Project.m_ProjectID);
                HMeasureSYS.Sys_Stop(index);
                tStripBt_Loop.Image = Properties.Resources.ic_run;
                tStripBt_Loop.Text = "循环当前项目";
            }
            else
            {
                HMeasureSYS.g_SysStatus.m_RunMode = RunMode.循环运行;
                HMeasureSYS.Cur_Project.Thread_Start();
                tStripBt_Loop.Image = Properties.Resources.ic_stop;
                tStripBt_Loop.Text = "停止当前项目";

            }
        }
        /// <summary>
        /// 停止所有
        /// </summary>
        private void tStripBt_Stop_Click(object sender, EventArgs e)
        {
            HMeasureSYS.Sys_Stop();
            tStripBt_Loop.Image = Properties.Resources.ic_run;
            tStripBt_Loop.Text = "循环当前项目";
        }

        private void tStripBt_Variable_Click(object sender, EventArgs e)
        {
            if (m_frm_VariableSetting == null || m_frm_VariableSetting.IsDisposed)
            {
                m_frm_VariableSetting = new frm_VariableSetting();
                m_frm_VariableSetting.Show(this);
            }
            else
            {
                m_frm_VariableSetting.Activate();
            }
        }

        private void tStripBt_Acquipment_Click(object sender, EventArgs e)
        {
            if (m_frm_Acquipment == null || m_frm_Acquipment.IsDisposed)
            {
                m_frm_Acquipment = new frm_Acquipment();
                m_frm_Acquipment.Show(this);
            }
            else
            {
                m_frm_Acquipment.Activate();
            }
        }

        private void tStripBt_ResultView_Click(object sender, EventArgs e)
        {
            if (m_frm_ResultView == null || m_frm_ResultView.IsDisposed)
            {
                m_frm_ResultView = new frm_ResultView2();
                m_frm_ResultView.Show(this);
            }
            else
                m_frm_ResultView.Activate();
        }

        private void tStripBt_TCPserver_Click(object sender, EventArgs e)
        {

            if (m_frm_TCP_IP_Server == null || m_frm_TCP_IP_Server.IsDisposed)
            {
                m_frm_TCP_IP_Server = new frm_TCP_IP_Server(ref HMeasureSYS.g_TcpServer);
                m_frm_TCP_IP_Server.Show(this);
            }
            else
                m_frm_TCP_IP_Server.Activate();
        }


        private void tStripBt_Project_Click(object sender, EventArgs e)
        {
            if (m_frm_ProjectList == null || m_frm_ProjectList.IsDisposed)
            {
                m_frm_ProjectList = new frm_ProjectList();
                m_frm_ProjectList.ShowDialog(this);
            }
            else
                m_frm_ProjectList.Activate();
        }

        private void tStripBt_RegImg_Click(object sender, EventArgs e)
        {
            frm_RegImg frmRegImg = new frm_RegImg();
            frmRegImg.ShowDialog(this);
        }


        private void frm_Main_Load(object sender, EventArgs e)
        {

            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");


            if (File.Exists(configFile))
            {
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            }

            frm_Main.thisHandle = this;
            CProgress m_Progress = new CProgress();
            //只有在没有外界加载的情况下才加载exe目录下配置
            if (HMeasureSYS.g_ProjectList.Count == 0)
            {
                HMeasureSYS.InitialVisionProgram();
            }

            if (HMeasureSYS.g_ProjectList.Count == 0)
            {
                HMeasureSYS.Cur_Project = new CProject();
                HMeasureSYS.g_ProjectList.Add(HMeasureSYS.Cur_Project);
                //    Directory.CreateDirectory(Application.StartupPath + "\\VisionConfig\\" + HMeasureSYS.Cur_Project.m_ProjectName);
                //  Directory.CreateDirectory(Application.StartupPath + "\\VisionConfig\\" + HMeasureSYS.Cur_Project.m_ProjectName + "\\RegisterIMG");
            }
            else if (HMeasureSYS.Cur_Project == null)
            {
                HMeasureSYS.Cur_Project = HMeasureSYS.g_ProjectList[0];
            }
            LoadProject(HMeasureSYS.Cur_Project);
            m_Progress.SetProgressValue(100, this);
            timer1.Start();
        }


        public void LoadProject(CProject p)
        {
            try
            {
                this.Invoke(new Action(delegate
              {
                  HMeasureSYS.Cur_Project = p;
                  //toolStrip_ProjectName.Text = "当前工程: " + HMeasureSYS.sConfigPath + "." + HMeasureSYS.Cur_Project.m_ProjectName;
                  toolStrip_ProjectName.Text = "当前工程: " + HMeasureSYS.Cur_Project.m_ProjectName;

                  tStripCmb_ImgType.Text = p.ImgCatagory.ToString();
                  UpdateFlowList();
              }));
            }
            catch (Exception ex)
            { }
        }


        public void UpdateFlowList(int rowid = 0)//直接绑定list效率或许更高
        {
            dgv_FlowList.SelectionChanged -= dgv_FlowList_SelectionChanged;
            m_dtFlowList.Clear();
            foreach (CMeasureCell unitCell in HMeasureSYS.Cur_Project.m_CellList)
            {
                string UnitID = "U" + unitCell.m_CellID.ToString("D4");
                m_dtFlowList.Rows.Add(new object[] { UnitID, unitCell.m_CellCatagory, unitCell.m_CellDesCribe });
            }
            dgv_FlowList.DataSource = m_dtFlowList;
            foreach (CMeasureCell unitCell in HMeasureSYS.Cur_Project.m_CellList)
            {
                if (unitCell.blnShield)
                    CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, unitCell.m_CellID, -1);//如果执行成功为数字 1；否则，为 0,屏蔽-1。
            }
            //dgv_FlowList.DataSource = new BindingList<CMeasureCell>(HMeasureSYS.g_CellList);
            if (dgv_FlowList.RowCount > 0)
            {
                if (curListIndex <= 0)
                    this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[this.dgv_FlowList.Rows.Count - 1].Cells[0];
                else if (curListIndex >= dgv_FlowList.RowCount)
                    this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[dgv_FlowList.RowCount - 1].Cells[0];
                else
                    this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[curListIndex].Cells[0];
            }
            dgv_FlowList.SelectionChanged += dgv_FlowList_SelectionChanged;
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="image">重绘的图片</param>
        public void RePaint(HImage image)
        {
            if (image.IsInitialized())
            {
                //int current_beginRow, current_beginCol, current_endRow, current_endCol;
                //hWindow_Fit.HWindowID.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
                //hWindow_Fit.Image = image;
                //hWindow_Fit.HWindowID.SetPart(current_beginRow, current_beginCol, current_endRow, current_endCol);
                //hWindow_Fit.HWindowID.DispObj(image);
                hWindow_Fit.Image = image;
            }
        }
        /// <summary>
        /// 单击单元时更新窗口 显示当前图片和检测内容
        /// </summary>
        /// <param name="cell"></param>
        public void UpdateWindow(CMeasureCell cell)
        {
            //if (cell.blnShield)
            //return;

            if (cell.m_Image != null && cell.m_Image.IsInitialized())
            {
                List<MeasureROI> roiList = cell.m_Image.measureROIlist.Where(c => c.CellID == cell.m_CellID.ToString()).ToList();

                hWindow_Fit.Image = cell.m_Image;
                foreach (MeasureROI roi in roiList)
                {
                    if (roi != null && roi.roiType == enMeasureROIType.文字显示.ToString())
                    {
                        MeasureROIText roiText = (MeasureROIText)roi;
                        HalconControl.CHelper.set_display_font(hWindow_Fit.HWindowID, roiText.size, roiText.font, "false", "false");
                        HalconControl.CHelper.disp_message(hWindow_Fit.HWindowID, roiText.text, "image", roiText.row, roiText.col, roiText.drawColor, "false");
                    }
                    else
                    {
                        if (roi != null && roi.hobject.IsInitialized())
                        {
                            hWindow_Fit.HWindowID.SetColor(roi.drawColor);
                            hWindow_Fit.HWindowID.DispObj(roi.hobject);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建流程列表
        /// </summary>
        /// <returns></returns>
        private DataTable FlowListDT()
        {
            DataTable dt_flow = new DataTable();
            dt_flow.Columns.Add("UnitID", Type.GetType("System.String"));//唯一流程标识
            dt_flow.Columns.Add("UnitCatagory", Type.GetType("System.String"));//单元名称 eg：line
            dt_flow.Columns.Add("UnitRemark", Type.GetType("System.String"));//

            return dt_flow;
        }

        private void InitMenuStrip()
        {
            ToolStripMenuItem strip_ShiftUp = new ToolStripMenuItem("上移");
            strip_ShiftUp.Click += new EventHandler((s, e) => OnStrip_ShiftUp(s, e));

            ToolStripMenuItem strip_ShiftDown = new ToolStripMenuItem("下移");
            strip_ShiftDown.Click += new EventHandler((s, e) => OnStrip_ShiftDown(s, e));

            ToolStripMenuItem strip_Cut = new ToolStripMenuItem("剪切");
            strip_Cut.Click += new EventHandler((s, e) => OnStrip_Cut(s, e));

            ToolStripMenuItem strip_Insert = new ToolStripMenuItem("插入");
            strip_Insert.Click += new EventHandler((s, e) => OnStrip_Insert(s, e));

            ToolStripMenuItem strip_RemoveAt = new ToolStripMenuItem("删除项");
            strip_RemoveAt.Click += new EventHandler((s, e) => OnStrip_RemoveAt(s, e));

            ToolStripMenuItem strip_RemoveAll = new ToolStripMenuItem("删除所有");
            strip_RemoveAll.Click += new EventHandler((s, e) => OnStrip_RemoveAll(s, e));

            m_MenuStrip.Items.Add(strip_ShiftUp);
            m_MenuStrip.Items.Add(strip_ShiftDown);
            m_MenuStrip.Items.Add(strip_Cut);
            m_MenuStrip.Items.Add(strip_Insert);
            m_MenuStrip.Items.Add(strip_RemoveAt);
            m_MenuStrip.Items.Add(strip_RemoveAll);
            m_MenuStrip.Opening += new CancelEventHandler((s, e) => On_MenuStrip_Opening());

            dgv_FlowList.ContextMenuStrip = m_MenuStrip;
        }

        public void On_MenuStrip_Opening()
        {
            m_MenuStrip.Items[0].Enabled = true;
            m_MenuStrip.Items[1].Enabled = true;

            if (dgv_FlowList.SelectedRows.Count < 1)
            {
                m_MenuStrip.Enabled = false;
            }
            if (dgv_FlowList.SelectedRows.Count <= 0)
            {
                m_MenuStrip.Items[0].Enabled = false;
            }
            else if (dgv_FlowList.CurrentRow.Index == dgv_FlowList.Rows.Count - 1)
            {
                m_MenuStrip.Items[1].Enabled = false;
            }
            if (Cutindex == -1)
            {
                m_MenuStrip.Items[3].Enabled = false;
            }
            else
            {
                m_MenuStrip.Items[3].Enabled = true;

            }
        }

        private void OnStrip_ShiftUp(object sender, EventArgs e)
        {
            int CurrentIndex = dgv_FlowList.CurrentRow.Index;
            var temp = HMeasureSYS.Cur_Project.m_CellList[CurrentIndex];
            HMeasureSYS.Cur_Project.m_CellList[CurrentIndex] = HMeasureSYS.Cur_Project.m_CellList[CurrentIndex - 1];
            HMeasureSYS.Cur_Project.m_CellList[CurrentIndex - 1] = temp;
            UpdateFlowList();
            this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[CurrentIndex - 1].Cells[0];
        }

        private void OnStrip_ShiftDown(object sender, EventArgs e)
        {
            int CurrentIndex = dgv_FlowList.CurrentRow.Index;
            var temp = HMeasureSYS.Cur_Project.m_CellList[CurrentIndex];
            HMeasureSYS.Cur_Project.m_CellList[CurrentIndex] = HMeasureSYS.Cur_Project.m_CellList[CurrentIndex + 1];
            HMeasureSYS.Cur_Project.m_CellList[CurrentIndex + 1] = temp;
            UpdateFlowList();
            this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[CurrentIndex + 1].Cells[0];

        }

        private void OnStrip_Cut(object sender, EventArgs e)
        {
            Cutindex = dgv_FlowList.CurrentRow.Index;
        }

        private void OnStrip_Insert(object sender, EventArgs e)
        {
            int InsertIndex = dgv_FlowList.CurrentRow.Index;
            var temp = HMeasureSYS.Cur_Project.m_CellList[Cutindex];
            if (InsertIndex <= Cutindex)
            {
                HMeasureSYS.Cur_Project.m_CellList.RemoveAt(Cutindex);
                HMeasureSYS.Cur_Project.m_CellList.Insert(InsertIndex, temp);
            }
            else
            {
                HMeasureSYS.Cur_Project.m_CellList.Insert(InsertIndex, temp);
                HMeasureSYS.Cur_Project.m_CellList.RemoveAt(Cutindex);
            }
            UpdateFlowList();
            this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[InsertIndex <= Cutindex ? InsertIndex : Cutindex].Cells[0];
            Cutindex = -1;
        }

        private void OnStrip_RemoveAt(object sender, EventArgs e)
        {
            int CurrentIndex = dgv_FlowList.CurrentRow.Index;
            var cell = HMeasureSYS.Cur_Project.m_CellList[CurrentIndex];
            //if (cell.m_CellCatagory==CellCatagory.位置补正)
            //{
            //    File.Delete(((CCorrect_Position)cell).m_ModelPath + "_model.hobj");//删除当前文件
            //    File.Delete(((CCorrect_Position)cell).m_ModelPath + "_search.hobj");
            //    File.Delete(((CCorrect_Position)cell).m_ModelPath + ".shm");
            //    File.Delete(((CCorrect_Position)cell).m_ModelPath + ".ncm");
            //}
            HMeasureSYS.Cur_Project.m_CellList.RemoveAt(CurrentIndex);
            var list = HMeasureSYS.Cur_Project.m_VariableList.RemoveAll(c => c.m_Data_CellID == cell.m_CellID);
            UpdateFlowList();
            if (CurrentIndex > 0)
            {
                this.dgv_FlowList.CurrentCell = this.dgv_FlowList.Rows[CurrentIndex - 1].Cells[0];
            }
        }

        private void OnStrip_RemoveAll(object sender, EventArgs e)
        {
            HMeasureSYS.Cur_Project.m_CellList.Clear();
            HMeasureSYS.Cur_Project.m_VariableList.RemoveAll(c => c.m_Data_CellID != HMeasureSYS.U000);
            //DirectoryInfo di = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory+"Setting\\");
            //foreach (FileInfo fi in di.GetFiles())
            //{
            //    string ext = Path.GetExtension(fi.Name);
            //    //判断当前文件后缀名是否与给定后缀名一样
            //    if (ext == ".hobj" || ext == ".shm"||ext==".ncm")
            //    {
            //        File.Delete(fi.FullName);//删除当前文件
            //    }
            //}
            UpdateFlowList();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            CHelper.g_MainWnd = this.Handle;
        }
        private void tStripBt_Log_Click(object sender, EventArgs e)
        {
            if (m_frm_ViewLog == null || m_frm_ViewLog.IsDisposed)
            {
                m_frm_ViewLog = new frm_ViewLog();
                m_frm_ViewLog.Show(this);
            }
            else
                m_frm_ViewLog.Activate();
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case CHelper.MAIN_MESSAGE:
                    {
                        switch (m.WParam.ToInt32())
                        {
                            case -1://-1表示开始或结束一个单元
                                if (m.LParam.ToInt32() == 0)
                                {
                                    sw.Reset();
                                    sw.Start();
                                }
                                else if (m.LParam.ToInt32() == 1)
                                {
                                    tlLable.Text = "耗时 " + (sw.ElapsedMilliseconds * 1.0 / 1000).ToString("#0.000") + " 秒";
                                }

                                break;
                            default:
                                int curCellID = m.WParam.ToInt32();
                                int idx = HMeasureSYS.Cur_Project.m_CellList.FindIndex(c => c.m_CellID == curCellID);
                                if (idx < 0)
                                    return;
                                int status = m.LParam.ToInt32();
                                if (status == -1)//屏蔽单元
                                {
                                    dgv_FlowList.Rows[idx].DefaultCellStyle.BackColor = Color.LightGray;
                                    break;
                                }
                                else if (status == 0)//检测失败单元
                                    dgv_FlowList.Rows[idx].DefaultCellStyle.BackColor = Color.LightPink;
                                else if (status == 1)//检测成功单元
                                    dgv_FlowList.Rows[idx].DefaultCellStyle.BackColor = Color.LightGreen;
                                else if (status == -2)//正在检测单元
                                    dgv_FlowList.Rows[idx].DefaultCellStyle.BackColor = Color.Blue;
                                tStripTxt_CurrentUnit.Text = curCellID.ToString();
                                break;
                        }
                    }
                    break;
                default:
                    base.DefWndProc(ref m);//一定要调用基类函数，以便系统处理其它消息。
                    break;
            }

        }

        private void tStripMenu_Exit_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Close();
        }

        bool checkREgister = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                if (checkREgister == false)
                {
                    checkREgister = true;
                    if (RegisterHelper.Instance.TryRegisteredDll() == false)
                    {
                        frmRegistered frm = new frmRegistered();
                        frm.ShowDialog();
                    }
                }

                tStripBt_Step.Enabled = !HMeasureSYS.Cur_Project.m_Status;
                tStripBt_Once.Enabled = !HMeasureSYS.Cur_Project.m_Status;
                //tStripBt_Loop.Enabled = HMeasureSYS.Cur_Project.m_Status;
                tStripBt_Stop.Enabled = HMeasureSYS.Cur_Project.m_Status;
                //dgv_FlowList.Enabled = !HMeasureSYS.Cur_Project.m_Status;
                if (HMeasureSYS.Cur_Project.m_Status)
                    tStripBt_Loop.Image = Properties.Resources.ic_stop;
                else
                    tStripBt_Loop.Image = Properties.Resources.ic_run;
                if (frm_HEViewer == null || frm_HEViewer.IsDisposed)
                {
                    CHelper.insertHe2HeViewer = null;
                }
                //bool isRegistered = Wrapper.Fun.GetRegistState();

                //if (isRegistered == false)
                //{
                //    StatusLabel_注册状态.Text = "视觉组件未注册";
                //    StatusLabel_注册状态.BackColor = Color.Red;
                //}
                //else
                //{
                //    StatusLabel_注册状态.Text = "视觉组件已注册";
                //    StatusLabel_注册状态.BackColor = Color.Green;
                //}
                timer1.Start();
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 打开效果图暂时窗口 magical 20170823
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStripBt_EffectView_Click(object sender, EventArgs e)
        {
            //原方法跨线程调用出错， edit by kelly
            //CHelper.frm_HEViewer.Show();
            if (frm_HEViewer == null || frm_HEViewer.IsDisposed)
            {
                CHelper.insertHe2HeViewer = new CHelper.DlgInsertHe(insertHe2HeViewer);
                frm_HEViewer = new Frm_HEViewer(true);
                frm_HEViewer.Show(this);
            }
            else
                frm_HEViewer.Activate();
        }

        private void tStripCmb_ImgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HMeasureSYS.Cur_Project.ImgCatagory = (ImageCatagory)tStripCmb_ImgType.SelectedIndex;
        }

        private void tStripMenu_MeasureShow_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.显示单元);
        }

        private void 项目另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string files;

            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                files = saveProjectFileDialog.FileName;
                HMeasureSYS.sConfigPath = files;
                CProgress process = new CProgress();
                HMeasureSYS.SaveConfig(files);
                process.SetProgressValue(100, this);
            }
        }

        private void 打开项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string files;
            if (openProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                CProgress process = new CProgress();
                files = openProjectFileDialog.FileName;
                Measure.HMeasureSYS.InitialVisionProgram(files);
                if (HMeasureSYS.g_ProjectList == null)
                {
                    HMeasureSYS.g_ProjectList = new List<CProject>();
                }
                if (HMeasureSYS.g_ProjectList.Count < 1)
                {
                    HMeasureSYS.g_ProjectList.Add(new CProject());
                }
                HMeasureSYS.Cur_Project = HMeasureSYS.g_ProjectList[0];

                LoadProject(HMeasureSYS.Cur_Project);

                process.SetProgressValue(100, this);

            }
        }

        private void 延时单元ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.延时单元);
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void tStripBt_Tool_Click(object sender, EventArgs e)
        {

        }

        private void halcon引擎ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowUnitForm(CellCatagory.Halcon引擎);
        }

        private void 流程窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frm_Flow.Show(dockPanel);
        }

        private void 运行日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frm_ViewLog.Show(dockPanel);
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("是否保存配置文件再退出？", "退出", MessageBoxButtons.YesNoCancel);
            CProgress m_Progress = new CProgress();
            if (result == DialogResult.Yes)
            {
                //HMeasureSYS.SaveProjectInfo(HMeasureSYS.Cur_Project);
                //HMeasureSYS.SaveSpaceInfo(HMeasureSYS.g_ProjectList, HMeasureSYS.g_VariableList, HMeasureSYS.g_AcqDeviceList, HMeasureSYS.g_TcpServer, Application.StartupPath + HMeasureSYS.sProject_Path);
                HMeasureSYS.SaveConfig(HMeasureSYS.sConfigPath);
                CHelper.g_MainWnd = IntPtr.Zero;
                HMeasureSYS.DisposeVisionProgram();
            }
            else if (result == DialogResult.No)
            {
                CHelper.g_MainWnd = IntPtr.Zero;
                HMeasureSYS.DisposeVisionProgram();
            }
            else
            {
                e.Cancel = true;
            }
            m_Progress.SetProgressValue(100, this);
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            dockPanel.SaveAsXml(configFile);
            //HMeasureSYS.DisposeVisionProgram();
        }

        private void 自动运行窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frm_AutoRun.Show(dockPanel);
        }
    }
}
