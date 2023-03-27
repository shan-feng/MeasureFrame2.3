using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Helper.Socket
{
    public class SerHelper
    {
        public SerHelper()
        {
        }

        public static byte[] Serialize(object obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                result = memoryStream.ToArray();
            }
            return result;
        }
       
        public static T Deserialize<T>(byte[] buffer)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T result;
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                result = (T)((object)binaryFormatter.Deserialize(memoryStream));
            }
            return result;
        }

        public static object Deserialize(byte[] datas, int index)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(datas, index, datas.Length - index);
            object result = binaryFormatter.Deserialize(memoryStream);
            memoryStream.Dispose();
            return result;

        }
             /// <summary>
             /// 序列化对象到文件
             /// </summary>
             /// <param name="filePath">序列化保存路径</param>
             /// <param name="obj">序列化对象</param>
        public static void SerializeObject(string filePath, object obj)//序列化
        {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fileStream, obj);
            }
        }
        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>反序列化后的对象</returns>
        public static object DeserializeObject(string filePath)
        {
            object obj = new object();
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    obj = b.Deserialize(fileStream);
                }
            }
            catch (Exception )
            {
                obj = null;
            }
            return obj;
        }
    }
}
