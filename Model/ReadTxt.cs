using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JianKunKing.Log4NetTest;

namespace ReadTxt
{
    public class ReadTxt
    {
        static public string[] ReadTXT(string a)
        {
            try
            {


                string[] TXT;
                //该方法返回一个字符串数组。每一行都是一个数组元素。

                TXT = File.ReadAllLines(a, Encoding.UTF8);

                return TXT;
            }
            catch(Exception ex)
            {
                LogisTrac.WriteLog(typeof(ReadTxt), ex);

            }
            return null;
        }
        static public void WriteTXT(string path,string[] a)
        {
            File.WriteAllLines(path, a);
            
        }
    }
}
