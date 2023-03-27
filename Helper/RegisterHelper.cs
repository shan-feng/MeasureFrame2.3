using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Helper
{
    [Serializable]
    public class RegisterHelper
    {
        public static RegisterHelper Instance = new RegisterHelper();
        ///// <summary>
        ///// 注册文件路径  不能直接使用相对路径  可能会发生变化 yoga 2018-8-30 13:37:45
        ///// </summary>
        //static string registerDatPath
        //{
        //    get
        //    {
        //         string ThePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        //        string tempFile = "register.dat";
        //        tempFile = System.IO.Path.Combine(ThePath, tempFile);
        //        return tempFile;
        //    }
        //}
        public string MachineCode
        {
            get
            {
                return "";
                //return Wrapper.Fun.GetHWInfo();
            }
        }
        public string RegisterCode { get; set; }
        public bool RegisteredDll()
        {
            try
            {
                return true;
                //string ThePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                //string registerDatPath = "register.dat";
                //registerDatPath = System.IO.Path.Combine(ThePath, registerDatPath);

                //Socket.SerHelper.SerializeObject(registerDatPath, this);
                //if (Wrapper.Fun.RegistDll( RegisterCode))
                //{

                //    return true;
                //}
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool TryRegisteredDll()
        {

            return true;
            //    string ThePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            //    string registerDatPath = "register.dat";
            //    registerDatPath = System.IO.Path.Combine(ThePath, registerDatPath);

            //    if (System.IO.File.Exists(registerDatPath))
            //    {
            //        try
            //        {

            //            RegisterHelper setting = Socket.SerHelper.DeserializeObject(
            //    registerDatPath) as RegisterHelper;
            //            if (setting == null)
            //            {
            //                setting = new RegisterHelper();
            //            }
            //            Instance = setting;

            //            if (Wrapper.Fun.RegistDll( Instance.RegisterCode))
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }

            //        }
            //        catch (Exception ex )
            //        {
            //            System.Windows.Forms.MessageBox.Show("注册失败:"+ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        System.Windows.Forms.MessageBox.Show("注册注册文件未找到" );
            //    }
            //    return false;
        }

    }
}
