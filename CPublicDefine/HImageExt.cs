using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

/// <summary>
/// 公有类型定义
/// </summary>
namespace CPublicDefine
{
    [Serializable]
    public class HImageExt : HImage, ISerializable
    {
        /// <summary>
        /// 采集当前图像时候的位置X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 采集当前图像时候的位置X
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// 采集当前图像时候的位置X
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// X轴和直角坐标系X轴夹角
        /// </summary>
        public double PhiX { get; set; }
        /// <summary>
        /// X轴和直角坐标系旋转重叠后 Y轴和直角坐标系Y轴夹角
        /// </summary>
        public double PhiY { get; set; }
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
        /// <summary>
        /// 是否标定过
        /// </summary>
        public bool blnCalibrated { get; set; }
        #endregion
        #region 当前图像原点，用户指定
        public double CoorX { get; set; }
        public double CoorY { get; set; }
        public double CoorPhi { get; set; }
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public HImageExt() : base()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName"></param>
        public HImageExt(string fileName) : base(fileName)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="copy"></param>
        public HImageExt(IntPtr key, bool copy) : base(key, copy)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj"></param>
        public HImageExt(HObject obj) : base(obj)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelPointer"></param>
        public HImageExt(string type, int width, int height, IntPtr pixelPointer) : base(type, width, height, pixelPointer)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public HImageExt(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }

            this.X = info.GetDouble("X");
            this.Y = info.GetDouble("Y");
            this.Z = info.GetDouble("Z");
            this.PhiX = info.GetDouble("PhiX");
            this.PhiY = info.GetDouble("PhiY");
            this.ScaleX = info.GetDouble("ScaleX");
            this.ScaleY = info.GetDouble("ScaleY");
            //magical 20170821
            try
            {
                this.measureROIlist = (List<MeasureROI>)info.GetValue("measureROIlist", typeof(List<MeasureROI>));
            }
            catch (Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
            }
        }

        //<summary>
        //序列化
        //</summary>
        //<param name="info"></param>
        //<param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }

            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
            info.AddValue("PhiX", PhiX);
            info.AddValue("PhiY", PhiY);
            info.AddValue("ScaleX", ScaleX);
            info.AddValue("ScaleY", ScaleY);
            //magical 20170821
            info.AddValue("measureROIlist", measureROIlist);

