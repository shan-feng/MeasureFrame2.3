using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AcqDevice;
using Measure;
using System.Runtime.InteropServices;
using MVSDK;
using HalconDotNet;
using DVPCameraType;
using Ookii.Dialogs.WinForms;


namespace MeasureFrame.IUI
{
    public partial class frm_Acquipment : Form
    {
        private frm_CameraRateSet frmCameraRateSet;
        private ContextMenuStrip dgvMenu = new ContextMenuStrip();
        private List<CamInfo> _CamInfoList = new List<CamInfo>();
        private Form frm_AcqAttr;
        public frm_Acquipment()
        {
            InitializeComponent();
        }

        private void frm_Acquipment_Load(object sender, EventArgs e)
        {
            InitCmbDeviceType();
            InitdgvMenu();
            dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
            ///初始化文本框
            cmb_DeviceType.Tag = "1";
            if (dgv_DeviceList.SelectedRows.Count > 0)
            {
                int Index = dgv_DeviceList.SelectedRows[0].Cells[0].RowIndex;
                AcqDeviceBase m_AcqDevice = HMeasureSYS.g_AcqDeviceList[Index];
                bt_Connect.Enabled = !m_AcqDevice.m_bConnected;
                bt_Disconnect.Enabled = m_AcqDevice.m_bConnected;
            }
        }

