using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Measure
{
    /// <summary>
    /// 数值类型数据计算、补偿、判定
    /// </summary>
    [Serializable]
    public class CDataCalculate : CMeasureCell
    {
        public CDataCalculate() : base()
        {
        }

        public CDataCalculate(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        /// <summary>
        /// 测试个数
        /// </summary>
        public int iCountTest = 0;
        /// <summary>
        /// 良品个数
        /// </summary>
        public int iCountOK = 0;

        /// <summary>
        /// 检测结果
        /// </summary>
        public string sResult = "NG";

        public List<FAI_Info> lstFAI = new List<FAI_Info>();
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                iCountTest += 1;
                bool bIsOK = true;
                foreach (FAI_Info fai in lstFAI)
                {
                    F_DATA_CELL data = m_Owner.QueryVariableValue(HMeasureSYS.U000, fai.sVariableName);
                    F_DATA_CELL dataResult = new F_DATA_CELL();
                    if (fai.sResultVariableName != "无")
                        dataResult = m_Owner.QueryVariableValue(HMeasureSYS.U000, fai.sResultVariableName);
                    dataResult.m_Data_Value = new List<bool>() { true };

                    if (((List<double>)(data.m_Data_Value)).Count > 0)
                    {
                        double dValue = ((List<double>)(data.m_Data_Value))[0];
                        dValue = dValue * fai.dK + fai.dB;
                        data.m_Data_Value = new List<double>() { dValue };
                        if (dValue > fai.dLimitUp || dValue < fai.dLimitDown)
                        {
                            fai.iCountNG += 1;
                            dataResult.m_Data_Value = new List<bool>() { false };
                            bIsOK = false;
                        }
                    }
                    else
                    {
                        data.m_Data_Value = new List<double>();
                        fai.iCountNG += 1;
                        dataResult.m_Data_Value = new List<bool>() { false };
                        bIsOK = false;
                    }

                    m_Owner.UpdateVariableValue(m_CellID, fai.sVariableName, data);
                    if (fai.sResultVariableName != "无")
                        m_Owner.UpdateVariableValue(m_CellID, fai.sResultVariableName, dataResult);
                }
                if (bIsOK)
                {
                    iCountOK += 1;
                    sResult = "OK";
                }
                object NewValue = new List<string>() { sResult };
                m_Owner.UpdateVariableValue(m_CellID, ConstVavriable.outResult, NewValue);
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }

        }

        public void Clear()
        {
            foreach (FAI_Info fai in lstFAI)
            {
                fai.iCountNG = 0;
            }
            iCountTest = 0;
            iCountOK = 0;
        }
    }

    public class FAI_Info
    {
        public string sVariableName { get; set; }

        //public F_DATA_CELL data
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// K值
        /// </summary>
        public double dK
        {
            get { return mK; }
            set { mK = value; }
        }
        /// <summary>
        /// B值
        /// </summary>
        public double dB
        {
            get { return mB; }
            set { mB = value; }
        }
        /// <summary>
        ///上限
        /// </summary>
        public double dLimitUp
        {
            get { return mLimitUp; }
            set { mLimitUp = value; }
        }
        /// <summary>
        ///下限
        /// </summary>
        public double dLimitDown
        {
            get { return mLimitDown; }
            set { mLimitDown = value; }
        }

        /// <summary>
        /// 当前FAI不良个数
        /// </summary>
        public int iCountNG
        {
            get { return mCountNG; }
            set { mCountNG = value; }
        }

        /// <summary>
        /// 判定结果变量名称
        /// </summary>
        public string sResultVariableName { get; set; }

        private double mValue = 999.999;
        private double mK = 1.0;
        private double mB = 0.0;
        private double mLimitUp = 10000.0;
        private double mLimitDown = -10000.0;
        private int mCountNG = 0;
        private bool mIsOK = true;
    }
}
