using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class regCheck
    {
        public string Check()
        {
            try
            {


                //获取CPU号
                ComputerInfo.ComputerInfo cpu = new ComputerInfo.ComputerInfo();
                string CPU = cpu.CPU;
                //验证注册码
                Reg.Reg.Register reg = new Reg.Reg.Register();
                reg.SubKey = "software\\Tiger\\";
                string key = reg.ReadRegeditKey("TDReg").ToString();
                if (!string.IsNullOrEmpty(key))
                {
                    Security.DESHelper des = new Security.DESHelper();
                    string regkey = des.DesDecrypt(key);
                    string cpuno = regkey.Split(';')[0];
                    DateTime date = Convert.ToDateTime(regkey.Split(';')[1]);
                    if (cpuno == CPU)
                    {
                        if (date > DateTime.Now)
                        {
                            return "1";
                        }
                        else
                        {
                            return "软件到期！";
                        }
                    }
                    else
                    {
                        return "机器码不符！";
                    }
                }
                else
                {
                    return "软件未注册！";
                }

            }
            catch
            {
                return "检测注册信息失败！";
            }
        }

    }
}
