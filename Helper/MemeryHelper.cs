using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Helper
{
    public static class MemeryHelper
    {
        /// <summary>
        /// 深拷贝函数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object DeepCopyObject(object obj)
        {
            if (obj != null)
            {
                object obj2 = Activator.CreateInstance(obj.GetType());
                foreach (FieldInfo info in obj.GetType().GetFields())
                {
                    if (info.FieldType.GetInterface("IList", false) == null)
                    {
                        info.SetValue(obj2, info.GetValue(obj));
                    }
                    else
                    {
                        IList list = (IList)info.GetValue(obj2);
                        if (list != null)
                        {
                            foreach (object obj3 in (IList)info.GetValue(obj))
                            {
                                list.Add(DeepCopyObject(obj3));
                            }
                        }
                    }
                }
                return obj2;
            }
            return null;
        }


    }
}
