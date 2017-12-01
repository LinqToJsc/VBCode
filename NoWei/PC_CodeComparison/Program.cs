using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PC_CodeComparison
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            NorvayConfig.InitNorvayCode();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
