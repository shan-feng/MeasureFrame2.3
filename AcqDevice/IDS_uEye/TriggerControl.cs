using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AcqDevice
{

    partial class TriggerControl : IControl
    {

        public TriggerControl(uEye.Camera camera) : base(camera)
        {
            InitializeComponent();
        }

        public override void OnControlFocusActive()
        {
            UpdateTriggerControls();
        }

        public override void OnControlFocusLost()
        {
        }

        private void radioTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Camera.Acquisition.IsOpened)
            {
                if (rad_TriggerContinue.Checked)
                {
                    //m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                    m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Continuous);
                    m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                }
                // Software trigger
                else if (rad_TriggerSoft.Checked)
                {
                    //m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Wait);
                    m_Camera.Acquisition.Stop();
                    m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Software);
                    //m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.DontWait );
                }
                // Hardware trigger falling edge
                else if (rad_TriggerFE.Checked)
                {
                    // m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                    m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Hi_Lo);
                    m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                }
                // Hardware trigger rising edge
                else if (rad_TriggerRE.Checked)
                {
                    //m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                    m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Lo_Hi);
                    m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                }
                else
                {
                    m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Continuous);
                    m_Camera.Acquisition.Capture();
                }
            }

        }

        private void bt_TriggerForce_Click(object sender, EventArgs e)
        {
            uEye.Defines.TriggerMode TriggerMode;
            m_Camera.Trigger.Get(out TriggerMode);
            if (TriggerMode == uEye.Defines.TriggerMode.Software)
            {
                m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Force);
            }
            //m_Camera.Trigger.Force();
        }

        private void UpdateTriggerControls()
        {
            uEye.Defines.TriggerMode TriggerMode;
            m_Camera.Trigger.Get(out TriggerMode);
            switch (TriggerMode)
            {
                case uEye.Defines.TriggerMode.Off:
                    rad_TriggerOff.Checked = true;
                    break;
                case uEye.Defines.TriggerMode.Continuous:
                    rad_TriggerContinue.Checked = true;
                    break;
                case uEye.Defines.TriggerMode.Software:
                    rad_TriggerSoft.Checked = true;
                    break;
                case uEye.Defines.TriggerMode.Lo_Hi:
                    rad_TriggerRE.Checked = true;
                    break;
                case uEye.Defines.TriggerMode.Hi_Lo:
                    rad_TriggerFE.Checked = true;
                    break;
            }
        }
    }
}
