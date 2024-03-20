using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTp.Tools
{
    public static class StringHelper
    {
        public static bool stringCheckNotValid(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str.Any(char.IsDigit);
        }
    }
}
