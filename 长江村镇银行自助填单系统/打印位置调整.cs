using Model;
using System;
using System.Collections;
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
    public partial class 打印位置调整 : Form
    {
        public 打印位置调整()
        {
            InitializeComponent();
        }

        private void 打印位置调整_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedValueChanged -= new System.EventHandler(this.comboBox1_SelectedValueChanged);
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            DataRow dr4 = dt.NewRow();
            dr4["Id"] = "0";
            dr4["Name"] = "";
            dt.Rows.Add(dr4);
            DataRow dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Name"] = "个人客户开户申请书";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["Id"] = "2";
            dr1["Name"] = "个人结算业务申请书";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Id"] = "3";
            dr2["Name"] = "个人业务凭证（填单）";
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["Id"] = "4";
            dr3["Name"] = "开立单位银行结算账户申请书";
            dt.Rows.Add(dr3);
            DataRow dr5 = dt.NewRow();
            dr5["Id"] = "5";
            dr5["Name"] = "长江定存确认书（个人类）";
            dt.Rows.Add(dr5);
            DataRow dr6 = dt.NewRow();
            dr6["Id"] = "6";
            dr6["Name"] = "个税声明";
            dt.Rows.Add(dr6);
            DataRow dr7 = dt.NewRow();
            dr6["Id"] = "7";
            dr6["Name"] = "借据";
            dt.Rows.Add(dr7);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            //comboBox1.SelectedValue = "0";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //int aa = texList.textList.Count / 5;
            ArrayList arr=new ArrayList();
            int ii = 0;
            //textList list;
            for(int i=0;i<texList.textList.Count/5;i++)
            {
                ArrayList array = new ArrayList();
                for (int j = 0; j < 5; j++)
                {
                    string a = texList.textList[ii].ToString();
                    string txt = ((TextBox)(panel1.Controls.Find(a, false)[0])).Text;
                    array.Add(txt);
                    ii++;
                }
                string[] txtarr = (string[])array.ToArray(typeof(string));
                string tt = null;
                foreach (string str in txtarr)
                {

                    if (tt == null)
                    { tt = str; }
                    else { tt = tt + "," + str; }

                }
                arr.Add( tt);
            }
            string[] arrString = (string[])arr.ToArray(typeof(string));

            ReadTxt.ReadTxt.WriteTXT(path, arrString);
            MessageBox.Show("修改打印要素成功！");
        }
        //string[] controlName;
        //ArrayList List = new ArrayList();
        private void comSelect(string a)
        {
            try
            {
                panel1.Controls.Clear();
                string[] arr = ReadTxt.ReadTxt.ReadTXT(a);
                int xcur = 5;
                int ycur = 5;
                int locx=(panel1.Width-5)/ 5-10;
                int locy = 35;
                int N = arr.Length;
                ArrayList List=new ArrayList();
                //TextBox[][] textBoxes = new TextBox[N][];
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {

                        string txt = arr[i].Split(',')[j];
                        TextBox textBox = new TextBox();
                        textBox.Name = "textBox" + i + j;
                        List.Add(textBox.Name);
                        //controlName.Intersect(textBox.Name.ToString());
                        textBox.Text = txt;
                        textBox.Location = new Point(xcur + j * locx, ycur + i * locy);
                        panel1.Controls.Add(textBox);

                    }
                    /*
                    //转换string到font和fontstyle
                    FontConverter f = new FontConverter();
                    Font ffont = f.ConvertFromString(arr[i].Split(',')[1]) as Font;
                    FontStyle fsStyle = (FontStyle)Enum.Parse(typeof(FontStyle), arr[i].Split(',')[2]);
                    //定义字体
                    Font font = new Font(ffont,fsStyle) ;
                    */


                }
                texList.textList = List;
                //return;
            }
            catch { }



        }

        string path;
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string txt = null;
                switch (comboBox1.SelectedValue)
                {
                    case "1":
                        txt = "print\\grkh.dat";
                        break;
                    case "2":
                        txt = "print\\grjs.dat";
                        break;
                    case "3":
                        txt = "print\\grywpz.dat";
                        break;
                    case "4":
                        txt = "print\\dwkh.dat";
                        break;
                    case "5":
                        txt = "print\\grcjdc.dat";
                        break;
                    case "6":
                        txt = "print\\gssm.dat";
                        break;
                    case "7":
                        txt = "print\\jj.dat";
                        break;
                }
                if (txt != "0" || txt != null)
                {
                    comSelect(txt);
                    path = txt;
                }
                return;
            }
            catch
            {

            }


        }
    }
    public class texList
    {
        public static ArrayList textList;
    }
}