        private void cmb_DeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_DeviceType.Tag == null)
                return;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            switch ((DeviceType)Enum.Parse(typeof(DeviceType), cmb_DeviceType.Text))
            {
                case AcqDevice.DeviceType.文件夹_面阵:
                    //fd.RootFolder = Environment.SpecialFolder.MyDocuments;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        bool exist = HMeasureSYS.g_AcqDeviceList.Exists(c => c.m_SerialNo == fd.SelectedPath);
                        if (!exist)
                        {
                            AcqDevice.AcqFolder_Area.SearchCameras(fd.SelectedPath, out _CamInfoList);
                        }
                    }
                    break;
                case AcqDevice.DeviceType.文件夹_线扫:
                    //fd.RootFolder = Environment.SpecialFolder.MyDocuments;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        bool exist = HMeasureSYS.g_AcqDeviceList.Exists(c => c.m_SerialNo == fd.SelectedPath);
                        if (!exist)
                        {
                            AcqDevice.AcqFolder_Line.SearchCameras(fd.SelectedPath, out _CamInfoList);
                        }
                    }
                    break;
                case AcqDevice.DeviceType.SVS_hr16050:
                    AcqDevice.AcqSVS_hr.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.IDS_uEye:
                    AcqDevice.AcqIDS_uEye.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.KEYENCE_LINELASER:
                    cmb_DeviceName.Text = "192.168.1.100:24691";
                    return;
                case AcqDevice.DeviceType.MEYI_LINELASER:
                    AcqDevice.AcqMeLaser.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.Wenglor_LINELASER:
                    AcqDevice.AcqWenglorLaser.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.MindVision:
                    AcqDevice.AcqMindVision.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.Do3Think:
                    AcqDevice.AcqDo3Think.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.Basler:
                    AcqDevice.AcqBasler.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.Imaging:
                    AcqDevice.AcqImaging.SearchCameras(out _CamInfoList);
                    break;
                case AcqDevice.DeviceType.HKVision:
                    AcqDevice.AcqHKVision.SearchCameras(out _CamInfoList);
                    break;
            }
            cmb_DeviceName.DataSource = _CamInfoList;
            cmb_DeviceName.DisplayMember = "m_UniqueName";
        }

        private void bt_Add2List_Click(object sender, EventArgs e)
        {
            AcqDeviceBase m_AcqDevice;
            if ((DeviceType)Enum.Parse(typeof(DeviceType), cmb_DeviceType.Text) == AcqDevice.DeviceType.KEYENCE_LINELASER)
            {
                m_AcqDevice = new AcqKeyenceLaser(AcqDevice.DeviceType.KEYENCE_LINELASER);
                m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
            }
            else
            {

                if (cmb_DeviceName.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择设备！");
                    return;
                }
                int index = HMeasureSYS.g_AcqDeviceList.FindIndex(c => c.m_SerialNo == _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO);
                if (index >= 0)
                {
                    MessageBox.Show("该设备已经添加列表");
                    return;
                }
                switch ((DeviceType)Enum.Parse(typeof(DeviceType), cmb_DeviceType.Text))
                {
                    case AcqDevice.DeviceType.文件夹_面阵:
                        if (cmb_DeviceName.SelectedIndex >= 0)
                        {
                            m_AcqDevice = new AcqFolder_Area(AcqDevice.DeviceType.文件夹_面阵);
                            m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                            HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        }
                        break;
                    case AcqDevice.DeviceType.文件夹_线扫:
                        if (cmb_DeviceName.SelectedIndex >= 0)
                        {
                            m_AcqDevice = new AcqFolder_Line(AcqDevice.DeviceType.文件夹_线扫);
                            m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                            HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        }
                        break;
                    case AcqDevice.DeviceType.SVS_hr16050:
                        m_AcqDevice = new AcqSVS_hr(AcqDevice.DeviceType.SVS_hr16050);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.IDS_uEye:
                        m_AcqDevice = new AcqIDS_uEye(AcqDevice.DeviceType.IDS_uEye);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.KEYENCE_LINELASER:
                        m_AcqDevice = new AcqKeyenceLaser(AcqDevice.DeviceType.KEYENCE_LINELASER);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        //m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        //m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.MEYI_LINELASER:
                        m_AcqDevice = new AcqMeLaser(AcqDevice.DeviceType.MEYI_LINELASER);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.Wenglor_LINELASER:
                        m_AcqDevice = new AcqWenglorLaser(AcqDevice.DeviceType.Wenglor_LINELASER);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.MindVision:
                        m_AcqDevice = new AcqMindVision(AcqDevice.DeviceType.MindVision);
                        m_AcqDevice.m_UniqueLabel = cmb_DeviceName.Text.Trim();
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        ((AcqMindVision)m_AcqDevice).m_DevInfo = (tSdkCameraDevInfo)_CamInfoList[cmb_DeviceName.SelectedIndex].mExtInfo;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.Do3Think:
                        m_AcqDevice = new AcqDo3Think(AcqDevice.DeviceType.Do3Think);
                        m_AcqDevice.m_UniqueLabel = _CamInfoList[cmb_DeviceName.SelectedIndex].m_UniqueName;
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.Basler:
                        m_AcqDevice = new AcqBasler(AcqDevice.DeviceType.Basler);
                        m_AcqDevice.m_UniqueLabel = _CamInfoList[cmb_DeviceName.SelectedIndex].m_UniqueName;
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.Imaging:
                        m_AcqDevice = new AcqImaging(AcqDevice.DeviceType.Imaging);
                        m_AcqDevice.m_UniqueLabel = _CamInfoList[cmb_DeviceName.SelectedIndex].m_UniqueName;
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        ((AcqImaging)m_AcqDevice).extInfo = _CamInfoList[cmb_DeviceName.SelectedIndex].mExtInfo;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                    case AcqDevice.DeviceType.HKVision:
                        m_AcqDevice = new AcqHKVision(AcqDevice.DeviceType.HKVision);
                        m_AcqDevice.m_UniqueLabel = _CamInfoList[cmb_DeviceName.SelectedIndex].m_UniqueName;
                        m_AcqDevice.m_DevDirExt = _CamInfoList[cmb_DeviceName.SelectedIndex].m_MaskName;
                        m_AcqDevice.m_SerialNo = _CamInfoList[cmb_DeviceName.SelectedIndex].m_SerialNO;
                        ((AcqHKVision)m_AcqDevice).extInfo = _CamInfoList[cmb_DeviceName.SelectedIndex].mExtInfo;
                        HMeasureSYS.g_AcqDeviceList.Add(m_AcqDevice);
                        break;
                }
            }
            dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
        }


        private void InitCmbDeviceType()
        {
            List<string> listName = new List<string>();
            foreach (string s in Enum.GetNames(typeof(DeviceType)))
            {
                listName.Add(s);
            }
            cmb_DeviceType.DataSource = listName;
        }

        private void InitdgvMenu()
        {
            ToolStripMenuItem ItemRateSet = new ToolStripMenuItem("像素当量设置");
            ItemRateSet.Click += new EventHandler((s, e) => ItemRateSet_Click(s, e));
            dgvMenu.Items.Add(ItemRateSet);

            ToolStripMenuItem ItemParamOut = new ToolStripMenuItem("导出参数设置");
            ItemParamOut.Click += new EventHandler((s, e) => ItemParamOut_Click(s, e));
            dgvMenu.Items.Add(ItemParamOut);

            ToolStripMenuItem ItemParamIn = new ToolStripMenuItem("导入参数设置");
            ItemParamIn.Click += new EventHandler((s, e) => ItemParamIn_Click(s, e));
            dgvMenu.Items.Add(ItemParamIn);

            dgv_DeviceList.ContextMenuStrip = dgvMenu;
        }

        private void ItemRateSet_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.Rows.Count > 0)
            {
                int index = dgv_DeviceList.SelectedRows[0].Index;
                AcqDeviceBase acq = HMeasureSYS.g_AcqDeviceList[index];
                if (frmCameraRateSet == null || frmCameraRateSet.IsDisposed)
                {
                    frmCameraRateSet = new frm_CameraRateSet(acq);
                    //frmCameraRateSet.setValue = new Action<double, double>(setVale);
                    if (DialogResult.OK == frmCameraRateSet.ShowDialog(this))
                    {
                        dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                        dgv_DeviceList.Rows[index].Selected = true;
                    }
                    frmCameraRateSet.Dispose();
                }
                else
                    frmCameraRateSet.Activate();
            }

        }

        private void ItemParamOut_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.Rows.Count > 0)
            {
                int index = dgv_DeviceList.SelectedRows[0].Index;
                AcqDeviceBase acq = HMeasureSYS.g_AcqDeviceList[index];
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = Application.StartupPath + @"\" + "CameraConfig" + acq.m_SerialNo;
                sfd.Filter = "所有文件|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    acq.SaveSetting(sfd.FileName);
                }
            }

        }

        private void ItemParamIn_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.Rows.Count > 0)
            {
                int index = dgv_DeviceList.SelectedRows[0].Index;
                AcqDeviceBase acq = HMeasureSYS.g_AcqDeviceList[index];
                OpenFileDialog fD = new OpenFileDialog();
                fD.Filter = "所有文件|*.*";
                fD.FileName =Application.StartupPath+ "/CameraConfig" + acq.m_SerialNo;
                if (fD.ShowDialog() == DialogResult.OK)
                {
                    acq.LoadSetting(fD.FileName);
                }

            }
        }

        private void bt_DeleteAll_Click(object sender, EventArgs e)
        {
            HMeasureSYS.g_AcqDeviceList.Clear();
            dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
            AcqDeviceBase.m_LastDeviceID = 0;
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgv_DeviceList.SelectedRows[0];
                int index = r.Cells[0].RowIndex;
                if (HMeasureSYS.g_AcqDeviceList[index].m_bConnected)
                    return;
                HMeasureSYS.g_AcqDeviceList.RemoveAt(index);
                dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                if (index > 0)
                {
                    dgv_DeviceList.CurrentCell = dgv_DeviceList.Rows[index - 1].Cells[0];
                }
            }
        }

        private void bt_Disconnect_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.SelectedRows.Count > 0)
            {
                int Index = dgv_DeviceList.SelectedRows[0].Cells[0].RowIndex;
                AcqDeviceBase m_AcqDevice = HMeasureSYS.g_AcqDeviceList[Index];
                m_AcqDevice.DisConnectDev();
                dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                bt_Connect.Enabled = !m_AcqDevice.m_bConnected;
                bt_Disconnect.Enabled = m_AcqDevice.m_bConnected;
                dgv_DeviceList.Rows[Index].Selected = true;
            }

        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            if (dgv_DeviceList.SelectedRows.Count > 0)
            {
                int Index = dgv_DeviceList.SelectedRows[0].Cells[0].RowIndex;
                AcqDeviceBase m_AcqDevice = HMeasureSYS.g_AcqDeviceList[Index];
                m_AcqDevice.ConnectDev();
                dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                bt_Connect.Enabled = !m_AcqDevice.m_bConnected;
                bt_Disconnect.Enabled = m_AcqDevice.m_bConnected;
                dgv_DeviceList.Rows[Index].Selected = true;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_DeviceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AcqDeviceBase m_AcqDevice = HMeasureSYS.g_AcqDeviceList[e.RowIndex];
                //IntPtr intPtr = Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]);  
                ShowAttrForm(ref m_AcqDevice);
            }
        }

        /// <summary>
        /// 打开单元窗口
        /// </summary>
        private void ShowAttrForm(ref AcqDeviceBase _AcqDevice)
        {
            if (frm_AcqAttr == null || frm_AcqAttr.IsDisposed)
            {
                //FolderBrowserDialog fd = new FolderBrowserDialog();
                VistaFolderBrowserDialog fd = new VistaFolderBrowserDialog();
                switch (_AcqDevice.m_DeviceType)
                {
                    case AcqDevice.DeviceType.SVS_hr16050:
                        frm_AcqAttr = new frm_AcqSVS_hrAttr(ref _AcqDevice);
                        ((frm_AcqSVS_hrAttr)frm_AcqAttr).m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        break;
                    case AcqDevice.DeviceType.IDS_uEye:
                        frm_AcqAttr = new frm_AcqIDS_uEyeAttr(ref _AcqDevice);
                        ((frm_AcqIDS_uEyeAttr)frm_AcqAttr).m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        break;
                    case AcqDevice.DeviceType.文件夹_面阵:
                        if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            _AcqDevice.m_SerialNo = fd.SelectedPath;
                            _AcqDevice.m_bConnected = false;
                        }
                        dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                        return;
                    case AcqDevice.DeviceType.文件夹_线扫:
                        if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            _AcqDevice.m_SerialNo = fd.SelectedPath;
                            _AcqDevice.m_bConnected = false;
                        }
                        dgv_DeviceList.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList);
                        return;
                    case AcqDevice.DeviceType.KEYENCE_LINELASER:
                        return;
                    case AcqDevice.DeviceType.MEYI_LINELASER:
                        frm_AcqAttr = new frm_AcqMeLaser_Attr(ref _AcqDevice);
                        break;
                    case AcqDevice.DeviceType.Wenglor_LINELASER:
                        frm_AcqAttr = new frm_AcqWenglorLaser_Attr(ref _AcqDevice);
                        break;
                    case AcqDevice.DeviceType.MindVision:
                        frm_AcqMindWision temp = new frm_AcqMindWision(ref _AcqDevice);
                        temp.m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        temp.ShowAttr(this.Owner.Handle);
                        return;
                    case AcqDevice.DeviceType.Do3Think:
                        frm_AcqDo3Think tAcqDo3Think = new frm_AcqDo3Think(ref _AcqDevice);
                        tAcqDo3Think.m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        tAcqDo3Think.ShowAttr(this.Handle);
                        return;
                    case AcqDevice.DeviceType.Basler:
                        frm_AcqAttr = new Frm_AcqBasler_Attr(ref _AcqDevice);
                        ((Frm_AcqBasler_Attr)frm_AcqAttr).m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        break;
                    case AcqDevice.DeviceType.Imaging:
                        frm_AcqImaging tAcqImaging = new frm_AcqImaging(ref _AcqDevice);
                        tAcqImaging.m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        tAcqImaging.ShowAttr(this.Handle);
                        return;
                    case AcqDevice.DeviceType.HKVision:
                        frm_AcqAttr = new frm_AcqHKVision(ref _AcqDevice);
                        ((frm_AcqHKVision)frm_AcqAttr).m_HWindow = frm_Main.thisHandle.hWindow_Fit;
                        break;
                }
                frm_AcqAttr.Show(this);
            }
            else
                frm_AcqAttr.Activate();
        }

        private void dgv_DeviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AcqDeviceBase m_AcqDevice = HMeasureSYS.g_AcqDeviceList[e.RowIndex];
                if (m_AcqDevice.m_bConnected)
                {
                    bt_Connect.Enabled = false;
                    bt_Disconnect.Enabled = true;
                }
                else
                {
                    bt_Connect.Enabled = true;
                    bt_Disconnect.Enabled = false;
                }
            }
        }
    }
}
