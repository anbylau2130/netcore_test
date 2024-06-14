using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiuyeung.Common.Extentions
{
    public static class StringExtention
    {
        public static bool IsNotNullOrEmpty(this string? str)
        {
            return !IsNullOrEmpty(str);
        }

        public static bool IsNullOrEmpty(this string? str)
        {
            if (str == null)
                return true;
            else
                return string.IsNullOrEmpty(str);
        }

        public static Stream ToStream(this string? str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            return stream;
        }
    }
}
