using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using Measure.UserDefine;
using System.Runtime.Serialization;
using CPublicDefine;
using System.Drawing;

namespace Measure
{
    //2D测量线
    [Serializable]
    public class CMeasure_2D : CMeasureCell
    {
        /// <summary>
        /// 当前图像名称
        /// </summary>
        public string m_CurrentImgName = string.Empty;
        

        /// <summary>
        /// 检测形态信息
        /// </summary>
        public Metrology_INFO m_MetrologyInfo;

        /// <summary>
        /// 位置补正的单元ID
        /// </summary>
        public int m_homMatUnitID;
        
        /// <summary>
        /// //屏蔽区域 magical 20171028
        /// </summary>
        public HRegion disableRegion = new HRegion();

        /// <summary>
        /// 第一次加载图像时参考坐标 存储图像坐标
        /// </summary>
        public Coordinate_INFO RegCoor = new Coordinate_INFO();
        /// <summary>
        /// 是否对屏蔽区域补正 ，补正屏蔽产品上需要屏蔽的区域，不补正屏蔽载具上的区域
        /// </summary>
        public bool isCorrect;


        /// <summary>
        /// 画笔颜色
        /// </summary>
        public string m_drawColor = "#FF0000";

        //输出轮廓线
        [NonSerialized]
        public HXLDCont m_MeasureXLD = new HXLDCont();   ///检测形态轮廓
        [NonSerialized]
        public HXLDCont m_MeasureCross = new HXLDCont(); ///检测点十字
        [NonSerialized]
        public HXLDCont m_ResultXLD = new HXLDCont();    ///检测结果轮廓
        [NonSerialized]
        public HXLDCont m_ArrowXLD = new HXLDCont();    ///检测方向

        //输出检测点
        [NonSerialized]
        protected HTuple m_row = new HTuple();
        [NonSerialized]
        protected HTuple m_col = new HTuple();

        public HTuple point_Row
        {
            get { return m_row; }
        }
        public HTuple points_Col
        {
            get { return m_col; }
        }
        public CMeasure_2D()
        {

        }
        public CMeasure_2D(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        public override void Execute(bool blnByHand = false)
        {
            base.Execute(blnByHand);

        }

        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            m_row = new HTuple();
            m_col = new HTuple();
            m_MeasureXLD = new HXLDCont();   ///检测形态轮廓
            m_MeasureCross = new HXLDCont(); ///检测点十字
            m_ResultXLD = new HXLDCont();    ///检测结果轮廓
            disableRegion = new HRegion();
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (disableRegion == null || !disableRegion.IsInitialized())//修复为null 错误 magical 20171103
            {
                disableRegion = new HRegion((double)0,0,0);
            }
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (disableRegion == null)
            {
                disableRegion = new HRegion();
            }
        }
    }
}
