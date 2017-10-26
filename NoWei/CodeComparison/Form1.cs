using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeComparison
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioUp.Checked = false;
            radioDown.Checked = false;
            labdot5.Text = string.Format(@"5、接收器收到对码信号，保存发射器的编码，再按上下翻页键时，
    上方的按键测试区会有变化，表示对码成功。");
            
        }

        private void Btn_Exits_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            System.Environment.Exit(System.Environment.ExitCode);
            
        }
    }
}
