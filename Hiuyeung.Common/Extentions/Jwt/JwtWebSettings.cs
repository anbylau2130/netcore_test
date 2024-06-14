using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiuyeung.Common.Extentions.Jwt
{
    public class JwtWebSettings
    {
        public string SecurityKey { get; set; }

        public int ExpireSeconds { get; set; }
    }
}
