using System;
using System.Collections.Generic;
using System.Text;

//转换数字金额为人民币大写
namespace ConvertMoney
{
    public class ConvertMoney
    {
        /// <summary> 
        /// 是否是浮点数 可带正负号 
        /// </summary> 
        /// <param name="inputData">输入字符串 </param> 
        /// <returns> </returns> 
        //public static bool IsDecimalSign(string inputData)
        //{
        //    Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        //    Match m = RegDecimalSign.Match(inputData);
        //    return m.Success;
        //}

        static public string convertMoneytoRMB(decimal decMoney)
        {
            string strMoney, strOneNum, strTemp, strConverted;
            int i, iLen;

            //设初值
            strConverted = "";
            strMoney = decMoney.ToString();
            iLen = strMoney.Length;

            //先取小数位
            if (strMoney.IndexOf(".") > 0)
            {
                strTemp = strMoney.Substring(strMoney.IndexOf(".") + 1, strMoney.Length - strMoney.IndexOf(".") - 1);
                if (strTemp.Length > 2)
                {
                    Console.WriteLine("错误：无法计算超过2位的小数");
                    return strConverted;
                }
                else if (strTemp == "0" || strTemp == "00" || strTemp == "")
                    strTemp = "";
                else
                {
                    if (strTemp.Length == 1 && strTemp != "0")
                    {
                        strConverted = converNumtoCapital(strTemp) + "角" + strConverted;
                    }
                    else
                    {
                        strOneNum = strTemp.Substring(0, 1);
                        strConverted = converNumtoCapital(strOneNum) + (strOneNum != "0" ? "角" : "") + strConverted;
                        strOneNum = strTemp.Substring(1, 1);
                        strConverted = strConverted + (strOneNum != "0" ? converNumtoCapital(strOneNum) + "分" : "");
                    }
                }
            }

            //取整数部分
            if (strMoney.IndexOf(".") < 0)
                strTemp = strMoney;
            else
                strTemp = strMoney.Substring(0, strMoney.IndexOf("."));

            iLen = strTemp.Length;
            //Console.WriteLine(iLen);
            Console.WriteLine(strTemp);

            if (iLen > 0 && decimal.Parse(strTemp) != 0)
            {
                strConverted = "元" + strConverted;

                for (i = 0; i < iLen; ++i)
                {
                    strOneNum = strTemp.Substring(iLen - 1 - i, 1);
                    //if (strOneNum == "0")
                    //{
                    //    //Console.WriteLine(strConverted.Substring(0, 1));
                    //    if ((strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿") && !((i + 1) % 12 == 0 || (i + 1) == 5 || (i + 1) % 9 == 0))
                    //        continue;
                    //    else
                    //        strConverted = converNumtoCapital(strOneNum) + strConverted;
                    //}

                    //Console.WriteLine((i + 1) % 4);

                    if ((i + 1) == 1)
                    {
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + strConverted;
                    }
                    else if (((i + 1) % 4 == 2 || (i + 1) == 2) && i % 4 != 0 && i % 8 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "拾" + strConverted;
                    }
                    else if (((i + 1) % 4 == 3 || (i + 1) == 3) && i % 4 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "佰" + strConverted;
                    }
                    else if ((i + 1) % 4 == 0 && i % 4 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "仟" + strConverted;
                    }
                    else if (i % 4 == 0 && i % 8 != 0)
                    {
                        Console.WriteLine("万位{0}", i);
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + "万" + strConverted;
                    }
                    else if (i % 8 == 0)
                    {
                        Console.WriteLine("亿位{0}", i);
                        if (strConverted.Substring(0, 1) == "万") strConverted = strConverted.Substring(1, strConverted.Length - 1);
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + "亿" + strConverted;
                    }
                    else
                    {
                        Console.WriteLine(i);
                        strConverted = converNumtoCapital(strOneNum) + strConverted;
                    }
                }
            }
            if ((decMoney * 100) % 10 ==0)
            {                strConverted = strConverted + "整";

                return strConverted ;
            }
            else
            {
                return strConverted;
            }

        }

        static string converNumtoCapital(string strNum)
        {
            string strCapital = "";
            switch (strNum)
            {
                case "0":
                    strCapital = "零";
                    break;
                case "1":
                    strCapital = "壹";
                    break;
                case "2":
                    strCapital = "贰";
                    break;
                case "3":
                    strCapital = "叁";
                    break;
                case "4":
                    strCapital = "肆";
                    break;
                case "5":
                    strCapital = "伍";
                    break;
                case "6":
                    strCapital = "陆";
                    break;
                case "7":
                    strCapital = "柒";
                    break;
                case "8":
                    strCapital = "捌";
                    break;
                case "9":
                    strCapital = "玖";
                    break;
                default:
                    strCapital = "";
                    break;
            }
            return strCapital;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal i;
            string s;
            while (1 == 1)
            {
                Console.WriteLine("输入一个金额(直接回车退出):");
                s = Console.ReadLine();
                if (s == "") break;
                //检查金额是否符合规则
                try
                {
                    i = decimal.Parse(s);
                    if (i < 0)
                        throw new Exception("不能是负数");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                /*
                if (!(ConvertMoney.IsDecimalSign(s)))
                    Console.WriteLine("错误：不是金额！");
                */

                //i = Convert.ToDecimal(s);
                s = ConvertMoney.convertMoneytoRMB(i);
                Console.WriteLine("人民币大写金额为:{0}", s);
            }
        }
    }
}