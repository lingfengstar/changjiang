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
            b个人客户开户申请书.Visible = true;
            b个人业务凭证.Visible = true;
            b开立单位银行结算账户申请书.Visible = true;
            b长江定存.Visible = true;
            b借据.Visible = true;
            b个人客户签约申请书.Visible = true;
            pictureBox1.Visible = true;
            int h = this.Height;
            int w = this.Width;
            Point p1 = new Point(w / 6, 3 * h / 12);
            Point p2 = new Point(5*w/12, 3 * h / 12);
            Point p3 = new Point(4 * w / 6, 3 * h / 12);
            Point p4 = new Point(w / 6, 6 * h / 12);
            Point p5 = new Point(5 * w / 12, 6 * h / 12);
            Point p6 = new Point(4 * w / 6, 6 * h / 12);

            b个人客户开户申请书.Location = p1;
            b个人客户开户申请书.Width = w / 6;
            b个人客户开户申请书.Height = h / 6;
            b个人业务凭证.Location = p2;
            b个人业务凭证.Width = w / 6;
            b个人业务凭证.Height = h / 6;
            b开立单位银行结算账户申请书.Location = p3;
            b开立单位银行结算账户申请书.Width = w / 6;
            b开立单位银行结算账户申请书.Height = h / 6;
            b长江定存.Location = p4;
            b长江定存.Width = w / 6;
            b长江定存.Height = h / 6;
            b借据.Location =p5;
            b借据.Width = w / 6;
            b借据.Height = h / 6;
            b个人客户签约申请书.Location = p6;
            b个人客户签约申请书.Width = w / 6;
            b个人客户签约申请书.Height = h / 6;


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

        private void button7_Click(object sender, EventArgs e)
        {
            个人客户签约申请书 c = new 个人客户签约申请书();
            c.Show();

        }
    }
}
