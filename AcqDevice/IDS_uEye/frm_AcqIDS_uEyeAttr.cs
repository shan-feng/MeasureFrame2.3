using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace AcqDevice
{
    public partial class frm_AcqIDS_uEyeAttr : Form
    {
        AcqIDS_uEye m_AcqIDS_uEye;
        private uEye.Camera m_Camera;
        private FormatControl m_FormatControl;
        private SizeControl m_SizeControl;

        IControl m_ActiveControl = null;
        private HalconControl.HWindow_Fit hWindow = null;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqIDS_uEye.dispImgCallback = dispImage;
                }
            }
        }

        public frm_AcqIDS_uEyeAttr(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();

            m_AcqIDS_uEye = (AcqIDS_uEye)_AcqDevice;
            m_Camera = m_AcqIDS_uEye.m_Camera;

            m_FormatControl = new FormatControl(m_Camera);
            m_SizeControl = new SizeControl(m_Camera);
        }


        ~frm_AcqIDS_uEyeAttr()
        {
            m_AcqIDS_uEye.dispImgCallback = null;
        }
        public FormatControl FormatControl
        {
            get
            {
                return m_FormatControl;
            }
        }

        public SizeControl SizeControl
        {
            get
            {
                return m_SizeControl;
            }
        }

        private void InitSettingsList()
        {
            ListViewControlItem item;

            item = new ListViewControlItem();
            item.Text = "Timing               ";
            item.Value = new CameraControl(m_Camera);
            item.ImageIndex = 0;

            listViewSettings.Items.Add(item);

            item = new ListViewControlItem();
            item.Text = "Picture                    ";
            item.Value = new PictureControl(m_Camera);
            item.ImageIndex = 1;
            listViewSettings.Items.Add(item);

            item = new ListViewControlItem();
            item.Text = "Size                     ";
            item.Value = m_SizeControl;
            item.ImageIndex = 2;
            listViewSettings.Items.Add(item);


            item = new ListViewControlItem();
            item.Text = "Format                         ";
            item.Value = m_FormatControl;
            item.ImageIndex = 3;
            listViewSettings.Items.Add(item);

            //添加Trigger Control
            item = new ListViewControlItem();
            item.Text = "Trigger                    ";
            item.Value = new TriggerControl(m_Camera);
            item.ImageIndex = 4;
            listViewSettings.Items.Add(item);


            listViewSettings.Items[0].Selected = true;
            listViewSettings.FullRowSelect = true;
            listViewSettings.HideSelection = false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            InitSettingsList();
        }

        private void listViewSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ActiveControl != null)
            {
                m_ActiveControl.OnControlFocusLost();
                m_ActiveControl = null;
            }

            if (listViewSettings.SelectedItems.Count != 0)
            {
                m_ActiveControl = (IControl)(listViewSettings.SelectedItems[0] as ListViewControlItem).Value;

                if (m_ActiveControl != null)
                {
                    //splitContainerMain.Panel2.Controls.Clear();
                    //splitContainerMain.Panel2.Controls.Add(m_ActiveControl);
                    panel1.Controls.Clear();
                    panel1.Controls.Add(m_ActiveControl);

                    m_ActiveControl.Dock = DockStyle.Fill;

                    m_ActiveControl.OnControlFocusActive();
                }
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            m_Camera.Parameter.Save();
            //m_Camera.Parameter.Save(m_AcqIDS_uEye .m_SettingPath );
        }

        private void dispImage(HImage image, int user)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                hWindow.Image = image;
                //int width, height;
                //image.GetImageSize(out width, out height);
                //hWindow.SetPart(0, 0, height, width);
                //hWindow.HWindowID.DispImage(image);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //功能有问题
        private void tmi_LoadFile_Click(object sender, EventArgs e)
        {
            //m_Camera.Acquisition.Stop();

            m_Camera.Parameter.Load("");
            Int32[] memList;
            m_Camera.Memory.GetList(out memList);
            m_Camera.Memory.Free(memList);

            // allocate new standard memory
            m_Camera.Memory.Allocate();

            m_AcqIDS_uEye.SetTriggerMode();
        }

        private void tmi_LoadRAM_Click(object sender, EventArgs e)
        {
            m_Camera.Acquisition.Stop();

            Int32[] memList;
            m_Camera.Memory.GetList(out memList);
            m_Camera.Memory.Free(memList);

            m_Camera.Parameter.Load();
            // allocate new standard memory
            m_Camera.Memory.Allocate();

            m_AcqIDS_uEye.SetTriggerMode();
        }

        private void tmi_Save2File_Click(object sender, EventArgs e)
        {
            m_Camera.Parameter.Load("");
        }

        private void tmi_Save2RAM_Click(object sender, EventArgs e)
        {
            m_Camera.Parameter.Load();
        }
    }

    public class ListViewControlItem : ListViewItem
    {
        public object Value { get; set; }
    }

}
