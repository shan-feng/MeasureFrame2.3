using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using CPublicDefine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Measure
{
    [Serializable]
    public class CMeasureCell : ICloneable
    {
        //public static int m_LastCellID = 0;
        protected CellCatagory _CellCatagory;
        protected CProject _Owner = null;
        private int _CellID;

        /// <summary>
        /// 单元ID
        /// </summary>
        public int m_CellID
        {
            set { _CellID = value; }
            get { return _CellID; }
        }

        /// <summary>
        /// 检测单元分类
        /// </summary>
        public CellCatagory m_CellCatagory
        {
            set { _CellCatagory = value; }
            get { return _CellCatagory; }
        }

        /// <summary>
        /// 单元描述
        /// </summary>
        public string m_CellDesCribe=string.Empty;

        /// <summary>
        /// 是否屏蔽不执行
        /// </summary>
        public bool blnShield = false;

        /// <summary>
        /// 当前单元是否执行成功
        /// </summary>
        public bool blnSuccessed = false;


        /// <summary>
        /// 记录当前图片
        /// </summary>
        [NonSerialized]
        public HImageExt m_Image = new HImageExt();

        public CMeasureCell()
        {
        }

        public CMeasureCell(CellCatagory CellCatagory, int m_LastCellID)
        {
            _CellCatagory = CellCatagory;
            _CellID = m_LastCellID;
            m_Owner = HMeasureSYS.Cur_Project;
        }
        

        public virtual void Execute(bool blnByHand = false)
        {

        }
        public CProject m_Owner
        {
            set
            {
                if (value != null)
                {
                    _Owner = value;
                    if (_Owner.m_CellList.FindIndex(c => c.m_CellID == this.m_CellID) < 0)
                    {
                        _Owner.m_CellList.Add(this);
                        _Owner.m_LastCellID++;
                    }
                }
            }
            get
            {
                return _Owner;
            }
        }

        public object Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            CMeasureCell temp = (CMeasureCell)formatter.Deserialize(stream);
            //CProject.m_LastProjectID++;
            //temp._ProjectID = m_LastProjectID;
            return temp;
        }

    }
}
