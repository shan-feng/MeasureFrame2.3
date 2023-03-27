using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Runtime.Serialization;

namespace CPublicDefine
{



    /// <summary>
    /// 用于展示效果的HObject
    /// </summary>
    [Serializable]
    public class MeasureROI
    {
        public MeasureROI()
        { }

        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellCatagory">单元类型</param>
        /// <param name="_CellDesCribe">单元描述</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        public MeasureROI(string _CellID, string _CellCatagory, string _CellDesCribe, string _roiType, string _drawColor, HObject _hobject)
        {
            CellID = _CellID;
            CellCatagory = _CellCatagory;
            CellDesCribe = _CellDesCribe;
            roiType = _roiType;
            drawColor = _drawColor;
            hobject = _hobject;
        }
        /// <summary>
        /// 单元id
        /// </summary>
        public string CellID { get; set; }
        /// <summary>
        /// 单元类型
        /// </summary>
        public string CellCatagory { get; set; }
        /// <summary>
        /// 单元描述
        /// </summary>
        public string CellDesCribe { get; set; }
        /// <summary>
        /// 轮廓分类
        /// </summary>
        public string roiType { get; set; }
        /// <summary>
        /// 画笔颜色
        /// </summary>
        public string drawColor { get; set; }
        /// <summary>
        /// 测量roi
        /// </summary>
        public HObject hobject { get; set; }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (hobject != null && !hobject.IsInitialized())//修复为null 错误 magical 20171103
            {
                hobject = null;
            }
        }
    }

    [Serializable]
    public class MeasureROIText: MeasureROI
    {

        /// <summary>
        /// 文字
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public string font = "mono";

        /// <summary>
        /// 显示的位置
        /// </summary>
        public double row { get; set; }
        public double col { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public int size{ get; set; }

    /// <summary>
    /// 测量roi
    /// </summary>
    /// <param name="_CellID">单元id</param>
    /// <param name="_CellCatagory">单元类型</param>
    /// <param name="_CellDesCribe">单元描述</param>
    /// <param name="_drawColor">画笔颜色</param>
    /// <param name="_hobject">测量roi 必须为HObject类型</param>
    public MeasureROIText(string _CellID, string _CellCatagory, string _CellDesCribe, string _roiType, string _drawColor,
            string _text, string _font, double _row, double _col, int _size)
        {
            hobject = null;
    
            CellID = _CellID;
            CellCatagory = _CellCatagory;
            CellDesCribe = _CellDesCribe;
            roiType = _roiType;
            drawColor = _drawColor;
            text = _text;
            font = _font;
            row = _row;
            col = _col;
            size = _size;
        }

    }

    /// <summary>
    /// 轮廓分类
    /// </summary>
    public enum enMeasureROIType
    {
        检测范围,
        检测点,
        检测结果,
        搜索范围,
        屏蔽范围,
        搜索方向,
        参考坐标系,
        文字显示
    }
}
