using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Reg;

namespace 长江村镇银行自助填单系统
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //验证窗口
            //Model.regCheck regcheck = new Model.regCheck();
            //string mess = regcheck.Check();
            //if (mess == "1")
            //{
            //调整按钮大小
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            pictureBox1.Visible = true;
            int h = this.Height;
            int w = this.Width;
            button1.Location = new Point(w / 6, 3 * h / 12);
            button1.Width = w / 6;
            button1.Height = h / 6;
            button2.Location = new Point(4 * w / 6, 3 * h / 12);
            button2.Width = w / 6;
            button2.Height = h / 6;
            button3.Location = new Point(w / 6, 8 * h / 12);
            button3.Width = w / 6;
            button3.Height = h / 6;
            button4.Location = new Point(4 * w / 6, 8 * h / 12);
            button4.Width = w / 6;
            button4.Height = h / 6;
            button5.Location = new Point(5 * w / 12, 11 * h / 24);
            button5.Width = w / 6;
            button5.Height = h / 6;
            button6.Location = new Point(w/2,h/12);
            
            //LOGO调整
            pictureBox1.Load("logo\\LOGO.png");
            pictureBox1.Height = h / 12;
            pictureBox1.Width = 450 * h / 720;
            pictureBox1.Location = new Point(w / 2 - 450 * h / (720 * 2), h / 12);
            //}
            //else
            //{
            //MessageBox.Show(mess);
            //REG c = new REG();
            //c.Show();
            //}
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            个人结算业务申请书 c = new 个人结算业务申请书();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            个人客户开户申请书 c = new 个人客户开户申请书();
            c.Show();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            个人业务凭证_填单_ c = new 个人业务凭证_填单_();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            开立单位银行结算账户申请书 c = new 开立单位银行结算账户申请书();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            长江定存确认书 c = new 长江定存确认书();
            c.Show();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            打印位置调整 c = new 打印位置调整();
            c.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            借据 c = new 借据();
            c.Show();

        }
    }
}
