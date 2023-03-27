using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcqDevice
{
    public delegate void dlg_LaserProfile(double[] adValueX, double[] adValueZ);
    [Serializable]
    public class AcqLineDeviceBase : AcqDeviceBase
    {
        public AcqLineDeviceBase(DeviceType _DeviceType)
            : base(_DeviceType)
        {
            m_SensorType = SENSOR_TYPE.Line;
        }

        /// <summary>
        /// 采集帧数，只对线扫设备有效
        /// </summary>
        public int m_NeededProfile { get; set; }

        /// <summary>
        /// 采集帧数，只对线扫设备有效
        /// </summary>
        protected int m_CurrentProfile = 0;

        [NonSerialized]
        public bool m_bEnableRevData = false;//回调函数时，是否允许接受数据

        public override void setTrigger()
        {
            base.setTrigger();
            m_bEnableRevData = true;
        }

        public virtual void SetEndTrigger()
        {
            m_bEnableRevData = false;
            m_CurrentProfile = 0;
            eventWait.Set();
        }
    }
}
