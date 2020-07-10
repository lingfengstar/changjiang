using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTxt
{
    public class ReadTxt
    {
        static public string[] ReadTXT(string a)
        {
            string[] TXT;
            //该方法返回一个字符串数组。每一行都是一个数组元素。

            TXT = File.ReadAllLines(a,Encoding.Default);

            return TXT;
        }
        static public void WriteTXT(string path,string[] a)
        {
            File.WriteAllLines(path, a);
            
        }
    }
}
