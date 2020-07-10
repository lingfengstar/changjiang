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

        private void je_TextChanged(object sender, EventArgs e)
        {
            try
                {
                if (string.IsNullOrEmpty(je.Text))
                {
                    tyi.Text = null;
                    tqwan.Text = null;
                    tbwan.Text = null;
                    tswan.Text = null;
                    twan.Text = null;
                    tqian.Text = null;
                    tbai.Text = null;
                    tshi.Text = null;
                    tyuan.Text = null;
                    tjiao.Text = null;
                    tfen.Text = null;

                }
                else
                {
                    string aa = string.Format("{0:C}", Convert.ToDecimal(je.Text));
                    aa = aa.Replace(",", "");
                    aa = aa.Replace(".", "");
                    string[] st = St(aa);
                    tyi.Text = st[10];
                    tqwan.Text = st[9];
                    tbwan.Text = st[8];
                    tswan.Text = st[7];
                    twan.Text = st[6];
                    tqian.Text = st[5];
                    tbai.Text = st[4];
                    tshi.Text = st[3];
                    tyuan.Text = st[2];
                    tjiao.Text = st[1];
                    tfen.Text = st[0];

                    tjkjedx.Text = ConvertMoney.ConvertMoney.convertMoneytoRMB(Convert.ToDecimal(je.Text));
                }
            }
            catch
            {

            }
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
        /// 限制输入类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void je_KeyPress(object sender, KeyPressEventArgs e)
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

        private void 个人客户签约申请书_Load(object sender, EventArgs e)
        {
            tyear.Text = dateTimePicker1.Value.Year.ToString();
            tmonth.Text = dateTimePicker1.Value.Month.ToString();
            tday.Text = dateTimePicker1.Value.Day.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] arr = ReadTxt.ReadTxt.ReadTXT(path);
            VBprinter.VB2008Print myp = new VBprinter.VB2008Print();
            myp.PageUnits = VBprinter.VB2008Print.PageExportUnit.CentiMeter; //以百分之一厘米为单位
            myp.PaperMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            myp.NewDoc();

            //小写金额位数
            string aa = je.Text;//小写金额去小数点
            
            aa = aa.Replace(",", "");
            aa = aa.Replace(".", "");
            int le = aa.Length;

            string[] st = St(aa);
            //str.Substring(start - 1, length));
            //打印数组
            string[] arr1 = { tyear.Text,tmonth.Text,tday.Text,tjkr.Text,tjjbh.Text,tjkrsfzh.Text,tdkzkh.Text,tdkzh.Text,tskzh.Text,
            thkzh1.Text,thkzh2.Text,tjkjedx.Text,tyi.Text,tqwan.Text,tbwan.Text,tswan.Text,twan.Text,tqian.Text,tbai.Text,tshi.Text,
            tyuan.Text,tjiao.Text,tfen.Text,tyongtu.Text,tlilv.Text,tdkfs.Text,tjkhth.Text,tdbhth.Text,tjknian.Text,tjkyue.Text,tjkri.Text,
            tdqnian.Text,tdqyue.Text,tdqri.Text,tzqnian.Text,tzqyue.Text,tzqri.Text};


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
    }
}
