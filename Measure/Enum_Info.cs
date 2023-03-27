using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Measure
{
    /// <summary>
    /// 检测单元分类
    /// </summary>
    public enum CellCatagory
    {
        None = -1,
        面阵图像单元,
        线阵图像单元,
        直线单元,              ///直线检测单元
        圆单元,                ///圆检测单元
        椭圆单元,              ///椭圆检测单元
        坐标系,            ///建立直角坐标系
        矩形阵列,              ///多个区域取点
        TCP_IP通讯,            ///TCP/IP通讯
        UDP通讯,               ///UDP通讯
        数据计算,               ///数据计算单元
        数据存储,               ///数据存储
        位置补正,               ///位置补正
        保留12,               ///相机标定
        结果显示,               ///结果显示
        相机机械坐标转换,       ///相机和机械坐标转换
        旋转中心标定,             ///旋转中心标定
        数值补偿和判定,          ///数值补偿和判定
        保留17,               ///保留17
        结果显示2,               ///结果显示2
        串口通讯,               ///串口通讯
        保留20,                ///保留20
        保留21,              ///相机标定halcon 12 標定板
        畸变标定,               ///畸变标定，使用区域补偿法
        构造点,                ///构造点
        显示单元,///显示单元
        延时单元,
        Halcon引擎,
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType         ///复数全部用list来存储
    {
        数值型 = 0,                ///数值类型   float
        字符串,                  ///CString 字符串类型
        点2D,                    ///2D点
        点3D,                    ///3D点
        直线,                    ///直线
        圆,                      ///圆
        椭圆,                    ///椭圆
        坐标系,                  ///坐标系
        矩形阵列,                ///矩形阵列 rectInfo
        图像,                    ///图像
        位置转换2D,              ///HHomMat2D
        布尔型,                  ///布尔型
        旋转矩形,                ///旋转矩形    rectangle2_info
        平面,                  ///面
        矩形,                     ///矩形 rectangle_info
    }

    /// <summary>
    /// 自定义变量数据类型
    /// </summary>
    public enum DataGroup
    {
        单量 = 0,           ///单个变量
        数组,              ///数组类型
    }

    /// <summary>
    /// 变量归属
    /// </summary>
    public enum DataAtrribution
    {
        全局变量 = 0,              ///全局变量，但无需保存
        系统变量,                  ///系统变量，需要保存到本地
        //常量,                      ///常量
    }

    /// <summary>
    /// 展示图像分类
    /// </summary>
    public enum ImageCatagory
    {
        当前图像,
        注册图像
    }

    /// <summary>
    /// 图片滤波方法
    /// </summary>
    public enum PreTreatMent
    {
        无,
        中值滤波,
        均值滤波,
        高斯滤波,
        平滑滤波
    }

    /// <summary>
    /// 运行模式
    /// </summary>
    public enum RunMode
    {
        None = 0,
        单步运行,
        执行一次,
        循环运行,
    }

    /// <summary>
    /// 连接模式
    /// </summary>
    public enum EnviMode
    {
        联机模式 = 0,
        脱机模式,
    }

    /// <summary>
    /// 定位模板类型
    /// </summary>
    public enum ModelType
    {
        形状模板 = 0,
        灰度模板,
    }

    /// <summary>
    /// 标定模型
    /// </summary>
    public enum CalibrationMode
    {
        面阵相机_普通镜头 = 0,
        面阵相机_远心镜头,
    }

    /// <summary>
    /// 内部常量定义
    /// </summary>
    public static class ConstVavriable
    {
        #region 单元输出变量 定义和赋值不允许重复
        //public const string outRow = "outRow";
        //public const string outCol = "outCol";
        public const string outLine = "outLine";
        //public const string outLineW = "outLineW";
        public const string outCircle = "outCircle";
        //public const string outCircleW = "outCircleW";
        public const string outEllipse = "outEllipse";
        //public const string outEllipseW = "outEllipseW";
        public const string outX = "outX";
        //public const string outColW = "outColW";
        public const string outY = "outY";
        //public const string outRowW = "outRowW";
        public const string outPointF = "outPointF";
        public const string outCoord = "outCoord";
        public const string outRectInfo = "outRectInfo";
        public const string outHomMat2D = "outHomMat2D";
        public const string ScaleX = "ScaleX";
        public const string ScaleY = "ScaleX";
        public const string outResult = "outResult";
        public const string outRow1 = "outRow1";
        public const string outCol1 = "outCol1";
        public const string Flatness1 = "Flatness1";
        public const string Flatness2 = "Flatness2";
        public const string outImage = "outImage";
        #endregion
    }
}
