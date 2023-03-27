using System;
using System.Text;
using Measure;
using Helper;

namespace Measure.Global
{
    /// <summary>
    /// 定义VB.NET脚本使用的全局对象容器类型
    /// </summary>
    [Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute()]
    public class GlobalObject
    {
        static VBA_Function h = null;
        /// <summary>
        /// 全局的 HMeasureSYS 对象
        /// </summary>
        public static VBA_Function H
        {
            get
            {
                return h;
            }
        }
    }
}
