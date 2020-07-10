using Model;
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

namespace 测试
{
    public partial class readIdCard : Form
    {
        //接收身份证信息的实体
        private clsEDZ objEDZ = new clsEDZ();

        //构造函数
        public readIdCard()
        {
            InitializeComponent();
        }

        //读卡
        private void button1_Click(object sender, EventArgs e)
        {
            usbIdCard();
        }

        private void usbIdCard()
        {
            //声明变量
            DialogResult dr;
            int iRet = 0x90;          //返回码
            int iPort = 1;          //端口号
            int iIfOpen = 1;             //是否需要打开端口
            byte[] pubManaInfo = new byte[255];    //身份证管理号信息
            byte[] pubManaMsg = new byte[255];    //
            byte[] pubCHMsg = new byte[512];  //文字信息
            byte[] pubPHMsg = new byte[3024]; //照片信息
            byte[] pubFPMsg = new byte[1024]; //指纹信息
            UInt32 puiCHMsgLen = 0;              //文字信息的长度
            UInt32 puiPHMsgLen = 0;              //照片信息的长度

            //打开端口
            if (iIfOpen == 0)
            {
                iRet = DllMoudle.SDT_OpenPort(iPort);
                //若打开端口不成功
                if (iRet != 0x90)
                {
                    MessageBox.Show("SDT_OpenPort Error,Error Code Is: " + iRet);
                    //关闭端口
                    DllMoudle.SDT_ClosePort(iPort);
                    return;
                }
            }

            //找卡
            do
            {
                //开始找卡
                iRet = DllMoudle.SDT_StartFindIDCard(iPort, pubManaInfo, iIfOpen);

                if (iRet == 0x9f)
                {
                    //找到之后，选择卡
                    iRet = DllMoudle.SDT_SelectIDCard(iPort, pubManaMsg, iIfOpen);
                    if (iRet == 0x90)
                    {
                        break;
                    }
                }

                //若找不到卡，提示
                dr = MessageBox.Show("尚未找到卡，您是否想继续找卡？", "找卡提示",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            //一直找卡，直到取消找卡
            while (dr == DialogResult.Yes);

            //读卡信息
            iRet = DllMoudle.SDT_ReadBaseMsg(iPort, pubCHMsg, ref puiCHMsgLen, pubPHMsg, ref puiPHMsgLen, iIfOpen);
            if (iRet != 0x90)
            {
                //不成功，关闭端口,退出
                MessageBox.Show("SDT_ReadBaseMsg Error,Error Code Is: " + iRet);
                closePort(iPort, iIfOpen);
                return;
            }

            //读卡成功
            //显示结果集
            textBox1.Text = System.Text.ASCIIEncoding.Unicode.GetString(pubCHMsg);

            //注意，在这里，用户必须有应用程序当前目录的读写权限
            //删除掉这些文件
            FileInfo objFile = new FileInfo("wz.txt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.bmp");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.wlt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }

            //将基本信息写到wz.txt中，将照片信息写到zp.wlt文件中
            iRet = DllMoudle.SDT_ReadBaseMsgToFile(iPort, "wz.txt", ref puiCHMsgLen, "zp.wlt", ref puiPHMsgLen, iIfOpen);
            if (iRet != 144)
            {
                iRet = DllMoudle.SDT_ClosePort(iPort);
                MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //下面解析照片，注意，如果在C盘根目录下没有机具厂商的授权文件Termb.Lic，照片解析将会失败
            //用2表示usb口，1表示串口。将zp.wlt转换为照片zp.bmp。
            bool falg = true;
            if (falg)
                iRet = DllMoudle.GetBmp("zp.wlt", 2);
            else
                iRet = DllMoudle.GetBmp("zp.wlt", 1);
            switch (iRet)
            {
                case 0:
                    MessageBox.Show("调用sdtapi.dll错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:   //正常
                    break;
                case -1:
                    MessageBox.Show("相片解码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("wlt文件后缀错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -3:
                    MessageBox.Show("wlt文件打开错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -4:
                    MessageBox.Show("wlt文件格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -5:
                    MessageBox.Show("软件未授权！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -6:
                    MessageBox.Show("设备连接错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            //如果照片解析成功，则将照片，将从wz.txt中的内容赋值给二进制的bt
            iRet = DllMoudle.SDT_ClosePort(iPort);
            FileInfo f = new FileInfo("wz.txt");
            FileStream fs = f.OpenRead();
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, (int)fs.Length);
            fs.Close();

            //然后根据位数分割，获取到相应的值，前30为是姓名，31-32是性别的编码。等等依次类推
            objEDZ.Name = System.Text.UnicodeEncoding.Unicode.GetString(bt, 0, 30).Trim();
            objEDZ.Sex_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 30, 2).Trim();
            objEDZ.NATION_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 32, 4).Trim();
            string strBird = System.Text.UnicodeEncoding.Unicode.GetString(bt, 36, 16).Trim();
            objEDZ.BIRTH = Convert.ToDateTime(strBird.Substring(0, 4) + "年" + strBird.Substring(4, 2) + "月" + strBird.Substring(6) + "日");
            objEDZ.ADDRESS = System.Text.UnicodeEncoding.Unicode.GetString(bt, 52, 70).Trim();
            objEDZ.IDC = System.Text.UnicodeEncoding.Unicode.GetString(bt, 122, 36).Trim();
            objEDZ.REGORG = System.Text.UnicodeEncoding.Unicode.GetString(bt, 158, 30).Trim();
            string strTem = System.Text.UnicodeEncoding.Unicode.GetString(bt, 188, bt.GetLength(0) - 188).Trim();
            objEDZ.STARTDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            strTem = strTem.Substring(8);
            if (strTem.Trim() != "长期")
            {
                objEDZ.ENDDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            }
            else
            {
                objEDZ.ENDDATE = DateTime.MaxValue;
            }

            //找到zp.bmp照片
            objFile = new FileInfo("zp.bmp");
            //若找存在，则将照片通过文件流中督考imgbyte的二进制中，然后用Memorystream流中创建图片Image，
            //放到身份证的Image照片上；而imgbyte则放到照片的二进制中。最后将图片和memorystream都摧毁。
            if (objFile.Exists)
            {
                FileStream fss = new FileStream("zp.bmp", FileMode.Open);
                byte[] imgbyte = new byte[(int)objFile.Length];
                fss.Read(imgbyte, 0, (int)objFile.Length);
                fss.Close();
                MemoryStream ms = new MemoryStream(imgbyte);
                Image img = Image.FromStream(ms);
                objEDZ.PIC_Image = (Image)img.Clone();
                objEDZ.PIC_Byte = imgbyte;
                img.Dispose();
                ms.Dispose();
            }

            //最后界面显示值和照片
            textBox1.Text = textBox1.Text + objEDZ.Name + objEDZ.Sex_Code + objEDZ.NATION_Code + objEDZ.BIRTH + objEDZ.ADDRESS + objEDZ.IDC + objEDZ.REGORG + objEDZ.STARTDATE + objEDZ.ENDDATE;
            pictureBox1.Image = objEDZ.PIC_Image;

        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="iPort">端口号</param>
        /// <param name="iIfOpen">是否开启</param>
        private void closePort(int iPort, int iIfOpen)
        {
            if (iIfOpen == 0)
            {
                DllMoudle.SDT_ClosePort(iPort);
            }
        }

        private void readIdCard_Load(object sender, EventArgs e)
        {

        }
    }
}
