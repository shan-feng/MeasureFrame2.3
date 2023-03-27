using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcqDevice
{
    /// <summary>
    /// 设备类型
    /// </summary>
    [Serializable]
    public enum DeviceType
    {
        文件夹_面阵,
        文件夹_线扫,
        SVS_hr16050,
        IDS_uEye,
        KEYENCE_LINELASER,
        MEYI_LINELASER,
        Wenglor_LINELASER,
        MindVision,
        Do3Think,
        Basler,
        Imaging,
        HKVision,
    }

    /// <summary>
    /// 图像位深
    /// </summary>
    [Serializable]
    public enum PIXEL_DEPTH
    {
        PIXEL_DEPTH_8,          ///8位
        PIXEL_DEPTH_12,         ///12位
        PIXEL_DEPTH_16          ///16位
    }

    /// <summary>
    /// 图像彩色信息
    /// </summary>
    [Serializable]
    public enum PIXEL_TYPE
    {
        PIX_GRAY8,              ///灰度图8位，定义时可以不要位深信息
        PIX_RGB8                ///彩色图8位
    }

    /// <summary>
    /// 线扫模式
    /// </summary>
    [Serializable]
    public enum SENSOR_TYPE
    {
        Area,
        Line
    }

    /// <summary>
    /// 触发模式
    /// </summary>
    [Serializable]
    public enum TRIGGER_MODE
    {
        内触发 = 0,
        软触发,
        上升沿,
        下降沿
    }

    /// <summary>
    /// 曝光模式
    /// </summary>
    [Serializable]
    public enum EXPOSURE_MODE
    {
        内曝光 = 0, //内部设置曝光时间
        外曝光,    //电平信号设置曝光时间
    }

    [Serializable]
    public enum IMG_ADJUST
    {
        None = 0,
        垂直镜像,
        水平镜像,
        顺时针90度,
        逆时针90度,
        旋转180度
    }
}
