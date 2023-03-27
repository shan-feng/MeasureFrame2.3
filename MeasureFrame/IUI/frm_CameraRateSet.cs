using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AcqDevice;

namespace MeasureFrame.IUI
{
    public partial class frm_CameraRateSet : Form
    {
        AcqDeviceBase acq;
        public frm_CameraRateSet(AcqDeviceBase _acq)
        {
            InitializeComponent();
            acq = _acq;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            acq.ScaleX = double.Parse(txt_ScaleX.Text.Trim());
            acq.ScaleY = double.Parse(txt_ScaleY.Text.Trim());
        }

        private void frm_CameraRateSet_Load(object sender, EventArgs e)
        {

            txt_ScaleX.Text = acq.ScaleX.ToString();
            txt_ScaleY.Text = acq.ScaleY.ToString();
        }
    }
}
