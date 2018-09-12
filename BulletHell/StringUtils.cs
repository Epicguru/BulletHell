using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public static class StringUtils
    {
        public static string Form(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
    }
}