            //Himage 内部函数 反编译得到的
            HSerializedItem item = this.SerializeImage();
            byte[] buffer = (byte[])item;
            item.Dispose();
            info.AddValue("data", buffer, typeof(byte[]));
        }

        #endregion
        #region 静态函数，通过已有HImage 获取HImageExt
        /// <summary>
        /// 静态函数，通过已有HImage 获取HImageExt
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static HImageExt Instance(HObject image)
        {
            //string type;
            //int width;
            //int height;

            //IntPtr ptr = image.GetImagePointer1(out type, out width, out height);
            //return new HImageExt(type, width, height, ptr);
            return new HImageExt(image);
        }
        /// <summary>
        /// 将引用图像的扩展信息复制到新的图像
        /// </summary>
        /// <param name="refImg"></param>
        public  void SetExtData(HImageExt refImg)
        {
            this.X = refImg.X;
            this.Y = refImg.Y;
            this.Z = refImg.Z;
            this.PhiX = refImg.PhiX;
            this.PhiY =refImg.PhiY;
            this.ScaleX = refImg.ScaleX;
            this.ScaleY = refImg.ScaleY;

            this.BoardRow = refImg.BoardRow;
            this.BoardCol = refImg.BoardCol;
            this.BoardX = refImg.BoardX;
            this.BoardY = refImg.BoardY;
            this.blnCalibrated = refImg.blnCalibrated;
            this.CoorX = refImg.CoorX;

            this.CoorY = refImg.CoorY;
            this.CoorPhi = refImg.CoorPhi;

            try
            {
                this.measureROIlist = refImg.measureROIlist.ToList();
            }
            catch (Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
            }
        }
        #endregion

        /// <summary>
        /// 从he文件中获取ImageExt对象
        /// </summary>
        /// <param name="fileName">he文件所在路径</param>
        /// <returns></returns>
        public static HImageExt ReadImageExt(string fileName)
        {
            HImageExt ImgExt = null;
            try
            {
                string ext = System.IO.Path.GetExtension(fileName).ToLower();
                if (ext == ".he")
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))//作为语句：用于定义一个范围，在此范围的末尾将释放对象。 请参阅 using 语句。 by:longteng
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        BinaryFormatter binaryFmt = new BinaryFormatter();
                        ImgExt = (HImageExt)binaryFmt.Deserialize(fs);
                        //fs.Close();  //by:longteng
                    }
                }
                else
                {
                    HImage temp = new HImage(fileName);
                    ImgExt = HImageExt.Instance(temp);
                }
                return ImgExt;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return ImgExt;
            }
        }

        /// <summary>
        /// 保存HimageExt 到本地
        /// </summary>
        /// <param name="fileName">文件路径</param>
        public void WriteImageExt(string fileName)
        {
            string ext = Path.GetExtension(fileName);

            if (ext == ".he")
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter binaryFmt = new BinaryFormatter();
                    fs.Seek(0, SeekOrigin.Begin);
                    binaryFmt.Serialize(fs, this);
                    //fs.Close(); //by:longteng
                }
            }
            else if (ext == "") //当没有传入有后缀的fileName,默认保存png magical 20170822
            {
                string type = this.GetImageType().ToString();
                if (type.Contains("real"))
                {
                    this.WriteImage("tiff", 0, fileName);
                }
                else
                {
                    this.WriteImage("png best", 0, fileName);
                }
            }
            else
            {
                this.WriteImage(ext.Substring(1), 0, fileName);
            }

        }

        /// <summary>
        /// 图片缩放
        /// </summary>
        /// <returns></returns>
        public HHomMat2D getHomImg()
        {
            HHomMat2D hom = new HHomMat2D();
            hom = hom.HomMat2dScaleLocal(ScaleX, ScaleY);
            return hom;
        }
        /// <summary>
        /// 获取校正相机夹角和校正轴矩阵
        /// </summary>
        /// <returns></returns>
        public HHomMat2D getHomAxis()
        {
            HHomMat2D homA = new HHomMat2D();
            homA = homA.HomMat2dRotateLocal(PhiX);//校正相机和轴夹角
            //homA = homA.HomMat2dSlantLocal(Y * Math.Sin(PhiY), "x");//校正XY轴夹角
            return homA;
        }
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public new HImageExt Clone()
        {
   
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    measureROIlist = measureROIlist.Where(c => c != null && (c.hobject == null || c.hobject.IsInitialized())).ToList();
                    // measureROIlist = measureROIlist.Where(c => c != null ).ToList();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream) as HImageExt;
                }
            


           //return
        }

        //测量显示的roi magical 20170821
        //[NonSerialized]
        public List<MeasureROI> measureROIlist = new List<MeasureROI>();

        public void UpdateRoiList(MeasureROI ROI)
        {
            try
            {
                int index = measureROIlist.FindIndex(e => e.CellID == ROI.CellID && e.roiType == ROI.roiType);
                if (index > -1)
                    measureROIlist[index] = ROI;
                else
                    measureROIlist.Add(ROI);
            }
            catch(Exception ex)
            {

            }
        }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            foreach(MeasureROI ROI in measureROIlist)
            {
                if (ROI.hobject == null || !ROI.hobject.IsInitialized())//修复为null 错误 magical 20171103
                {
                    ROI.hobject = null;
                }
            }
        }
        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            //如果he为老版本没有x y比例 手动设置为1,否则离线读取数据计算时候会出现异常   yoga 20180824
            if (ScaleX==0)
            {
                ScaleX = 1;
            }
            if (ScaleY==0)
            {
                ScaleY = 1;
            }
        }

    }
}
