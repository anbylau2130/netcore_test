
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    /// <summary>
    /// 客户需要的类
    /// </summary>
    public  class Target
    {

        /// <summary>
        /// 客户需要的类
        /// </summary>
        public Target()
        {
        }

        public virtual  void Request()
        {
            Console.WriteLine("普通请求！");
        }

    }
}