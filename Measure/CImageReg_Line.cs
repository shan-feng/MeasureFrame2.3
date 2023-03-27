using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using AcqDevice;
using Measure.UserDefine;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization;
using CPublicDefine;

namespace Measure
{
    /// <summary>
    /// 图像采集单元
    /// </summary>
    [Serializable]
    public class CImageReg_Line : CMeasureCell
    {
        private string _DeviceID;
        private string _ImageName;
        private string _TriggerSource = string.Empty;
        private string _EndTriggerSource = string.Empty;

        public AcqLineDeviceBase m_AcqDevice;

        public string m_DeviceID
        {
            set
            {
                _DeviceID = value;
                m_AcqDevice = (AcqLineDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
            }
            get { return _DeviceID; }
        }

        public IMG_ADJUST m_ImgAdjust { get; set; }

        public string m_RegImgName { get; set; }
        public string m_ImageName
        {
            set { _ImageName = value; }
            get { return _ImageName; }
        }

        /// <summary>
        /// 开始触发
        /// </summary>
        public string m_TriggerSource
        {
            set
            {
                if (_TriggerSource != string.Empty)
                {
                    if (_TriggerSource == "TR1")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR1");
                        //HMeasureSYS.g_TR1 -= new DelegateTrigger(m_AcqDevice.setTrigger);
                    }
                    else if (_TriggerSource == "TR2")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR2");
                        //HMeasureSYS.g_TR2 -= new DelegateTrigger(m_AcqDevice.setTrigger);
                    }
                    else if (_TriggerSource == "TR3")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR3");
                        //HMeasureSYS.g_TR3 -= new DelegateTrigger(m_AcqDevice.setTrigger);
                    }
                    else if (_TriggerSource == "TR4")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR4");
                        //HMeasureSYS.g_TR4 -= new DelegateTrigger(m_AcqDevice.setTrigger);
                    }
                }
                _TriggerSource = value;
                if (_TriggerSource == "TR1")
                {
                    HMeasureSYS.g_TR1 += new DelegateTrigger(m_AcqDevice.setTrigger);
                }
                else if (_TriggerSource == "TR2")
                {
                    HMeasureSYS.g_TR2 += new DelegateTrigger(m_AcqDevice.setTrigger);
                }
                else if (_TriggerSource == "TR3")
                {
                    HMeasureSYS.g_TR3 += new DelegateTrigger(m_AcqDevice.setTrigger);
                }
                else if (_TriggerSource == "TR4")
                {
                    HMeasureSYS.g_TR4 += new DelegateTrigger(m_AcqDevice.setTrigger);
                }
            }
            get { return _TriggerSource; }
        }
        public string m_EndTriggerSource
        {
            set
            {
                if (_EndTriggerSource != string.Empty)
                {
                    if (_EndTriggerSource == "EndTR1")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR1");
                        //HMeasureSYS.g_EndTR1 -= new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                    }
                    else if (_EndTriggerSource == "EndTR2")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR2");
                        //HMeasureSYS.g_EndTR2 -= new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                    }
                    else if (_EndTriggerSource == "EndTR3")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR3");
                        //HMeasureSYS.g_EndTR3 -= new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                    }
                    else if (_EndTriggerSource == "EndTR4")
                    {
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR4");
                        //HMeasureSYS.g_EndTR4 -= new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                    }
                }
                _EndTriggerSource = value;
                if (_EndTriggerSource == "EndTR1")
                {
                    HMeasureSYS.g_EndTR1 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                }
                else if (_EndTriggerSource == "EndTR2")
                {
                    HMeasureSYS.g_EndTR2 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                }
                else if (_EndTriggerSource == "EndTR3")
                {
                    HMeasureSYS.g_EndTR3 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                }
                else if (_EndTriggerSource == "EndTR4")
                {
                    HMeasureSYS.g_EndTR4 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
                }
            }
            get { return _EndTriggerSource; }
        }


        public CImageReg_Line() : base()
        {
        }

        public CImageReg_Line(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                HImage tempImg;
                F_DATA_CELL datacell = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == m_ImageName);
                if (m_Owner.ImgCatagory == ImageCatagory.注册图像)
                {
                    HImageExt temp;
                    m_Owner.QueryImage(ImageCatagory.注册图像, m_RegImgName, out temp);
                    temp.measureROIlist.Clear();

                    temp.ScaleX = m_AcqDevice.ScaleX;
                    temp.ScaleY = m_AcqDevice.ScaleY;
                    ((List<HImageExt>)datacell.m_Data_Value)[0] = temp;
                    blnSuccessed = true;
                    return;
                }
                if (HMeasureSYS.g_SysStatus.m_RunMode == RunMode.执行一次)
                {//单次执行的时候使用当前图片，如果当前图片存在则返回false
                    tempImg = ((List<HImageExt>)datacell.m_Data_Value)[0];

                    //由于是反复使用一张图片,所以需要手动清除 magical 201708021
                    ((HImageExt)tempImg).measureROIlist.Clear();

                    if (tempImg.IsInitialized())
                    {
                        blnSuccessed = true;
                        return;
                    }
                    else
                    {
                        blnSuccessed = false;
                        return;
                    }
                }
                else
                {
                    m_AcqDevice.eventWait.Reset();
                    //发送采集命令
                    if (!m_AcqDevice.CaptureImage(blnByHand))
                    {
                        blnSuccessed = false;
                        return;
                    }
                    m_AcqDevice.eventWait.WaitOne();
                    m_AcqDevice.m_bEnableRevData = false;
                    if (!this.m_Owner.m_Status && !blnByHand)
                    {
                        blnSuccessed = false;
                        return;
                    }
                    tempImg = m_AcqDevice.m_Image;
                }

                tempImg = HMeasureSet.AffineImage(tempImg, m_ImgAdjust);

                // tempImg = tempImg.MedianImage("square", 4, 0.5);
                //tempImg = tempImg.MedianSeparate(1, 8, "mirrored");

                //读取线扫开始位置，结束时读取位置不是很准确，最佳方法是运动控制和采集图像写到一个流程控制
               
                HImageExt imageExt = HImageExt.Instance(tempImg.Clone());

                double x, y, z;
                m_Owner.GetCurrentPosi(out x, out y, out z);

                //添加获取像素当量    yoga 20180824 
                //镭射未设计像素标定  故直接获取相机比例参数设置到he中
                double scaleX, scaleY;
                scaleX = m_AcqDevice.ScaleX;
                scaleY = m_AcqDevice.ScaleY;

                imageExt.X = x;
                imageExt.Y = y;
                imageExt.Z = z;

                imageExt.ScaleX = scaleX;
                imageExt.ScaleY = scaleY;
                ((List<HImageExt>)datacell.m_Data_Value)[0] = imageExt;  //最好在此返回采集图像完毕信号
                //最好在此返回采集图像完毕信号
                int index = m_Owner.m_VariableList.IndexOf(datacell);
                m_Owner.m_VariableList[index] = datacell;
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }

        }
        

        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            m_AcqDevice = (AcqLineDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
            if (m_AcqDevice == null)
            {
                MessageBox.Show(m_DeviceID + "设备不存在，请重新绑定");
                //设备不存在就不要绑定事件，否则会报错
                return;
            }
                
            if (_TriggerSource == "TR1")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR1");
                HMeasureSYS.g_TR1 += new DelegateTrigger(m_AcqDevice.setTrigger);
            }
            else if (_TriggerSource == "TR2")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR2");
                HMeasureSYS.g_TR2 += new DelegateTrigger(m_AcqDevice.setTrigger);
            }
            else if (_TriggerSource == "TR3")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR3");
                HMeasureSYS.g_TR3 += new DelegateTrigger(m_AcqDevice.setTrigger);
            }
            else if (_TriggerSource == "TR4")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR4");
                HMeasureSYS.g_TR4 += new DelegateTrigger(m_AcqDevice.setTrigger);
            }

            if (_EndTriggerSource == "EndTR1")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR1");
                HMeasureSYS.g_EndTR1 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
            }
            else if (_EndTriggerSource == "EndTR2")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR2");
                HMeasureSYS.g_EndTR2 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
            }
            else if (_EndTriggerSource == "EndTR3")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR3");
                HMeasureSYS.g_EndTR3 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
            }
            else if (_EndTriggerSource == "EndTR4")
            {
                Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_EndTR4");
                HMeasureSYS.g_EndTR4 += new DelegateTrigger(m_AcqDevice.SetEndTrigger);
            }
        }
    }
}
