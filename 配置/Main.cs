using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JianKunKing.Log4NetTest;
using Model;

namespace 配置
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        ///设备接口类型：
        ///         1：设备为COM接口
        ///         2：设备为USB接口
        string iPort;
        string path = $"{Application.StartupPath}\\config.ini";//配置文件路径
        //string picpath;//LOGO图片路径
        string chname;//村行名称
        string zhname;//支行名称
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                chname = textBox1.Text;
                zhname = textBox3.Text;
                string[] arr = { chname, zhname, iPort };

                if (Config.WriteConfig(path, arr))
                {
                    MessageBox.Show("修改配置成功！");
                }
                else
                {
                    MessageBox.Show("请重试！");
                }
            }
            catch(Exception ex)
            {
                LogisTrac.WriteLog(typeof(Main), ex);

            }

        }
        private void Main_Load(object sender, EventArgs e)
        {
            
            if(Config.ReadConfig(path))
            {
                textBox1.Text = Config.OrgName;
                textBox3.Text = Config.BranchName;
                iPort = Config.Iport;
                if(iPort=="2")
                {
                    radioUSB.Checked=true;
                }
                else if(iPort=="1")
                {
                    radioCOM.Checked = true;
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioUSB.Checked)
            {
                iPort = "2";
            }
            else if(radioCOM.Checked)
            {
                iPort = "1";
            }
        }

        /// <summary>
        /// 设置LOGO文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.DefaultExt = "png";
            opendialog.Filter = "图片文件|*.png";
            //opendialog.ShowDialog();
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                string file = opendialog.FileName.ToString();
                if (File.Exists($"{Application.StartupPath}\\logo\\LOGO.png") == true)
                {
                    if( MessageBox.Show("目标文件夹已有此文件，是否覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk)==DialogResult.OK)
                    {
                        //复制
                        File.Copy(file, $"{Application.StartupPath}\\logo\\LOGO.png",true);
                        MessageBox.Show("LOGO设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        MessageBox.Show("替换LOGO文件不成功！");
                    }

                }
                else
                {
                    //复制
                    File.Copy(file, $"{Application.StartupPath}\\logo\\LOGO.png");
                    MessageBox.Show("LOGO设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
