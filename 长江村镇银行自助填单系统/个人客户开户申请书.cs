using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Model;
using System.IO;

namespace 长江村镇银行自助填单系统
{
    public partial class 个人客户开户申请书 : Form
    {
        public 个人客户开户申请书()
        {

            InitializeComponent();
        }
        string path = "print\\grkh.dat";
        //获取屏幕分辨率
        public int SH = Screen.PrimaryScreen.Bounds.Height;//高
        public int SW = Screen.PrimaryScreen.Bounds.Width;//宽

        private void 个人开户申请书_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //panel1.Height = SH;
            //panel1.Width = SW / 2;
            //pictureBox1.Height = SH;
            //pictureBox1.Width = SH * 210 / 297;
            //pictureBox1.Location = new Point(SW - pictureBox1.Width, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if (e.KeyChar == (char)46) e.KeyChar = (char)0;
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;
                }
            }
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxKeyPress(object sender, KeyPressEventArgs e, string textBox)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;


            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox, out oldf);

                    b2 = float.TryParse(textBox + e.KeyChar.ToString(), out f);

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
        /// radiocheck斜线选择
        /// </summary>
        /// <param name="i"></param>
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


        private void button2_Click(object sender, EventArgs e)
        {

            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();

            //方框选择
            string aa2, aa3, aa7, aa8, aa10, aa11, aa18, aa26, aa27, aa30, aa31, bb1, bb2, bb3, bb4, bb5, bb6, bb9, bb10, bb12, bb13, bb14, bb15,
                bb16, bb17, bb18, bb19, bb20, bb21, bb22, bb23, bb25, bb26, bb27, bb28, bb29, bb30, bb31, bb32, cc1, cc4, cc6, cc7, cc8, cc9, cc12,
                cc13, cc15, cc20, cc22, cc23, cc24, cc25, cc26, cc31;
            aa2 = Check(a2.Checked);
            aa3 = Check(a3.Checked);
            aa7 = Check(a7.Checked);
            aa8 = Check(a8.Checked);
            aa10 = Check(a10.Checked);
            aa11 = Check(a11.Checked);
            aa18 = Check(a18.Checked);
            aa26 = Check(a26.Checked);
            aa27 = Check(a27.Checked);
            aa30 = Check(a30.Checked);
            aa31 = Check(a31.Checked);
            bb1 = Check(b1.Checked);
            bb2 = Check(b2.Checked);
            bb3 = Check(b3.Checked);
            bb4 = Check(b4.Checked);
            bb5 = Check(b5.Checked);
            bb6 = Check(b6.Checked);
            bb9 = Check(b9.Checked);
            bb10 = Check(b10.Checked);
            bb12 = Check(b12.Checked);
            bb13 = Check(b13.Checked);
            bb14 = Check(b14.Checked);
            bb15 = Check(b15.Checked);
            bb16 = Check(b16.Checked);
            bb17 = Check(b17.Checked);
            bb18 = Check(b18.Checked);
            bb19 = Check(b19.Checked);
            bb20 = Check(b20.Checked);
            bb21 = Check(b21.Checked);
            bb22 = Check(b22.Checked);
            bb23 = Check(b23.Checked);
            bb25 = Check(b25.Checked);
            bb26 = Check(b26.Checked);
            bb27 = Check(b27.Checked);
            bb28 = Check(b28.Checked);
            bb29 = Check(b29.Checked);
            bb30 = Check(b30.Checked);
            bb31 = Check(b31.Checked);
            bb32 = Check(b32.Checked);
            cc1 = Check(c1.Checked);
            cc4 = Check(c4.Checked);
            cc6 = Check(c6.Checked);
            cc7 = Check(c7.Checked);
            cc8 = Check(c8.Checked);
            cc9 = Check(c9.Checked);
            cc12 = Check(c12.Checked);
            cc13 = Check(c13.Checked);
            cc15 = Check(c15.Checked);
            cc20 = Check(c20.Checked);
            cc22 = Check(c22.Checked);
            cc23 = Check(c23.Checked);
            cc24 = Check(c24.Checked);
            cc25 = Check(c25.Checked);
            cc26 = Check(c26.Checked);
            cc31 = Check(c31.Checked);

            //打印数组
            string[] arr1 = { a1.Text,aa2,aa3,a4.Text,a5.Text,a6.Text,aa7,aa8,a9.Text,aa10,aa11,a12.Text,
            a13.Text,a14.Text,a15.Text,a16.Text,a17.Text,aa18,a19.Text,a20.Text,a21.Text,a22.Text,a23.Text,
                a24.Text,a25.Text,aa26,aa27,a28.Text,a29.Text,aa30,aa31,a32.Text,a33.Text,a34.Text,bb1,bb2,bb3,
                bb4,bb5,bb6,b7.Text,b8.Text,bb9,bb10,b11.Text,bb12,bb13,bb14,bb15,bb16,bb17,bb18,bb19,bb20,bb21,
                bb22,bb23,b24.Text,bb25,bb26,bb27,bb28,bb29,bb30,bb31,bb32,cc1,c2.Text,c3.Text,cc4,c5.Text,cc6,
                cc7,cc8,cc9,c10.Text,c11.Text,cc12,cc13,c14.Text,cc15,c16.Text,c17.Text,c18.Text,c19.Text,cc20,
                c21.Text,cc22,cc23,cc24,cc25,cc26,c27.Text,c28.Text,c29.Text,c30.Text,cc31,c32.Text,c33.Text,c34.Text,
            c35.Text,c36.Text,c37.Text,c38.Text,c39.Text,c40.Text,c41.Text,c42.Text,c43.Text};


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
            this.TopMost = false;

            //myp.EndDoc("打印预览");
            if (MessageBox.Show("是否打印个税声明?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //myp.NewDoc();
                string tx1 = a1.Text;
                string tx2 = "身份证";
                string tx3 = a13.Text;
                string tx4 = ((char)8730).ToString();
                string[] arr11 = ReadTxt.ReadTxt.ReadTXT("print\\gssm.dat");
                string[] arr12 = { tx1, tx2, tx3, tx4 };
                myp.NewPage();
                myp.IsImmediatePrintNotPreview = true;
                for (int i1 = 0; i1 < arr11.Length; i1++)
                {
                    //定义字体
                    Font font1 = new Font(arr[i1].Split(',')[1].ToString(), Convert.ToInt32(arr[i1].Split(',')[2]));
                    //打印位置
                    string x1 = arr[i1].Split(',')[3];
                    string y1 = arr[i1].Split(',')[4];
                    //myp.Location = new Point(Convert.ToInt32(Convert.ToDecimal(x) * 10), Convert.ToInt32(Convert.ToDecimal(y) * 10));
                    myp.Currentx = Convert.ToInt32(Convert.ToDecimal(x1) * 10);
                    myp.Currenty = Convert.ToInt32(Convert.ToDecimal(y1) * 10);
                    myp.DrawText(arr12[i1], font1);

                }



                //delete

            }
            myp.EndDoc("打印预览");
            this.TopMost = true;



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                c4.Checked = true;
                c6.Checked = true;
                c9.Checked = true;
                c10.Text = "1";
                c11.Text = "1";
                c5.Text = a19.Text;

            }
            else
            {
                c4.Checked = false;
                c6.Checked = false;
                c9.Checked = false;
                c10.Text = null;
                c11.Text = null;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                c20.Checked = true;
                c26.Checked = true;
                c27.Text = "20";
                c28.Text = "5万";
                c29.Text = "5万";
                c30.Text = "1000万";
                c21.Text = a19.Text;
            }
            else
            {
                c20.Checked = false;
                c26.Checked = false;
                c27.Text = null;
                c28.Text = null;
                c29.Text = null;
                c30.Text = null;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                c15.Checked = true;
                c16.Text = "20";
                c17.Text = "100万";
                c18.Text = "100万";
                c19.Text = "1000万";

            }
            else
            {
                c15.Checked = false;
                c16.Text = null;
                c17.Text = null;
                c18.Text = null;
                c19.Text = null;
            }
        }

        private void a2_CheckedChanged(object sender, EventArgs e)
        {
            if (a2.Checked)
            {
                a3.Checked = false;
            }
        }

        private void a3_CheckedChanged(object sender, EventArgs e)
        {
            if (a3.Checked)
            {
                a2.Checked = false;
            }
        }

        private void a7_CheckedChanged(object sender, EventArgs e)
        {
            if (a7.Checked)
            {
                a8.Checked = false;
                a9.Enabled = false;
                a9.Text = null;
            }
        }

        private void a8_CheckedChanged(object sender, EventArgs e)
        {
            if (a8.Checked)
            {
                a7.Checked = false;
                a9.Enabled = true;
            }
        }

        private void a10_CheckedChanged(object sender, EventArgs e)
        {
            if (a10.Checked)
            {
                a11.Checked = false;
                a12.Enabled = false;
                a12.Text = null;
            }
        }

        private void a11_CheckedChanged(object sender, EventArgs e)
        {
            if (a11.Checked)
            {
                a10.Checked = false;
                a12.Enabled = true;
            }
        }

        private void a26_CheckedChanged(object sender, EventArgs e)
        {
            if (a26.Checked)
            {
                a27.Checked = false;
                a28.Enabled = false;
                a28.Text = null;
            }
        }

        private void a27_CheckedChanged(object sender, EventArgs e)
        {
            if (a27.Checked)
            {
                a26.Checked = false;
                a28.Enabled = true;
            }
        }

        private void b1_CheckedChanged(object sender, EventArgs e)
        {
            if (b1.Checked)
            {
                b2.Checked = false;
                b3.Checked = false;
                b4.Checked = false;
            }
        }

        private void b2_CheckedChanged(object sender, EventArgs e)
        {
            if (b2.Checked)
            {
                b1.Checked = false;
                b3.Checked = false;
                b4.Checked = false;
            }
        }

        private void b3_CheckedChanged(object sender, EventArgs e)
        {
            if (b3.Checked)
            {
                b2.Checked = false;
                b1.Checked = false;
                b4.Checked = false;
            }
        }

        private void b4_CheckedChanged(object sender, EventArgs e)
        {
            if (b4.Checked)
            {
                b2.Checked = false;
                b3.Checked = false;
                b1.Checked = false;
            }
        }

        private void b5_CheckedChanged(object sender, EventArgs e)
        {
            if (b5.Checked)
            {
                b6.Checked = false;
                b8.Text = null;

            }
        }

        private void b6_CheckedChanged(object sender, EventArgs e)
        {
            if (b6.Checked)
            {
                b5.Checked = false;
                b7.Text = null;

            }
        }

        private void b9_CheckedChanged(object sender, EventArgs e)
        {
            if (b9.Checked)
            {
                b10.Checked = false;
                b11.Enabled = false;
                b11.Text = null;
            }
        }

        private void b10_CheckedChanged(object sender, EventArgs e)
        {
            if (b10.Checked)
            {
                b9.Checked = false;
                b11.Enabled = true;

            }
        }

        private void b12_CheckedChanged(object sender, EventArgs e)
        {
            if (b12.Checked)
            {
                b13.Checked = false;
                b14.Checked = false;
                b15.Checked = false;
                b16.Checked = false;
            }
        }

        private void b13_CheckedChanged(object sender, EventArgs e)
        {
            if (b13.Checked)
            {
                b12.Checked = false;
                b14.Checked = false;
                b15.Checked = false;
                b16.Checked = false;
            }
        }

        private void b14_CheckedChanged(object sender, EventArgs e)
        {
            if (b14.Checked)
            {
                b13.Checked = false;
                b12.Checked = false;
                b15.Checked = false;
                b16.Checked = false;
            }
        }

        private void b15_CheckedChanged(object sender, EventArgs e)
        {
            if (b15.Checked)
            {
                b13.Checked = false;
                b12.Checked = false;
                b14.Checked = false;
                b16.Checked = false;
            }
        }

        private void b16_CheckedChanged(object sender, EventArgs e)
        {
            if (b16.Checked)
            {
                b13.Checked = false;
                b12.Checked = false;
                b15.Checked = false;
                b14.Checked = false;
            }
        }

        private void b17_CheckedChanged(object sender, EventArgs e)
        {
            if (b17.Checked)
            {
                b18.Checked = false;
                b19.Checked = false;

            }
        }

        private void b18_CheckedChanged(object sender, EventArgs e)
        {
            if (b18.Checked)
            {
                b17.Checked = false;
                b19.Checked = false;

            }
        }

        private void b19_CheckedChanged(object sender, EventArgs e)
        {
            if (b19.Checked)
            {
                b18.Checked = false;
                b17.Checked = false;

            }
        }

        private void b20_CheckedChanged(object sender, EventArgs e)
        {
            if (b20.Checked)
            {
                b21.Checked = false;
                b22.Checked = false;
                b23.Checked = false;
                b24.Enabled = false;
                b24.Text = null;

            }
        }

        private void b21_CheckedChanged(object sender, EventArgs e)
        {
            if (b21.Checked)
            {
                b20.Checked = false;
                b22.Checked = false;
                b23.Checked = false;
                b24.Enabled = false;
                b24.Text = null;
            }
        }

        private void b22_CheckedChanged(object sender, EventArgs e)
        {
            if (b22.Checked)
            {
                b21.Checked = false;
                b20.Checked = false;
                b23.Checked = false;
                b24.Enabled = false;
                b24.Text = null;
            }
        }

        private void b23_CheckedChanged(object sender, EventArgs e)
        {
            if (b23.Checked)
            {
                b21.Checked = false;
                b22.Checked = false;
                b20.Checked = false;
                b24.Enabled = true;

            }
        }

        private void b25_CheckedChanged(object sender, EventArgs e)
        {
            if (b25.Checked)
            {
                b26.Checked = false;
                b27.Checked = false;


            }
        }

        private void b26_CheckedChanged(object sender, EventArgs e)
        {
            if (b26.Checked)
            {
                b25.Checked = false;
                b27.Checked = false;


            }
        }

        private void b27_CheckedChanged(object sender, EventArgs e)
        {
            if (b27.Checked)
            {
                b25.Checked = false;
                b26.Checked = false;


            }
        }

        private void c6_CheckedChanged(object sender, EventArgs e)
        {
            if (c6.Checked)
            {
                c7.Checked = false;


            }
        }

        private void c7_CheckedChanged(object sender, EventArgs e)
        {
            if (c7.Checked)
            {
                c6.Checked = false;
            }
        }

        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (c8.Checked)
            {
                c9.Checked = false;
            }
        }

        private void c9_CheckedChanged(object sender, EventArgs e)
        {
            if (c9.Checked)
            {
                c8.Checked = false;
            }
        }

        private void c22_CheckedChanged(object sender, EventArgs e)
        {
            if (c22.Checked)
            {
                c23.Checked = false;
                c24.Checked = false;
            }
        }

        private void c23_CheckedChanged(object sender, EventArgs e)
        {
            if (c23.Checked)
            {
                c22.Checked = false;
                c24.Checked = false;
            }
        }

        private void c24_CheckedChanged(object sender, EventArgs e)
        {
            if (c24.Checked)
            {
                c22.Checked = false;
                c23.Checked = false;
            }
        }

        private void c25_CheckedChanged(object sender, EventArgs e)
        {
            if (c25.Checked)
            {
                c26.Checked = false;
            }
        }

        private void c26_CheckedChanged(object sender, EventArgs e)
        {
            if (c26.Checked)
            {
                c25.Checked = false;
            }
        }

        Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();



        /// <summary>
        /// 自动填入客户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                args = await Task.Run(() => ReadArgs.button_Click());
            }
            catch { }

            a1.Text = args.Name;
            if (args.Gender == "男") a2.Checked = true;
            if (args.Gender == "女") a3.Checked = true;
            a4.Text = Convert.ToDateTime(args.Birth).Year.ToString();
            a5.Text = Convert.ToDateTime(args.Birth).Month.ToString();
            a6.Text = Convert.ToDateTime(args.Birth).Day.ToString();
            a13.Text = args.IDC;
            a14.Text = args.EthnicName;
            a22.Text = args.Address;
            if (args.ValidDateEnd == "长期")
            { a18.Checked = true; }
            else
            {
                a15.Text = args.ValidDateEnd.Split('.')[0].ToString();
                a16.Text = args.ValidDateEnd.Split('.')[1].ToString();
                a17.Text = args.ValidDateEnd.Split('.')[2].ToString();
            }

        }

        private void a30_CheckedChanged(object sender, EventArgs e)
        {
            if (a30.Checked == true)
            {
                a31.Checked = false;
                a32.Enabled = false;
                a32.Text = null;
            }
        }

        private void a31_CheckedChanged(object sender, EventArgs e)
        {
            if (a31.Checked == true)
            {
                a30.Checked = false;
                a32.Enabled = true;
                //a32.Text = null;
            }
        }
        /// <summary>
        /// 自动添加代理人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                args = await Task.Run(() => ReadArgs.button_Click());
            }
            catch { }
            a25.Text = args.Name;
            a26.Checked = true;
            a30.Checked = true;
            a33.Text = args.IDC;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                b1.Checked = true;
                b12.Checked = true;
                b25.Checked = true;
                b28.Checked = true;
                b20.Checked = true;
                b31.Checked = true;

            }
            else
            {
                b1.Checked = false;
                b12.Checked = false;
                b25.Checked = false;
                b28.Checked = false;
                b20.Checked = false;
                b31.Checked = false;
            }
        }
    }

}
