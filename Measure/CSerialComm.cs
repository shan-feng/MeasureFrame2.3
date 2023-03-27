using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Measure.UserDefine;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Measure
{
    /// <summary>
    /// 串口通讯
    /// </summary>
    [Serializable]
    public class CSerialComm : CMeasureCell, ISerializable
    {
        public SerialPort mSerialPort;
        public List<Communication_Info> m_CommunicationInfo_List = new List<Communication_Info>();

        public CSerialComm() : base()
        {
        }

        public CSerialComm(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
            mSerialPort = new SerialPort();
        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                if (!mSerialPort.IsOpen)
                {
                    mSerialPort.Open();
                }

                StringBuilder str = new StringBuilder();
                foreach (Communication_Info info in m_CommunicationInfo_List)
                {
                    string sSpilt = Measure.CHelper.TransChar(info.m_SpiltStr);
                    string sEnd = Measure.CHelper.TransChar(info.m_EndStr);
                    F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == int.Parse(info.m_UnitID.Substring(1)) && c.m_Data_Name == info.m_VariableName);
                    if (info.m_DataType == DataType.数值型.ToString())
                    {
                        string[] temp = ((List<Double>)(data.m_Data_Value)).Select(c => c.ToString()).ToArray();
                        str.Append(string.Join(sSpilt, temp));
                    }
                    else if (info.m_DataType == DataType.字符串.ToString())
                    {
                        string[] temp = ((List<string>)(data.m_Data_Value)).ToArray();
                        str.Append(string.Join(sSpilt, temp));
                    }
                    else if (info.m_DataType == DataType.坐标系.ToString())
                    {
                        Coordinate_INFO temp = ((List<Coordinate_INFO>)(data.m_Data_Value))[0];
                        str.Append(temp.X.ToString());
                        str.Append(sSpilt);
                        str.Append(temp.Y.ToString());
                        str.Append(sSpilt);
                        str.Append(temp.Phi.ToString());
                    }
                    else if (info.m_DataType == DataType.点2D.ToString())
                    {
                        string[] temp = ((List<PointF>)(data.m_Data_Value)).Select(c => c.ToString()).ToArray();
                        str.Append(string.Join(sSpilt, temp));
                    }
                    else if (info.m_DataType == DataType.点3D.ToString())
                    {
                        string[] temp = ((List<Point3DF>)(data.m_Data_Value)).Select(c => c.ToString()).ToArray();
                        str.Append(string.Join(sSpilt, temp));
                    }
                    str.Append(sEnd);
                }
                mSerialPort.WriteLine(str.ToString());
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("_CellCatagory", _CellCatagory);
            info.AddValue("_Owner", _Owner);
            info.AddValue("m_CellID", m_CellID);
            info.AddValue("m_CellDesCribe", m_CellDesCribe);

            info.AddValue("PortName", mSerialPort.PortName);
            info.AddValue("BaudRate", mSerialPort.BaudRate);
            info.AddValue("Parity", mSerialPort.Parity);
            info.AddValue("StopBits", mSerialPort.StopBits);
            info.AddValue("DataBits", mSerialPort.DataBits);
            info.AddValue("m_CommunicationInfo_List", m_CommunicationInfo_List);
        }

        /// <summary>
        /// 构造函数反序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public CSerialComm(SerializationInfo info, StreamingContext context)
        {
            try
            {
                if (info == null)
                    throw new System.ArgumentNullException("info");

                _CellCatagory = (CellCatagory)(info.GetValue("_CellCatagory", typeof(CellCatagory)));
                _Owner = (CProject)(info.GetValue("_Owner", typeof(CProject)));
                m_CellID = info.GetInt32("m_CellID");
                m_CellDesCribe = info.GetString("m_CellDesCribe");

                mSerialPort = new SerialPort();
                mSerialPort.PortName = info.GetString("PortName");
                mSerialPort.BaudRate = info.GetInt32("BaudRate");
                mSerialPort.Parity = (Parity)(info.GetValue("Parity", typeof(Parity)));
                mSerialPort.StopBits = (StopBits)(info.GetValue("StopBits", typeof(StopBits)));
                mSerialPort.DataBits = info.GetInt32("DataBits");
                m_CommunicationInfo_List = (List<Communication_Info>)(info.GetValue("m_CommunicationInfo_List", typeof(List<Communication_Info>)));
                mSerialPort.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
