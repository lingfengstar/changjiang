using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReadArgs
    {
        static Com.FirstSolver.CardReader.ReadCardCompletedEventArgs args = new Com.FirstSolver.CardReader.ReadCardCompletedEventArgs();

        /// <summary>
        /// 读客户身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">读卡信息</param>
        static private void AddKehu(object sender, Com.FirstSolver.CardReader.ReadCardCompletedEventArgs arg)
        {
            args = arg;
        }
        static public async Task<Com.FirstSolver.CardReader.ReadCardCompletedEventArgs> button_Click()
        {
            //args = null;
            Com.FirstSolver.CardReader.YAReader reader = new Com.FirstSolver.CardReader.YAReader();
            reader.OnReadCardCompleted += AddKehu;
            await Task.Run(() => reader.Start());
            return args;
        }

    }

}

