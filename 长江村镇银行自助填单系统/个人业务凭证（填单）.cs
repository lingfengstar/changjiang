using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 长江村镇银行自助填单系统
{
    public partial class 个人业务凭证_填单_ : Form
    {
        public 个人业务凭证_填单_()
        {
            InitializeComponent();
        }
        string path = "print\\grywpz.dat";
        private void 个人业务凭证_填单__Load(object sender, EventArgs e)
        {
            yy.Text = dateTimePicker1.Value.Year.ToString();
            mm.Text = dateTimePicker1.Value.Month.ToString();
            dd.Text = dateTimePicker1.Value.Day.ToString();
        }
        /// <summary>
        /// 小写金额11个
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private string[] St(string a)
        {
            string[] arr = new string[11];
            int ii = a.Length;
            if (ii < 12)
            {
                for (int i = 0; i < 11; i++)
                {
                    int start = ii - i;
                    if (start < 1)
                    {
                        arr[i] = "";
                    }
                    else
                    {
                        string aa = a.Substring(start - 1, 1);
                        arr[i] = aa;
                    }

                }
            }

            return arr;
        }
        /// <summary>
        /// checkbox对号选择
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string Check(bool i)
        {
            string check;
            if (i == true)
            {
                check = ((char)8730).ToString();


            }
            else
            {
                check = "";
            }
            return check;
        }
        /// <summary>
        /// 市县选择
        /// </summary>
        /// <param 市/县="i"></param>
        /// <returns></returns>
        private string RCheck(bool i)
        {
            string check;
            if (i == true)
            {
                check = "\\";


            }
            else
            {
                check = "";
            }
            return check;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();
            //方框选择
            string [] c= { Check(c1.Checked), Check(c2.Checked), Check(c3.Checked),
                Check(c4.Checked), Check(c5.Checked), Check(c6.Checked), Check(c7.Checked),
                Check(c8.Checked), Check(c9.Checked), Check(c10.Checked), Check(c11.Checked),
                Check(c12.Checked), Check(c13.Checked), Check(c14.Checked), Check(c15.Checked),
                Check(c16.Checked), Check(c17.Checked), Check(c18.Checked), Check(c19.Checked),
                Check(c20.Checked), Check(c21.Checked), Check(c22.Checked), Check(c23.Checked)};
            //小写金额位数
            string aa = je.Text;//小写金额去小数点
            aa=
            aa = aa.Replace(",", "");
            aa = aa.Replace(".", "");
            int le = aa.Length;

            string[] st = St(aa);
            //str.Substring(start - 1, length));
            //打印数组
            string[] arr1 = { yy.Text,mm.Text,dd.Text, t1.Text,t2.Text,t3.Text,t4.Text,t5.Text,t6.Text,
                t7.Text,t8.Text,t9.Text, RCheck(xian.Checked),RCheck(shi.Checked), t10.Text,
                yi.Text,qianw.Text,baiw.Text,shiw.Text,wan.Text,qian.Text,bai.Text,shii.Text,yuan.Text,jiao.Text,fen.Text,t11.Text,t12.Text,
                t13.Text,t14.Text,t15.Text,t16.Text,t17.Text,t18.Text,c[0],c[1],c[2],c[3],c[4],c[5],c[6],
                c[7],c[8],c[9],c[10],c[11],c[12],t19.Text,c[13],c[14],c[15],c[16],c[17],c[18],c[19],c[20],
                c[21],c[22],t20.Text,t21.Text};


            myp.NewPage();
            myp.IsImmediatePrintNotPreview = true;
            for (int i = 0; i < arr.Length; i++)
            {

                //定义字体
                Font font = new Font(arr[i].Split(',')[1].ToString(), Convert.ToInt32(arr[i].Split(',')[2]));
                //打印位置
                string x = arr[i].Split(',')[3];
                string y = arr[i].Split(',')[4];
                myp.Currentx = Convert.ToInt32(Convert.ToDecimal(x) * 10);
                myp.Currenty = Convert.ToInt32(Convert.ToDecimal(y) * 10);
                myp.DrawText(arr1[i], font);

            }
            myp.EndDoc("打印预览");
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;


            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (je.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(je.Text, out oldf);

                    b2 = float.TryParse(je.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }

        }
        private void je_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(je.Text))
                {
                    yi.Text = null;
                    qianw.Text = null;
                    baiw.Text = null;
                    shiw.Text = null;
                    wan.Text = null;
                    qian.Text = null;
                    bai.Text = null;
                    shii.Text = null;
                    yuan.Text = null;
                    jiao.Text = null;
                    fen.Text = null;

                }
                else
                {
                    string aa = string.Format("{0:C}", Convert.ToDecimal(je.Text));
                    aa = aa.Replace(",", "");
                    aa = aa.Replace(".", "");
                    string[] st = St(aa);
                    yi.Text = st[10];
                    qianw.Text = st[9];
                    baiw.Text = st[8];
                    shiw.Text = st[7];
                    wan.Text = st[6];
                    qian.Text = st[5];
                    bai.Text = st[4];
                    shii.Text = st[3];
                    yuan.Text = st[2];
                    jiao.Text = st[1];
                    fen.Text = st[0];


                }
            }
            catch
            {

            }
        }
        Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();

        private async void button3_Click(object sender, EventArgs e)
        {
            args = await Task.Run(() => ReadArgs.button_Click());

            t11.Text = args.Name;
            t12.Text = "身份证";
            t13.Text = args.IDC;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            args = await Task.Run(() => ReadArgs.button_Click());
            t15.Text = args.Name;
            t16.Text = "身份证";
            t17.Text = args.IDC;
        }

        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            if (c1.Checked)
            {
                c2.Checked = false;
                c3.Checked = false; c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false; c9.Checked = false; c10.Checked = false; c11.Checked = false; c12.Checked = false;
                c13.Checked = false; c14.Checked = false; c15.Checked = false; c16.Checked = false;
                t19.Text = "";

            }

        }

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if (c2.Checked)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;



            }

        }

        private void c3_CheckedChanged(object sender, EventArgs e)
        {
            if(c3.Checked==true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false;
            }
        }

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked == true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c3.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false;
            }
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked == true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c4.Checked = false; c3.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false;
            }
        }

        private void c6_CheckedChanged(object sender, EventArgs e)
        {
            if (c6.Checked == true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c4.Checked = false; c5.Checked = false; c3.Checked = false; c7.Checked = false;
                c8.Checked = false;
            }
        }

        private void c7_CheckedChanged(object sender, EventArgs e)
        {
            if (c7.Checked == true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c4.Checked = false; c5.Checked = false; c6.Checked = false; c3.Checked = false;
                c8.Checked = false;
            }
        }

        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (c8.Checked == true)
            {
                c1.Checked = false;
                c14.Checked = false; c15.Checked = false; c16.Checked = false;
                c2.Checked = true;
                c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c3.Checked = false;

            }
        }

        private void c14_CheckedChanged(object sender, EventArgs e)
        {
            if (c14.Checked)
            {
                c2.Checked = false;
                c3.Checked = false; c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false; c9.Checked = false; c10.Checked = false; c11.Checked = false; c12.Checked = false;
                c13.Checked = false; c1.Checked = false; 
                t19.Text = "";

            }
        }

        private void c15_CheckedChanged(object sender, EventArgs e)
        {
            if (c15.Checked)
            {
                c2.Checked = false;
                c3.Checked = false; c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false; c9.Checked = false; c10.Checked = false; c11.Checked = false; c12.Checked = false;
                c13.Checked = false; c14.Checked = true; c1.Checked = false; c16.Checked = false;
                t19.Text = "";

            }
        }

        private void c16_CheckedChanged(object sender, EventArgs e)
        {
            if (c16.Checked)
            {
                c2.Checked = false;
                c3.Checked = false; c4.Checked = false; c5.Checked = false; c6.Checked = false; c7.Checked = false;
                c8.Checked = false; c9.Checked = false; c10.Checked = false; c11.Checked = false; c12.Checked = false;
                c13.Checked = false; c14.Checked = true; c1.Checked = false; c15.Checked = false;
                t19.Text = "";

            }
        }
    }
}
