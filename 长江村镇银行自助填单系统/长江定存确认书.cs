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
    public partial class 长江定存确认书 : Form
    {
        public 长江定存确认书()
        {
            InitializeComponent();
        }
        string path = "print\\grcjdc.dat";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();

        private async void button3_Click(object sender, EventArgs e)
        {
            args = await Task.Run(() => ReadArgs.button_Click());
            t1.Text = args.Name;
            t3.Text = "身份证";
            t4.Text = args.IDC;
            t9.Text= args.Name;

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            args = await Task.Run(() => ReadArgs.button_Click());
            t5.Text = args.Name;
            t6.Text = "身份证";
            t7.Text = args.IDC;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();
            //方框选择
            string[] c = { Check(c1.Checked), Check(c2.Checked), Check(c3.Checked),
                Check(c4.Checked), Check(c5.Checked)};
            //小写金额位数
            string aa = je.Text;//小写金额去小数点
            aa =
            aa = aa.Replace(",", "");
            aa = aa.Replace(".", "");
            int le = aa.Length;

            string[] st = St(aa);
            //str.Substring(start - 1, length));
            //打印数组
            string[] arr1 = { t1.Text,t2.Text,t3.Text,t4.Text,t5.Text,t6.Text,
                t7.Text,c[0],c[1],c[2],c[3],c[4],t8.Text,shiyi.Text,yi.Text,qianwan.Text,
                baiwan.Text,shiwan.Text,wan.Text,qian.Text,bai.Text,shi.Text,yuan.Text,
                jiao.Text,fen.Text,t9.Text,t10.Text,t11.Text,t12.Text};


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

        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            if(c1.Checked==true)
            {
                c2.Checked = false;
                c3.Checked = false;
            }
        }
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
        /// <summary>
        /// 小写金额11个
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private string[] St(string a)
        {
            string[] arr = new string[12];
            int ii = a.Length;
            if (ii < 13)
            {
                for (int i = 0; i < 12; i++)
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

        private void je_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(je.Text))
                {
                    shiyi.Text = null;
                    yi.Text = null;
                    qianwan.Text = null;
                    baiwan.Text = null;
                    shiwan.Text = null;
                    wan.Text = null;
                    qian.Text = null;
                    bai.Text = null;
                    shi.Text = null;
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
                    shiyi.Text = st[11];
                    yi.Text = st[10];
                    qianwan.Text = st[9];
                    baiwan.Text = st[8];
                    shiwan.Text = st[7];
                    wan.Text = st[6];
                    qian.Text = st[5];
                    bai.Text = st[4];
                    shi.Text = st[3];
                    yuan.Text = st[2];
                    jiao.Text = st[1];
                    fen.Text = st[0];


                }
            }
            catch { }


    }

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if (c2.Checked == true)
            {
                c1.Checked = false;
                c3.Checked = false;
            }
        }

        private void c3_CheckedChanged(object sender, EventArgs e)
        {
            if (c3.Checked == true)
            {
                c2.Checked = false;
                c1.Checked = false;
            }
        }

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked == true)
            {
                c5.Checked = false;
            }
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked == true)
            {
                c4.Checked = false;
            }
        }

        private void 长江定存确认书_Load(object sender, EventArgs e)
        {
            //加载行名信息
            if(Config.ReadConfig())
            {
                t10.Text = Config.OrgName;
                t11.Text = Config.OrgName;
                t12.Text = Config.BranchName;
            }

            

        }
    }
}
