using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    public partial class PinYinHelper
    {
        public string getPinYin(string s1)
        {
            string s2 = "";
            foreach (char s in s1)
            {
                ChineseChar cc = new ChineseChar(s);
                s2 += cc.Pinyins[0][0];
            }
            return s2;
        }
    }
}
