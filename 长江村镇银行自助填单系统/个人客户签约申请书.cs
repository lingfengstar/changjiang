using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 长江村镇银行自助填单系统
{
    public partial class 个人客户签约申请书 : Form
    {
        public 个人客户签约申请书()
        {
            InitializeComponent();
        }
        string path = "print\\grkhqysqs.dat";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void 个人客户签约申请书_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();

            //打印数组
            string[] arr1 = {t1.Text,Check(c2.Checked), Check(c3.Checked),t4.Text,t5.Text,t6.Text,t7.Text,t8.Text,t9.Text,
            Check(c10.Checked),Check(c11.Checked),Check(c12.Checked),Check(c13.Checked),t14.Text,t15.Text,t16.Text,t17.Text,
            t18.Text,t19.Text,Check(c20.Checked),Check(c21.Checked),Check(c22.Checked),Check(c23.Checked),Check(c24.Checked),
            Check(c25.Checked),t26.Text,t27.Text,t28.Text,t29.Text,Check(c30.Checked),t31.Text,Check(c32.Checked),t33.Text,
            Check(c34.Checked),Check(c35.Checked),Check(c36.Checked),Check(c37.Checked),Check(c38.Checked),Check(c39.Checked),
            t40.Text,Check(c41.Checked),t42.Text,Check(c43.Checked),Check(c44.Checked),Check(c45.Checked),Check(c46.Checked),
            Check(c47.Checked),Check(c48.Checked),t49.Text,Check(c50.Checked),Check(c51.Checked),t52.Text,Check(c53.Checked),
            Check(c54.Checked),t55.Text, Check(c56.Checked),Check(c57.Checked),t58.Text,t59.Text,t60.Text,t61.Text,
            t62.Text,t63.Text,Check(c64.Checked),Check(c65.Checked),Check(c66.Checked),Check(c67.Checked),Check(c68.Checked),
            Check(c69.Checked),Check(c70.Checked),Check(c71.Checked),Check(c72.Checked),Check(c73.Checked),Check(c74.Checked),
            Check(c75.Checked),Check(c76.Checked),t77.Text, Check(c78.Checked),Check(c79.Checked),Check(c80.Checked),
            Check(c81.Checked),Check(c82.Checked),t83.Text,t84.Text,t85.Text,t86.Text,t87.Text,t88.Text,t89.Text,
            t90.Text,t91.Text,t92.Text,t93.Text,t94.Text,t95.Text,Check(c96.Checked),Check(c97.Checked),Check(c98.Checked),
            Check(c99.Checked),t100.Text,Check(c101.Checked),Check(c102.Checked),t103.Text,t104.Text,Check(c105.Checked),
            Check(c106.Checked),t107.Text,Check(c108.Checked),Check(c109.Checked),t110.Text,t111.Text};


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
        #region 自动选择checkbox
        private void c10_CheckedChanged(object sender, EventArgs e)
        {
            check(c10, c13);
        }

        private void c13_CheckedChanged(object sender, EventArgs e)
        {
            if(c13.Checked)
            {
                c10.Checked = false;
                c11.Checked = false;
                c12.Checked = false;
            }
        }

        private void c20_CheckedChanged(object sender, EventArgs e)
        {
            check(c20, c21);
        }

        private void c21_CheckedChanged(object sender, EventArgs e)
        {
            check(c21, c20);
        }
        /// <summary>
        /// 二选一选定
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void check(CheckBox a,CheckBox b)
        {
            if(a.Checked)
            {
                b.Checked = false;
            }
        }

        private void c22_CheckedChanged(object sender, EventArgs e)
        {
            check(c22, c23);
        }

        private void c23_CheckedChanged(object sender, EventArgs e)
        {
            check(c23, c22);
        }

        private void c24_CheckedChanged(object sender, EventArgs e)
        {
            check(c24, c25);
        }

        private void c25_CheckedChanged(object sender, EventArgs e)
        {
            check(c25, c24);
        }

        private void c41_CheckedChanged(object sender, EventArgs e)
        {
            check(c41, c48);
        }

        private void c48_CheckedChanged(object sender, EventArgs e)
        {
            check(c48, c41);
        }

        private void c46_CheckedChanged(object sender, EventArgs e)
        {
            check(c46, c47);
        }

        private void c47_CheckedChanged(object sender, EventArgs e)
        {
            check(c47, c46);
        }

        private void c43_CheckedChanged(object sender, EventArgs e)
        {
            check(c43, c44);
            check(c43, c45);
        }

        private void c44_CheckedChanged(object sender, EventArgs e)
        {
            check(c44, c43);
            check(c44, c45);
        }

        private void c45_CheckedChanged(object sender, EventArgs e)
        {
            check(c45, c43);
            check(c45, c44);
        }

        private void c50_CheckedChanged(object sender, EventArgs e)
        {
            check(c50, c51);
        }

        private void c51_CheckedChanged(object sender, EventArgs e)
        {
            check(c51, c50);
        }

        private void c53_CheckedChanged(object sender, EventArgs e)
        {
            check(c53, c54);
        }

        private void c54_CheckedChanged(object sender, EventArgs e)
        {
            check(c54, c53);
        }

        private void c56_CheckedChanged(object sender, EventArgs e)
        {
            check(c56, c57);
        }

        private void c57_CheckedChanged(object sender, EventArgs e)
        {
            check(c57, c56);
        }

        private void c64_CheckedChanged(object sender, EventArgs e)
        {
            check(c64, c65);
            check(c64, c66);
        }

        private void c65_CheckedChanged(object sender, EventArgs e)
        {
            check(c65, c64);
            check(c65, c66);
        }

        private void c66_CheckedChanged(object sender, EventArgs e)
        {
            check(c66, c64);
            check(c66, c65);
        }

        private void c67_CheckedChanged(object sender, EventArgs e)
        {
            check(c67, c68);
            check(c67, c69);
        }

        private void c68_CheckedChanged(object sender, EventArgs e)
        {
            check(c68, c67);
            check(c68, c69);
        }

        private void c69_CheckedChanged(object sender, EventArgs e)
        {
            check(c69, c67);
            check(c69, c68);
        }

        private void c78_CheckedChanged(object sender, EventArgs e)
        {
            check(c78, c79);
            check(c78, c80);
            check(c78, c81);
            check(c78, c82);
        }

        private void c79_CheckedChanged(object sender, EventArgs e)
        {
            check(c79, c78);
        }

        private void c96_CheckedChanged(object sender, EventArgs e)
        {
            check(c96, c97);
        }

        private void c97_CheckedChanged(object sender, EventArgs e)
        {
            check(c97, c96);
        }
        private void c98_CheckedChanged(object sender, EventArgs e)
        {
            check(c98, c99);
        }

        private void c99_CheckedChanged(object sender, EventArgs e)
        {
            check(c99, c98);
        }
        private void c101_CheckedChanged(object sender, EventArgs e)
        {
            check(c101, c102);
        }
        private void c102_CheckedChanged(object sender, EventArgs e)
        {
            check(c102, c101);
        }
        private void c105_CheckedChanged(object sender, EventArgs e)
        {
            check(c105, c106);
        }

        private void c106_CheckedChanged(object sender, EventArgs e)
        {
            check(c106, c105);
        }
        private void c108_CheckedChanged(object sender, EventArgs e)
        {
            check(c108, c109);
        }

        private void c109_CheckedChanged(object sender, EventArgs e)
        {
            check(c109, c108);
        }


        #endregion
        #region 自动勾选网银、手机银行、短信
        private void c网银_CheckedChanged(object sender, EventArgs e)
        {
            if(c网银.Checked)
            {
                c10.Checked = true;
                t26.Text = "20";
                t27.Text = "100万";
                t28.Text = "100万";
                t29.Text = "1000万";

;            }
            if(c网银.Checked==false)
            {
                c10.Checked = false;
                t26.Text = null;
                t27.Text = null;
                t28.Text = null;
                t29.Text = null;
            }
        }
        private void c短信_CheckedChanged(object sender, EventArgs e)
        {
            if(c短信.Checked)
            {
                c96.Checked = true;
                c99.Checked = true;
                t100.Text = t6.Text;
                c101.Checked = true;
                t103.Text = "1";
                t104.Text = "1";
            }
            if(c短信.Checked==false)
            {
                c96.Checked = false;
                c99.Checked = false;
                t100.Text = null;
                c101.Checked = false;
                t103.Text = null;
                t104.Text = null;
            }
        }

        private void c手机银行_CheckedChanged(object sender, EventArgs e)
        {
            if(c手机银行.Checked)
            {
                c41.Checked = true;
                t42.Text = t6.Text;
                c47.Checked = true;
                c50.Checked = true;
                t58.Text = "20";
                t59.Text = "50万";
                t60.Text = "100万";
                t61.Text = "1000万";
            }
            if(c手机银行.Checked==false)
            {
                c41.Checked = false;
                t42.Text = null;
                c47.Checked = false;
                c50.Checked = false;
                t58.Text = null;
                t59.Text = null;
                t60.Text = null;
                t61.Text = null;
            }
        }

        #endregion
        /// <summary>
        /// 自动填写账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t9_TextChanged(object sender, EventArgs e)
        {
            if(c网银.Checked)
            {
                t14.Text = t9.Text;
                    }
            if(c手机银行.Checked)
            {
                t49.Text = t9.Text;
            }
        }

        Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                args = await Task.Run(() => ReadArgs.button_Click());
            }
            catch { }
            t1.Text = args.Name;
            t5.Text = args.IDC;
            t8.Text = args.Address;
        }
    }
}
