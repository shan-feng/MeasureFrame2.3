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
    public class CImageReg_Area : CMeasureCell
    {
        private string _DeviceID;
        private string _ImageName;
        private string _TriggerSource = string.Empty;
        private ROI _dispROI = null;
        private double _ExposureTime = 2000;


        private bool isAcqAuto = false;
        [NonSerialized]
        public AcqAreaDeviceBase m_AcqDevice;



        public string m_DeviceID
        {
            set
            {
                _DeviceID = value;
                m_AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
            }
            get { return _DeviceID; }
        }

        public IMG_ADJUST m_ImgAdjust
        { get; set; }

        public double m_ExposureTime
        {
            get { return _ExposureTime; }
            set { _ExposureTime = value; }
        }

        public string m_RegImgName { get; set; }
        public string m_ImageName
        {
            set { _ImageName = value; }
            get { return _ImageName; }
        }

        /// <summary>
        /// 检测区域
        /// </summary>
        public ROI m_dispROI
        {
            set { _dispROI = value; }
            get { return _dispROI; }
        }

        /// <summary>
        /// 位置补正的单元ID
        /// </summary>
        public int HomMatUnitID = -1;

        /// <summary>
        /// 畸变校正ID
        /// </summary>
        public int DistortionID = -1;


        public string m_TriggerSource
        {
            set
            {
                if (_TriggerSource != string.Empty)
                {
                    if (_TriggerSource == "TR1")
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR1");
                    else if (_TriggerSource == "TR2")
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR2");
                    else if (_TriggerSource == "TR3")
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR3");
                    else if (_TriggerSource == "TR4")
                        Helper.DelegateHelper.RemoveEvent(new HMeasureSYS(), "g_TR4");
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

        public bool m_IsAcqAuto
        {
            get
            {
                return isAcqAuto;
            }

            set
            {
                isAcqAuto = value;
            }
        }

        public CImageReg_Area()
            : base()
        {

        }

        public CImageReg_Area(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {

        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                HImage tempImg;
                if (m_Owner.ImgCatagory != ImageCatagory.注册图像)
                {
                    m_AcqDevice.setExposureTime(m_ExposureTime);
                }
               
                F_DATA_CELL datacell = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == m_ImageName);
                if (m_Owner.ImgCatagory == ImageCatagory.注册图像)
                {
                    HImageExt temp;
                    m_Owner.QueryImage(ImageCatagory.注册图像, m_RegImgName, out temp);
                    if (DistortionID != -1)
                    {
                        CMeasureCell cell = m_Owner.m_CellList.FirstOrDefault(c => c.m_CellID == DistortionID);
                        if (cell.m_CellCatagory == CellCatagory.畸变标定)
                        {
                            temp.blnCalibrated = true;
                            temp.BoardRow = ((CDistortionCalib)cell).BoardRow;
                            temp.BoardCol = ((CDistortionCalib)cell).BoardCol;
                            temp.BoardX = ((CDistortionCalib)cell).BoardX;
                            temp.BoardY = ((CDistortionCalib)cell).BoardY;
                            temp.ScaleX = ((CDistortionCalib)cell).ScaleX;
                            temp.ScaleY = ((CDistortionCalib)cell).ScaleY;
                        }
                    }
                    temp.measureROIlist.Clear();
                    ((List<HImageExt>)datacell.m_Data_Value)[0] = temp;
                    blnSuccessed = true;
                    return;
                }

                //将图像位置数据获取放在采集之前 yoga 2018-8-28 17:20:15
                double x=0, y=0, z=0;

                if (m_AcqDevice.m_DeviceType != DeviceType.文件夹_线扫 &&
                    m_AcqDevice.m_DeviceType != DeviceType.文件夹_面阵)
                {
                    m_Owner.GetCurrentPosi(out x, out y, out z);
                }
                //只有在不是自动采集图像模式下才使用当前图像作为运行图像 yoga 2018-8-29 20:37:08
                if (HMeasureSYS.g_SysStatus.m_RunMode == RunMode.执行一次&& isAcqAuto==false)
                {//单次执行的时候使用当前图片
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
                    //GC.Collect();
                    m_AcqDevice.eventWait.Reset();
                    //发送采集命令
                    if (!m_AcqDevice.CaptureImage(blnByHand))
                    {
                        blnSuccessed = false;
                        Helper.LogHandler.Instance.VTLogError("触发失败");
                        return;
                    }
                    m_AcqDevice.eventWait.WaitOne();
                    if (!this.m_Owner.m_Status && !blnByHand)
                    {
                        blnSuccessed = false;
                        Helper.LogHandler.Instance.VTLogError("状态异常");
                        return;
                    }
                    tempImg = m_AcqDevice.m_Image;

                }
                tempImg = HMeasureSet.AffineImage(tempImg, m_ImgAdjust);
                HImageExt imageExt =  HImageExt.Instance(tempImg.Clone());

                double scaleX, scaleY;
                scaleX = m_AcqDevice.ScaleX;
                scaleY = m_AcqDevice.ScaleY;

                //图像采集前已经获取 yoga 2018-8-28 17:22:04
                //double x, y, z;

                //if (m_AcqDevice.m_DeviceType != DeviceType.文件夹_线扫 &&
                //    m_AcqDevice.m_DeviceType != DeviceType.文件夹_面阵)
                //{
                //    m_Owner.GetCurrentPosi(out x, out y, out z);
                    
                //}

                imageExt.X = x;
                imageExt.Y = y;
                imageExt.Z = z;
                if (DistortionID != -1)
                {
                    CMeasureCell cell = m_Owner.m_CellList.FirstOrDefault(c => c.m_CellID == DistortionID);
                    if (cell.m_CellCatagory == CellCatagory.畸变标定)
                    {
                        imageExt.blnCalibrated = true;
                        imageExt.BoardRow = ((CDistortionCalib)cell).BoardRow;
                        imageExt.BoardCol = ((CDistortionCalib)cell).BoardCol;
                        imageExt.BoardX = ((CDistortionCalib)cell).BoardX;
                        imageExt.BoardY = ((CDistortionCalib)cell).BoardY;
                        scaleX = ((CDistortionCalib)cell).ScaleX;
                        scaleY = ((CDistortionCalib)cell).ScaleY;
                    }
                }

            if (HomMatUnitID != -1)
            {
                F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HomMatUnitID && c.m_Data_Name == ConstVavriable.outHomMat2D);
                HHomMat2D tempMat = ((List<HHomMat2D>)data.m_Data_Value)[0];
                double sx, sy, Phi, theta, tx, ty;
                sx = tempMat.HomMat2dToAffinePar(out sy, out Phi, out theta, out tx, out ty);
                imageExt.PhiX = Phi;
                imageExt.PhiY = theta;
            }
            imageExt.ScaleX = scaleX;
            imageExt.ScaleY = scaleY;

            ((List<HImageExt>)datacell.m_Data_Value)[0] = imageExt;  //最好在此返回采集图像完毕信号
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
    m_AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
    if (m_AcqDevice == null)
    {
        MessageBox.Show("单元U " + m_CellID + "中采集设备" + m_DeviceID + "不存在，请重新绑定");
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
}
    }
}
