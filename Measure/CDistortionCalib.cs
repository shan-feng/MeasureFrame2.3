using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Measure
{
    /// <summary>
    /// 区域标定
    /// </summary>
    [Serializable]
    public class CDistortionCalib : CMeasureCell
    {
        public CDistortionCalib() : base()
        {
        }

        public CDistortionCalib(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }
        /// <summary>
        /// 是否标定
        /// </summary>
        public bool Calibrated { get; set; }
        /// <summary>
        /// 注册图像名称
        /// </summary>
        public string RegisterImgName { get; set; }

        /// <summary>
        /// 标定板类型 0-圆孔 1-棋盘 
        /// </summary>
        public int BoardType { get; set; }

        /// <summary>
        /// //兴趣区域 
        /// </summary>
        public HRegion DetectRegion = new HRegion();

        /// <summary>
        /// //屏蔽区域 
        /// </summary>
        public HRegion DisableRegion = new HRegion();

        /// <summary>
        /// 棋盘格间距/孔板孔间距
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// X方向像素比率
        /// </summary>
        public double ScaleX { get; set; }
        /// <summary>
        /// Y方向像素比率
        /// </summary>
        public double ScaleY { get; set; }

        #region 区域标定映射
        /// <summary>
        /// 标定板行坐标
        /// </summary>
        public HTuple BoardRow { get; set; }

        /// <summary>
        /// 标定板列坐标
        /// </summary>
        public HTuple BoardCol { get; set; }
        /// <summary>
        /// 标定板X坐标
        /// </summary>
        public HTuple BoardX { get; set; }

        /// <summary>
        /// 标定板列坐标
        /// </summary>
        public HTuple BoardY { get; set; }
        #endregion
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                if (Calibrated)
                {
                    blnSuccessed = true;
                }
                else
                {
                    blnSuccessed = false;
                }
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                blnSuccessed = false;
            }
        }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (DisableRegion == null || !DisableRegion.IsInitialized())//修复为null 错误 magical 20171103
            {
                DisableRegion = null;
            }
            if (DetectRegion == null || !DetectRegion.IsInitialized())
            {
                DetectRegion = null;
            }
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (DetectRegion == null)
            {
                DetectRegion = new HRegion();
            }
            if (DisableRegion == null)
            {
                DisableRegion = new HRegion();
            }
        }
    }
}