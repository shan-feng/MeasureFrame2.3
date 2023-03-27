using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;
using System.Runtime.Serialization;
using Measure.UserDefine;
using CPublicDefine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Measure.UserDefine
{
    [Serializable]
    public abstract class ROI
    {
        private string _Color = "#00FF00";
        public string sColor
        {
            get { return _Color; }
            set { _Color = value; }
        }
        public abstract HRegion genRegion();
        public abstract HXLDCont genXLD();
        public abstract HTuple getTuple();
    }

    /// <summary>
    /// 直线信息
    /// </summary>
    [Serializable]
    public struct Line_INFO
    {
        public double StartY;//起点行坐标
        public double StartX;//起点列坐标
        public double EndY; //终点行坐标
        public double EndX;//终点列坐标
        public double Ny;//行向量
        public double Nx;//列向量
        public double Dist;//距离
        public double Phi;//方向
        public double MidY;//中间点行坐标
        public double MidX;//中间点列坐标
        public Line_INFO(double m_start_Row, double m_start_Col, double m_end_Row, double m_end_Col)
        {
            //r*Ny+c*Nx-Dist=0
            ///AX+BY+C=0        
            //A = Y2 - Y1
            //B = X1 - X2
            //C = X2*Y1 - X1*Y2
            this.StartY = m_start_Row;
            this.StartX = m_start_Col;
            this.EndY = m_end_Row;
            this.EndX = m_end_Col;
            this.Ny = m_start_Col - m_end_Col;
            this.Nx = m_end_Row - m_start_Row;
            this.Dist = m_start_Col * m_end_Row - m_end_Col * m_start_Row;
            Phi = HMisc.AngleLx(StartY, StartX, EndY, EndX);
            MidY = (StartY + EndY) / 2;
            MidX = (StartX + EndX) / 2;

        }
        public  HXLDCont genXLD()
        {
            HXLDCont xld = new HXLDCont();
            HMeasureSet.GenArrowContourXld(out xld,StartY, StartX, EndY, EndX, 10, 10);
            return xld;
        }
        public  HTuple getTuple()
        {
            double[] line = new double[] { StartY, StartX, EndY, EndX };
            return new HTuple(line);
        }
    };

    /// <summary>
    /// 面信息
    /// </summary>
    [Serializable]
    public struct Plane_INFO
    {
        public double x, y, z;     //The distance from the origin to the centroid, as measured along the x-axis.
        public double ax, by, cz, d;//Z + A*x + B*y + C =0  z's coefficient is just 1
        public double Angle;
        public double xAn, yAn, zAn;
        public double Flat, MinFlat, MaxFlat;
        public double MinZ, MaxZ;
    };

    [Serializable]
    public struct tagVector
    {
        public double a, b, c;
    };

    /// <summary>
    /// 圆信息
    /// </summary>
    [Serializable]
    public class Circle_INFO : ROI,ICloneable
    {
        public double CenterY, CenterX, Radius;
        public double StartPhi = 0.0, EndPhi = Math.PI * 2;
        public string PointOrder = "positive";
        public Circle_INFO()
        {
        }
        public Circle_INFO(double m_Row_center, double m_Column_center, double m_Radius)
        {
            this.CenterY = m_Row_center;
            this.CenterX = m_Column_center;
            this.Radius = m_Radius;
        }
        public Circle_INFO(double m_Row_center, double m_Column_center, double m_Radius, double m_StartPhi, double m_EndPhi, string m_PointOrder)
        {
            this.CenterY = m_Row_center;
            this.CenterX = m_Column_center;
            this.Radius = m_Radius;
            this.StartPhi = m_StartPhi;
            this.EndPhi = m_EndPhi;
        }
        public override HRegion genRegion()
        {
            HRegion h = new HRegion();
            h.GenCircle(CenterY, CenterX, Radius);
            return h;
        }
        public override HXLDCont genXLD()
        {
            HXLDCont xld = new HXLDCont();
            xld.GenCircleContourXld(CenterY, CenterX, Radius, StartPhi, EndPhi, PointOrder, 1.0);
            return xld;
        }

        public override HTuple getTuple()
        {
            double[] circle = new double[] { CenterY, CenterX, Radius };
            return new HTuple(circle);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 椭圆信息
    /// </summary>
    [Serializable]
    public class Ellipse_INFO : ROI,ICloneable
    {
        public double CenterY, CenterX, Phi, Radius1, Radius2;
        double StartPhi = 0.0, EndPhi = Math.PI * 2;
        public string PointOrder = "positive";
        public Ellipse_INFO()
        {
        }
        public Ellipse_INFO(double m_Row_center, double m_Column_center, double m_Phi, double m_Radius1, double m_Radius2)
        {
            this.CenterY = m_Row_center;
            this.CenterX = m_Column_center;
            this.Phi = m_Phi;
            this.Radius1 = m_Radius1;
            this.Radius2 = m_Radius2;
        }
        public override HRegion genRegion()
        {
            HRegion h = new HRegion();
            h.GenEllipse(CenterY, CenterX, Phi, Radius1, Radius2);
            return h;
        }

        public override HXLDCont genXLD()
        {
            HXLDCont xld = new HXLDCont();
            xld.GenEllipseContourXld(CenterY, CenterX, Phi, Radius1, Radius2, StartPhi, EndPhi, PointOrder, 1.0);
            return xld;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override HTuple getTuple()
        {
            double[] ellipse = new double[] { CenterY, CenterX, Phi, Radius1, Radius2 };
            return new HTuple(ellipse);
        }
    }

    /// <summary>
    /// 添加自定义形状
    /// </summary>
    [Serializable]
    public class UserDefinedShape_INFO : ROI
    {
        HRegion mHRegion;
        public UserDefinedShape_INFO()
        {
        }
        public UserDefinedShape_INFO(HRegion hregion)
        {
            mHRegion = hregion;
        }
        public override HRegion genRegion()
        {
            return mHRegion;
        }
        public override HXLDCont genXLD()
        {
            if (mHRegion != null && mHRegion.IsInitialized())
            {
                return mHRegion.GenContourRegionXld("border_holes");
            }
            else
            {
                return new HXLDCont();
            }
        }

        public override HTuple getTuple()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 矩形信息
    /// </summary>
    [Serializable]
    public class Rectangle_INFO : ROI
    {
        public double StartY, StartX, EndY, EndX;
        public Rectangle_INFO()
        {

        }
        public Rectangle_INFO(double m_Row_Start, double m_Column_Start, double m_Row_End, double m_Column_End)
        {
            this.StartY = m_Row_Start;
            this.StartX = m_Column_Start;
            this.EndY = m_Row_End;
            this.EndX = m_Column_End;
        }
        public override HRegion genRegion()
        {
            HRegion h = new HRegion();
            h.GenRectangle1(StartY, StartX, EndY, EndX);
            return h;
        }
        public override HXLDCont genXLD()
        {
            HXLDCont xld = new HXLDCont();
            HTuple row = new HTuple(StartY, EndY, EndY, StartY, StartY);
            HTuple col = new HTuple(StartX, StartX, EndX, EndX, StartX);
            xld.GenContourPolygonXld(row, col);
            return xld;
        }

        public override HTuple getTuple()
        {
            double[] rect1 = new double[] { StartY, StartX, EndY, EndX };
            return new HTuple(rect1);
        }
    }

    /// <summary>
    /// 旋转矩形信息
    /// </summary>
    [Serializable]
    public class Rectangle2_INFO : ROI, ICloneable
    {
        public double CenterY { get; set; }
        public double CenterX { get; set; }
        public double Phi { get; set; }
        public double Length1 { get; set; }
        public double Length2 { get; set; }

        public Rectangle2_INFO()
        {
        }
        public Rectangle2_INFO(double m_Row_center, double m_Column_center, double m_Phi, double m_Length1, double m_Length2)
        {
            this.CenterY = m_Row_center;
            this.CenterX = m_Column_center;
            this.Phi = m_Phi;
            this.Length1 = m_Length1;
            this.Length2 = m_Length2;
        }
        public override HRegion genRegion()
        {
            HRegion h = new HRegion();
            h.GenRectangle2(CenterY, CenterX, Phi, Length1, Length2);
            return h;
        }
        public override HXLDCont genXLD()
        {
            HXLDCont xld = new HXLDCont();
            xld.GenRectangle2ContourXld(CenterY, CenterX, Phi, Length1, Length2);
            return xld;
        }
        public override HTuple getTuple()
        {
            double[] rect2 = new double[] { CenterY, CenterX, Phi, Length1, Length2 };
            return new HTuple(rect2);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 3D点数据
    /// </summary>
    [Serializable]
    public struct Point3DF //3D点数据
    {
        public float X;
        public float Y;
        public float Z;
        public Point3DF(float _x, float _y, float _z)
        {
            this.X = _x;
            this.Y = _y;
            this.Z = _z;
        }
    }

    /// <summary>
    /// 矩形阵列返回的信息
    /// </summary>
    [Serializable]
    public struct RectInfo
    {
        public double X;//mm坐标
        public double Y;//mm坐标
        public double Value_Avg;///均值
        public double Value_Median;///中指
        public double Value_Max;///最大值
        public double Value_Min;///最小值
        public List<double> X_List;//x mm坐标
        public List<double> Y_List;//y mm坐标
        public List<double> Value_List;

        public RectInfo(double _x, double _y, double _avg, double _median, double _max, double _min, List<double> _xList, List<double> _yList, List<double> _valueList)
        {
            X = _x;
            Y = _y;
            Value_Avg = _avg;
            Value_Median = _median;
            Value_Max = _max;
            Value_Min = _min;
            X_List = _xList;
            Y_List = _yList;
            Value_List = _valueList;
        }
    }

    /// <summary>
    /// 十字坐标信息
    /// </summary>
    [Serializable]
    public struct Coordinate_INFO
    {
        public double Y, X, Phi;
        public Coordinate_INFO(double _row, double _col, double _phi)
        {
            this.Y = _row;
            this.X = _col;
            this.Phi = _phi;//坐标系X轴与图像X轴正方向的夹角
        }
    }

    /// <summary>
    /// 测量信息
    /// </summary>
    [Serializable]
    public struct Metrology_INFO
    {
        public double Length1, Length2, Threshold, MeasureDis;
        public HTuple ParamName, ParamValue;
        public int PointsOrder;

        public Metrology_INFO(double _length1, double _length2, double _threshold, double _measureDis, HTuple _paraName, HTuple _paraValue, int _pointsOrder)
        {
            this.Length1 = _length1;                        // 长/2
            this.Length2 = _length2;                        // 宽/2
            this.Threshold = _threshold;                    // 阈值
            this.MeasureDis = _measureDis;                  //间隔
            this.ParamName = _paraName;                     //参数名
            this.ParamValue = _paraValue;                   //参数值
            this.PointsOrder = _pointsOrder;                //点顺序 0位默认，1 顺时针，2 逆时针
        }
    }

}

namespace Measure
{
    /// <summary>
    /// 数据单元
    /// </summary>
    [Serializable]
    public struct F_DATA_CELL : ICloneable
    {
        private int _Data_CellID; ///所属单元ID，0 --表示全局变量
        public int m_Data_CellID
        {
            set { _Data_CellID = value; }
            get { return _Data_CellID; }
        }
        private DataGroup _Data_Group; //数据组合类型，0--单个变量，1--数组变量
        public DataGroup m_Data_Group
        {
            set { _Data_Group = value; }
            get { return _Data_Group; }
        }
        private DataType _Data_Type; //0-数值型,1--CString字符串型，2--2D点，3--3D点，4－直线，5－面
        public DataType m_Data_Type
        {
            set { _Data_Type = value; }
            get { return _Data_Type; }
        }
        private int _Data_Num; //变量组合数据的个数，单个变量为1，
        public int m_Data_Num
        {
            set { _Data_Num = value; }
            get { return _Data_Num; }
        }
        private DataAtrribution _Data_Atrr;//变量属性
        public DataAtrribution m_Data_Atrr
        {
            set { _Data_Atrr = value; }
            get { return _Data_Atrr; }
        }
        private String _Data_Name; //变量名称，不可重复，
        public String m_Data_Name
        {
            set { _Data_Name = value; }
            get { return _Data_Name; }
        }
        private String _DataTip; //注释
        public String m_DataTip
        {
            set { _DataTip = value; }
            get { return _DataTip; }
        }
        private String _Data_InitValue; //变量初值,为了兼容所有变量，将初值类型设为字符串型
        public String m_Data_InitValue
        {
            set { _Data_InitValue = value; }
            get { return _Data_InitValue; }
        }
        private Boolean _bUserDefineVariable;//是否用户自定义代码
        public Boolean m_bUserDefineVariable
        {
            set { _bUserDefineVariable = value; }
            get { return _bUserDefineVariable; }
        }
        //void* m_Data_Value; //变量的值,支持单量和数组形式
        [NonSerialized]
        private Object _Data_Value; //变量的值,支持单量和数组形式
        public Object m_Data_Value
        {
            set { _Data_Value = value; }
            get { return _Data_Value; }
        }

        public F_DATA_CELL(int _CellID, DataGroup _Group, DataType _type, String _Name, String _Tip,
                            String _InitValue, int _Num, Object _Value, DataAtrribution _Atrr)
        {
            _Data_CellID = _CellID;
            _Data_Group = _Group;
            _Data_Type = _type;
            _Data_Name = _Name;
            _DataTip = _Tip;
            _Data_InitValue = _InitValue;
            _Data_Num = _Num;
            _Data_Value = _Value;
            _bUserDefineVariable = false;
            _Data_Atrr = _Atrr;

        }
        public void InitValue(int _CellID,string _Name, DataType _DataType, string _InitValue)
        {
            _Data_CellID = _CellID;
            _Data_Name = _Name;
            InitValue(_DataType, _InitValue);
        }
        public void InitValue(DataType _DataType, string _InitValue)
        {
            _Data_Type = _DataType;
            _Data_InitValue = _InitValue;
            switch (_Data_Type)
            {
                case DataType.数值型:
                    _Data_Value = new List<Double>() { double.Parse(_InitValue) };
                    break;
                case DataType.字符串:
                    _Data_Value = new List<string>() { _InitValue };
                    break;
                case DataType.点2D:
                    _Data_Value = new List<PointF>() { new PointF() };
                    break;
                case DataType.点3D:
                    _Data_Value = new List<Point3DF>() { new Point3DF() };
                    break;
                case DataType.矩形阵列:
                    _Data_Value = new List<RectInfo>() { new RectInfo() };
                    break;
                case DataType.旋转矩形:
                    _Data_Value = new List<Rectangle2_INFO>() { new Rectangle2_INFO() };
                    break;
                case DataType.图像:
                    _Data_Value = new List<HImageExt>() { new HImageExt() };
                    break;
                case DataType.椭圆:
                    _Data_Value = new List<Ellipse_INFO>() { new Ellipse_INFO() };
                    break;
                case DataType.位置转换2D:
                    _Data_Value = new List<HHomMat2D>() { new HHomMat2D() };
                    break;
                case DataType.圆:
                    _Data_Value = new List<Circle_INFO>() { new Circle_INFO() };
                    break;
                case DataType.直线:
                    _Data_Value = new List<Line_INFO>() { new Line_INFO() };
                    break;
                case DataType.坐标系:
                    _Data_Value = new List<Coordinate_INFO>() { new Coordinate_INFO() };
                    break;
                case DataType.布尔型:
                    _Data_Value = new List<bool>() { Convert.ToBoolean(_InitValue.ToUpper()) };
                    break;
                case DataType.平面:
                    _Data_Value = new List<Plane_INFO>() { new Plane_INFO() };
                    break;
                default:
                    Helper.LogHandler.Instance.VTLogError("未处理数据类型 " + _Data_Type.ToString() + " 数据信息 ");
                    break;
            }

        }
        /// <summary>
        /// 根据类型设置值
        /// </summary>
        /// <param name="_DataType">类型</param>
        /// <param name="_value">值不为list</param>
        public void SetValue(DataType _DataType, object _value)
        {
            //if (_value == null)
            //{
            //    SetNull(_DataType);
            //}
            //else
            //{
            if (_value.GetType().Name.Contains("List"))
            {
                _Data_Value = _value;
            }
            else
            {
                switch (_Data_Type)
                {
                    case DataType.数值型:
                        _Data_Value = new List<Double>() { (double)_value };
                        break;
                    case DataType.字符串:
                        _Data_Value = new List<string>() { (string)_value };
                        break;
                    case DataType.点2D:
                        _Data_Value = new List<PointF>() { (PointF)_value };
                        break;
                    case DataType.点3D:
                        _Data_Value = new List<Point3DF>() { (Point3DF)_value };
                        break;
                    case DataType.矩形阵列:
                        _Data_Value = new List<RectInfo>() { (RectInfo)_value };
                        break;
                    case DataType.旋转矩形:
                        _Data_Value = new List<Rectangle2_INFO>() { (Rectangle2_INFO)_value };
                        break;
                    case DataType.图像:
                        _Data_Value = new List<HImageExt>() { (HImageExt)_value };
                        break;
                    case DataType.椭圆:
                        _Data_Value = new List<Ellipse_INFO>() { (Ellipse_INFO)_value };
                        break;
                    case DataType.位置转换2D:
                        _Data_Value = new List<HHomMat2D>() { (HHomMat2D)_value };
                        break;
                    case DataType.圆:
                        _Data_Value = new List<Circle_INFO>() { (Circle_INFO)_value };
                        break;
                    case DataType.直线:
                        _Data_Value = new List<Line_INFO>() { (Line_INFO)_value };
                        break;
                    case DataType.坐标系:
                        _Data_Value = new List<Coordinate_INFO>() { (Coordinate_INFO)_value };
                        break;
                    case DataType.布尔型:
                        _Data_Value = new List<bool>() { (bool)_value };
                        break;
                    case DataType.平面:
                        _Data_Value = new List<Plane_INFO>() { (Plane_INFO)_value };
                        break;
                    default:
                        Helper.LogHandler.Instance.VTLogError("未处理数据类型 " + _Data_Type.ToString() + " 数据信息 " + _value.GetType().ToString());
                        break;
                }

                //}
            }
        }
        public void SetNull(DataType _DataType)
        {
            switch (_Data_Type)
            {
                case DataType.数值型:
                    _Data_Value = new List<Double>();
                    break;
                case DataType.字符串:
                    _Data_Value = new List<string>();
                    break;
                case DataType.点2D:
                    _Data_Value = new List<PointF>();
                    break;
                case DataType.点3D:
                    _Data_Value = new List<Point3DF>();
                    break;
                case DataType.矩形阵列:
                    _Data_Value = new List<RectInfo>();
                    break;
                case DataType.旋转矩形:
                    _Data_Value = new List<Rectangle2_INFO>();
                    break;
                case DataType.图像:
                    _Data_Value = new List<HImageExt>();
                    break;
                case DataType.椭圆:
                    _Data_Value = new List<Ellipse_INFO>();
                    break;
                case DataType.位置转换2D:
                    _Data_Value = new List<HHomMat2D>();
                    break;
                case DataType.圆:
                    _Data_Value = new List<Circle_INFO>();
                    break;
                case DataType.直线:
                    _Data_Value = new List<Line_INFO>();
                    break;
                case DataType.坐标系:
                    _Data_Value = new List<Coordinate_INFO>();
                    break;
                case DataType.布尔型:
                    _Data_Value = new List<bool>();
                    break;
                case DataType.平面:
                    _Data_Value = new List<Plane_INFO>();
                    break;
                default:
                    Helper.LogHandler.Instance.VTLogError("未处理数据类型 " + _Data_Type.ToString());
                    break;
            }
        }

        public object GetValue()
        {
            object _value = null;
            if (_Data_Group == DataGroup.单量)
            {
                switch (_Data_Type)
                {
                    case DataType.点2D:
                        _value = ((List<PointF>)_Data_Value)[0];
                        break;
                    case DataType.点3D:
                        _value = ((List<Point3DF>)_Data_Value)[0];
                        break;
                    case DataType.矩形阵列:
                        _value = ((List<RectInfo>)_Data_Value)[0];
                        break;
                    case DataType.旋转矩形:
                        _value = ((List<Rectangle2_INFO>)_Data_Value)[0];
                        break;
                    case DataType.数值型:
                        _value = ((List<Double>)_Data_Value)[0];
                        break;
                    case DataType.图像:
                        _value = ((List<HImageExt>)_Data_Value)[0];
                        break;
                    case DataType.椭圆:
                        _value = ((List<Ellipse_INFO>)_Data_Value)[0];
                        break;
                    case DataType.位置转换2D:
                        _value = ((List<HHomMat2D>)_Data_Value)[0];
                        break;
                    case DataType.圆:
                        _value = ((List<Circle_INFO>)_Data_Value)[0];
                        break;
                    case DataType.直线:
                        _value = ((List<Line_INFO>)_Data_Value)[0];
                        break;
                    case DataType.字符串:
                        _value = ((List<string>)_Data_Value)[0];
                        break;
                    case DataType.坐标系:
                        _value = ((List<Coordinate_INFO>)_Data_Value)[0];
                        break;
                    case DataType.布尔型:
                        _value = ((List<bool>)_Data_Value)[0];
                        break;
                    case DataType.平面:
                        _value = ((List<Plane_INFO>)_Data_Value)[0];
                        break;
                    default:
                        Helper.LogHandler.Instance.VTLogError("未处理数据类型 " + _Data_Type.ToString());
                        break;
                }
            }
            else
            {
                _value = _Data_Value;
            }
            return _value;
        }
        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            _Data_InitValue = "-999.999";
        }
        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            InitValue(_Data_Type, _Data_InitValue);
        }
        public object Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }
    }
    /// <summary>
    /// 注册图像信息
    /// </summary>
    [Serializable]
    public class RegisterIMG_Info
    {
        public RegisterIMG_Info()
        {
        }

        private string _ImageID;       ///注册图像ID，唯一,  -1--表示当前图像，其他表示注册图像ID
        private string _type;            //图片类型
        private HImageExt _Image;         ///注册图像

        public string m_ImageID
        {
            get { return _ImageID; }
            set { _ImageID = value; }
        }
        public HImageExt m_Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        public string m_Type
        {
            get { return _type; }
        }
        ///
        public RegisterIMG_Info(string _ImageID, HImageExt _Image, string _type)
        {
            this._ImageID = _ImageID;
            this._Image = _Image;
            this._type = _type;
        }
    }
    /// <summary>
    /// 系统状态
    /// </summary>
    [Serializable]
    public struct Sys_Status
    {
        private RunMode _RunMode;
        private EnviMode _EnviMode;      ///0--联机模式; 1--脱机模式
        private bool _bAutoRun;   ///是否自动运行

        public RunMode m_RunMode
        {
            set { _RunMode = value; }
            get { return _RunMode; }
        }

        public EnviMode m_EnviMode
        {
            set { _EnviMode = value; }
            get { return _EnviMode; }
        }

        public bool m_bAutoRun
        {
            set { _bAutoRun = value; }
            get { return _bAutoRun; }
        }
    }

    /// <summary>
    /// 结果显示信息
    /// </summary>
    [Serializable]
    public class ResultView_Info
    {
        private string _dataType;
        private string _variableName;
        private string _conditionVarName;
        private string _disPosition;
        private Font _normalStyle;
        private string _normalColor;
        private string _ngColor;
        public List<sDictionary> m_dispObj = new List<sDictionary>();
        public string m_DataType
        {
            set { _dataType = value; }
            get { return _dataType; }
        }

        public string m_VariableName
        {
            set { _variableName = value; }
            get { return _variableName; }
        }

        public string m_ConditionVarName
        {
            set { _conditionVarName = value; }
            get { return _conditionVarName; }
        }

        public string m_DisPosition
        {
            set { _disPosition = value; }
            get { return _disPosition; }
        }

        public Font m_NormalStyle
        {
            set { _normalStyle = value; }
            get { return _normalStyle; }
        }

        public string m_NormalColor
        {
            set { _normalColor = value; }
            get { return _normalColor; }
        }

        public string m_NgColor
        {
            set { _ngColor = value; }
            get { return _ngColor; }
        }

        //public List<sDictionary> m_dispObj
        //{
        //    set { _dispObj = value; }
        //    get { return _dispObj; }
        //}
    }
    [Serializable]
    public struct sDictionary
    {
        private int _unitID;
        private string _variableName;
        public int m_UnitID
        {
            set { _unitID = value; }
            get { return _unitID; }
        }
        public string m_VariableName
        {
            set { _variableName = value; }
            get { return _variableName; }
        }
    }
    /// <summary>
    /// 通讯信息
    /// </summary>
    [Serializable]
    public class Communication_Info : ICloneable
    {
        private string _dataType;
        private string _unitID;
        private string _variableName;
        private string _spiltStr;
        private string _endStr;

        public string m_DataType
        {
            set { _dataType = value; }
            get { return _dataType; }
        }
        public string m_UnitID
        {
            set { _unitID = value; }
            get { return _unitID; }
        }
        public string m_VariableName
        {
            set { _variableName = value; }
            get { return _variableName; }
        }
        public string m_SpiltStr
        {
            set { _spiltStr = value; }
            get { return _spiltStr; }
        }
        public string m_EndStr
        {
            set { _endStr = value; }
            get { return _endStr; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    [Serializable]
    public class ROIText 
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
        public int size { get; set; }

        /// <summary>
        /// color
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// roitext magical 20180511
        /// </summary>
        /// <param name="_text">显示的内容</param>
        /// <param name="_row">行</param>
        /// <param name="_col">列</param>
        /// <param name="_font">字体</param>
        /// <param name="_size">大小</param>
        /// <param name="_color">颜色</param>
        public ROIText(string _text,  double _row, double _col, string _font, int _size, string _color)
        {
            text = _text;
            font = _font;
            row = _row;
            col = _col;
            size = _size;
            color = _color;
        }

    }
}
