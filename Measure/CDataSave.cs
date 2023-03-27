using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using HalconDotNet;
using Measure.UserDefine;
using System.Threading;
using CPublicDefine;

namespace Measure
{
    /// <summary>
    /// 数据存储单元
    /// </summary>
    [Serializable]
    public class CDataSave : CMeasureCell
    {
        public bool saveHeFlag = false;//是否将图像保存为he格式

        private static readonly object obLock = new object();
        public CDataSave() : base()
        {
        }

        public CDataSave(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        private List<string> _VariableList = new List<string>();
        private string _filePath;
        //private string _ImgPath;

        public List<string> m_VariableList
        {
            set { _VariableList = value; }
            get { return _VariableList; }
        }

        public string m_filePath
        {
            set
            {
                _filePath = value;
                //_ImgPath = Path.GetDirectoryName(_filePath);
            }
            get { return _filePath; }
        }

        //public string m_ImgPath
        //{
        //    get { return _ImgPath; }
        //}

        public override void Execute(bool blnByHand = false)
        {
            try
            {
                if (!Directory.Exists(m_filePath + "\\ExportData"))
                {
                    Directory.CreateDirectory(m_filePath + "\\ExportData");
                }
                string str = string.Empty;
                foreach (string name in m_VariableList)
                {
                    F_DATA_CELL data = m_Owner.m_VariableList.First(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                    name == c.m_Data_Name);
                    if (data.m_Data_Type == DataType.数值型)
                    {
                        List<double> temp = (List<double>)data.m_Data_Value;
                        foreach (double f in temp)
                        {
                            str += f.ToString("#0.0000");
                            str += ",";
                        }
                    }
                    else if (data.m_Data_Type == DataType.点2D)
                    {
                        List<PointF> temp = (List<PointF>)data.m_Data_Value;
                        foreach (PointF point in temp)
                        {
                            str += point.X.ToString("#0.0000");
                            str += ",";
                            str += point.Y.ToString("#0.0000");
                            str += ",";
                        }

                    }
                    else if (data.m_Data_Type == DataType.点3D)
                    {
                        List<Point3DF> temp = (List<Point3DF>)data.m_Data_Value;
                        foreach (Point3DF point in temp)
                        {
                            str += point.X.ToString("#0.0000");
                            str += ",";
                            str += point.Y.ToString("#0.0000");
                            str += ",";
                            str += point.Z.ToString("#0.0000");
                            str += ",";
                        }
                    }
                    else if (data.m_Data_Type == DataType.字符串)
                    {
                        List<string> temp = (List<string>)data.m_Data_Value;
                        foreach (string s in temp)
                        {
                            str += s;
                            str += ",";
                        }
                    }
                    else if (data.m_Data_Type == DataType.图像)
                    {
                        List<HImageExt> temp = (List<HImageExt>)data.m_Data_Value;
                        foreach (HImageExt _image in temp)
                        {
                            RegisterIMG_Info tempImg = new RegisterIMG_Info();
                            tempImg.m_Image = _image.Clone();
                            tempImg.m_ImageID = m_filePath;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(saveImg), tempImg);
                        }
                    }
                    //str += "\r\n";
                }
                if (str != "")//同步存储
                {
                    lock (obLock)
                    {
                        str = str.Substring(0, str.Length - 1);
                        str += "\r\n";
                        //按日期存储
                        DateTime dt = DateTime.Now;
                        string str_Date = DateTime.Now.ToString("yyyy-MM-dd");
                        StreamWriter sw = new StreamWriter(m_filePath + "\\ExportData\\" + str_Date + ".csv", true, Encoding.UTF8);
                        sw.Write(str);
                        sw.Close();
                    }
                }
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                blnSuccessed = false;
            }

        }

        private void saveImg(object obj)
        {
            try
            {
                RegisterIMG_Info imgInfo = (RegisterIMG_Info)obj;

                //根据后缀保存不同.he 或者png magical 20170822
                string fileName = "";
                if (saveHeFlag)
                {
                    fileName = imgInfo.m_ImageID + "\\ExportData\\" + DateTime.Now.ToString("MMdd-HHmmssffff") + ".he";
                }
                else
                {
                    fileName = imgInfo.m_ImageID + "\\ExportData\\" + DateTime.Now.ToString("MMdd-HHmmssffff");
                }
                imgInfo.m_Image.WriteImageExt(fileName);
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}
