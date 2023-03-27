using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Threading;
using System.Runtime.Serialization;

namespace AcqDevice
{
    public delegate void DispImageCallback(HImage img, int _user);
    [Serializable]
    public class AcqAreaDeviceBase : AcqDeviceBase
    {
        protected int _ImgWidth;
        protected int _ImgHeight;
        protected PIXEL_DEPTH _PixDepth;
        protected PIXEL_TYPE _PixType;
        protected int _TrigerMode = 2;//触发模式 
        protected float _ExposeTime;//曝光时间
        protected float _Framerate;//帧率
        [NonSerialized]
        public DispImageCallback dispImgCallback = null;
        public int m_ImgWidth
        {
            get { return _ImgWidth; }
        }

        public int m_ImgHeight
        {
            get { return _ImgHeight; }
        }
        public PIXEL_DEPTH m_PixDepth
        {
            get { return _PixDepth; }
        }

        public PIXEL_TYPE m_PixType
        {
            get { return _PixType; }
        }

        [NonSerialized]
        public AutoResetEvent SignalWait = new AutoResetEvent(false);//软触发时信号同步
        public AcqAreaDeviceBase(DeviceType _DeviceType)            : base(_DeviceType)
        {
            m_SensorType = SENSOR_TYPE.Area;
        }

        public override void setTrigger()
        {
            base.setTrigger();
            SignalWait.Set();
        }

        public virtual bool setExposureTime(double dValue)
        {
            return true;
        }

        /// <summary>
        /// 设置触发模式
        /// </summary>
        /// <param name="mode">触发模式</param>
        /// <returns>成功返回True</returns>
        public virtual bool SetTriggerMode(TRIGGER_MODE mode)
        {
            return true;
        }

        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            SignalWait = new AutoResetEvent(false);//采集信号
        }
    }
}
