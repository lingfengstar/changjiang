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
    public partial class 开立单位银行结算账户申请书 : Form
    {
        public 开立单位银行结算账户申请书()
        {
            InitializeComponent();
        }
        string path = "print\\dwkh.dat";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string  cc1, cc2, cc3, cc4, cc5, cc6, cc7,cc8, cc9, cc10, cc11;
            cc1 = Check(c1.Checked);
            cc2 = Check(c2.Checked);
            cc3 = Check(c3.Checked);
            cc4 = Check(c4.Checked);
            cc5 = Check(c5.Checked);
            cc6 = Check(c6.Checked);
            cc7 = Check(c7.Checked);
            cc8 = Check(c8.Checked);
            cc9 = Check(c9.Checked);
            cc10 = Check(c10.Checked);
            cc11 = Check(c11.Checked);

            //打印数组
            string[] arr1 = { t1.Text,t2.Text,t3.Text, t4.Text, t5.Text, t6.Text, t7.Text, t8.Text,
                cc1,cc2,t9.Text, t10.Text, t11.Text, t12.Text, t13.Text, t14.Text, t15.Text, t16.Text,
                t17.Text, t18.Text, t19.Text, t20.Text, t21.Text, t22.Text, t23.Text, t24.Text, t25.Text,
                t26.Text, t27.Text, t28.Text, cc3,cc4,cc5,cc6,cc7,cc8,cc9,t29.Text, t30.Text, t31.Text,
                t32.Text, t33.Text, t34.Text, t35.Text, t36.Text,cc10,cc11, t37.Text, t38.Text, t39.Text,
                t40.Text, t41.Text, t42.Text, t43.Text, t44.Text, t45.Text };


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
            }
        }

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if (c2.Checked == true)
            {
                c1.Checked = false;
            }
        }

        private void c3_CheckedChanged(object sender, EventArgs e)
        {
            if (c3.Checked == true)
            {
                c4.Checked = false;
                c5.Checked = false;
                c6.Checked = false;
            }
        }

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked == true)
            {
                c3.Checked = false;
                c5.Checked = false;
                c6.Checked = false;
            }
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked == true)
            {
                c4.Checked = false;
                c3.Checked = false;
                c6.Checked = false;
            }
        }

        private void c6_CheckedChanged(object sender, EventArgs e)
        {
            if (c6.Checked == true)
            {
                c4.Checked = false;
                c5.Checked = false;
                c3.Checked = false;
            }
        }

        private void c7_CheckedChanged(object sender, EventArgs e)
        {
            if (c7.Checked == true)
            {
                c8.Checked = false;
                c9.Checked = false;
                t29.Text=null;
                t29.Enabled = false;
            }
        }

        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (c8.Checked == true)
            {
                c9.Checked = false;
                c7.Checked = false;
                t29.Text = null;
                t29.Enabled = false;
            }
        }

        private void c9_CheckedChanged(object sender, EventArgs e)
        {
            if (c9.Checked == true)
            {
                c8.Checked = false;
                c7.Checked = false;
                //t29.Text = null;
                t29.Enabled = true;
            }
        }

        private void c10_CheckedChanged(object sender, EventArgs e)
        {
            if (c10.Checked)
            {
                c11.Checked = false;
            }
        }

        private void c11_CheckedChanged(object sender, EventArgs e)
        {
            if (c11.Checked)
            {
                c10.Checked = false;
            }
        }
        Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();

        private async void button3_Click(object sender, EventArgs e)
        {
            args = await Task.Run(() => ReadArgs.button_Click());
            t9.Text = args.Name;
            t10.Text = "身份证";
            t11.Text = args.IDC;
        }

        private void 开立单位银行结算账户申请书_Load(object sender, EventArgs e)
        {

        }
    }
}
