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
    public partial class REG : Form
    {
        public REG()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void REG_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            ComputerInfo.ComputerInfo cpu = new ComputerInfo.ComputerInfo();
            string CPU = cpu.CPU;
            textBox1.Text = CPU;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            //写入注册码
            //验证注册码
            Reg.Reg.Register reg = new Reg.Reg.Register();
            reg.SubKey = "software\\Tiger\\";
            reg.WriteRegeditKey("TDReg",textBox2.Text);
                MessageBox.Show("注册成功，请退出重新打开软件！");
            }
            catch
            {
                MessageBox.Show("注册失败！");
            }
       
        }
    }
}
