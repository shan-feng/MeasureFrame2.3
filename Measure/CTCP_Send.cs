using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Measure.UserDefine;
using System.Drawing;

namespace Measure
{
    [Serializable]
    public class CTCP_Send : CMeasureCell
    {

        public List<Communication_Info> m_CommunicationInfo_List = new List<Communication_Info>();
        //public IPEndPoint m_Endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        public CTCP_Send() : base()
        {
        }

        public CTCP_Send(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        public override void Execute(bool blnByHand = false)
        {
            try
            {
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

                HMeasureSYS.g_TcpServer.SendMsgUserToEveryone(Encoding.Default.GetBytes(str.ToString()));
                blnSuccessed = true;

            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }
        } 
    }
}
