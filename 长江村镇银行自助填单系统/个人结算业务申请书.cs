using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 长江村镇银行自助填单系统
{
    public partial class 个人结算业务申请书 : Form
    {
        public 个人结算业务申请书()
        {
            InitializeComponent();
        }
        string path = "print\\grjs.dat";
        private void 个人结算业务申请书_Load(object sender, EventArgs e)
        {
            yy.Text = dateTimePicker1.Value.Year.ToString();
            mm.Text = dateTimePicker1.Value.Month.ToString();
            dd.Text = dateTimePicker1.Value.Day.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            yy.Text = dateTimePicker1.Value.Year.ToString();
            mm.Text= dateTimePicker1.Value.Month.ToString();
            dd.Text= dateTimePicker1.Value.Day.ToString();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox6.Checked)
            {
                checkBox1.Checked=true;

            }
            else
            {
                checkBox1.Checked = false;
            }
            if (checkBox7.Checked)
            {
                checkBox2.Checked = true;

            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox2.Checked = true;

            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox3.Checked = true;

            }
            else
            {
                checkBox3.Checked = false;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox16.Text;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox4.Checked = true;

            }
            else
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                checkBox5.Checked = true;

            }
            else
            {
                checkBox5.Checked = false;
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            sqrcc.Text= textBox17.Text;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            sqrzh.Text = textBox18.Text;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            sqryt.Text = textBox19.Text;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            sqrdh.Text = textBox20.Text;
        }

        /// <summary>
        /// 金额转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox21.Text))
                {
                    jexx.Text = null;
                    jedx.Text = null;
                }
                else
                {
                    jexx.Text = string.Format("{0:C}",Convert.ToDecimal( textBox21.Text)); 
                    
                    jedx.Text = ConvertMoney.ConvertMoney.convertMoneytoRMB(Convert.ToDecimal(textBox21.Text)) + "整";

                }
            }
            catch
            {

            }
           
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;


            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox21.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox21.Text, out oldf);

                    b2 = float.TryParse(textBox21.Text + e.KeyChar.ToString(), out f);

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

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            skrcc.Text = textBox26.Text;
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            skrzh.Text = textBox25.Text;
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            hrhmc.Text = textBox24.Text;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            sheng.Text = textBox23.Text;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            shi.Text = textBox22.Text;
        }
        /// <summary>
        /// checkbox对号选择
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private  string Check(bool i)
        {
            string check;
            if (i==true)
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
      
        /// <summary>
        /// 小写金额11个
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private string[] St(string a)
        {
            string[] arr=new string[11];
            int ii = a.Length;
            if (ii < 12)
            {
                for (int i = 0; i < 11; i++)
                {
                    int start = ii - i;
                    if(start<1)
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
        private void button2_Click(object sender, EventArgs e)
        {
            
            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();
            //Font font1 = new Font("黑体", 12, FontStyle.Bold);
            //Font font2 = new Font("宋体", 10);

            //方框选择
            string check1,check2,check3,check4,check5;
            check1 = Check(checkBox1.Checked);
            check2 = Check(checkBox2.Checked);
            check3 = Check(checkBox3.Checked);
            check4 = Check(checkBox4.Checked);
            check5 = Check(checkBox5.Checked);
            //市县选择
            string check6 = RCheck(radioButton2.Checked);
            string check7 = RCheck(radioButton1.Checked);
            //小写金额位数
            string aa = jexx.Text;//小写金额去小数点
            aa = aa.Replace(",", "");
            aa = aa.Replace(".", "");
            int le=aa.Length;
            
            string[] st = St(aa);
              //str.Substring(start - 1, length));
            //打印数组
            string[] arr1 = { yy.Text,mm.Text,dd.Text,check1,check2,check3,textBox4.Text,check4,check5,
                sqrcc.Text,skrcc.Text, sqrzh.Text,skrzh.Text, sqryt.Text,hrhmc.Text, sqrdh.Text,sheng.Text,shi.Text,check6,check7,
            jedx.Text,st[10],st[9],st[8],st[7],st[6],st[5],st[4],st[3],st[2],st[1],st[0]};
            
            
            myp.NewPage();
            myp.IsImmediatePrintNotPreview = true;
            for (int i = 0; i < arr.Length; i++)
            {
                //定义字体                
                Font font = new Font(arr[i].Split(',')[1].ToString(),Convert.ToInt32( arr[i].Split(',')[2]));
                //打印起点
                string x = arr[i].Split(',')[3];
                string y = arr[i].Split(',')[4];
                //myp.Location = new Point(Convert.ToInt32(Convert.ToDecimal(x) * 10), Convert.ToInt32(Convert.ToDecimal(y) * 10));
                myp.Currentx = Convert.ToInt32(Convert.ToDecimal(x) * 10);
                myp.Currenty = Convert.ToInt32(Convert.ToDecimal(y) * 10);
                myp.DrawText(arr1[i], font);                
            }
            myp.EndDoc("打印预览");


        }
    }
}
