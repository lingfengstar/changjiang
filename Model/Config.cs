using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Config
    {

        static public string OrgName;
        static public string BranchName;
        ///设备接口类型：
        ///         1：设备为COM接口
        ///         2：设备为USB接口
        static public string Iport;
        
        static public bool ReadConfig(string path)
        {
            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            OrgName = arr[0].Split('=')[1];
            if (!string.IsNullOrEmpty(arr[1].Split('=')[1]))
            {
                BranchName = arr[1].Split('=')[1];
            }
            else
            {
                BranchName = null;
            }
            Iport = arr[2].Split('=')[1];
            return true;

        }

        static public bool WriteConfig(string path,string[] arr)
        {
            string[]config=new string[3];
            config[0] = "OrgName=" + arr[0];
            config[1] ="BranchName=" + arr[1];
            config[2] = "Iport=" + arr[2];
            try
            {
                ReadTxt.ReadTxt.WriteTXT(path, config);
                return true;
            }
            catch
            {

            }
            return false;

        }
    }
}
