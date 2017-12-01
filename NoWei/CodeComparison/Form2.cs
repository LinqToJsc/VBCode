using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CodeComparison
{
    public partial class Form2 : Form
    {
        //按键状态
        const int KEYEVENTF_EXTENDEDKEY = 1;
        const int KEYEVENTF_KEYUP = 2;

        //键值
        const int VK_NUMLOCK = 144;
        const int VK_CAPITAL = 20;
        const int VK_SCROLL = 145;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            radioUp.Checked = false;
            radioDown.Checked = false;
            labdot5.Text = @"5、接收器收到对码信号，保存发射器的编码，再按上下翻页键时，
    上方的按键测试区会有变化，表示对码成功。";

        }

        private void Btn_Exits_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            System.Environment.Exit(System.Environment.ExitCode);

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.PageUp:
        //            // radioUp.Checked = true;
        //            return false;
        //        case Keys.PageDown:
        //            return false;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}


        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.PageUp:
                    radioUp.Checked = true;
                    break;
                case Keys.PageDown:
                    radioDown.Checked = true;
                    break;
            }

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.PageUp:
                    radioUp.Checked = false;
                    radioDown.Checked = false;
                    break;
                case Keys.PageDown:
                    radioUp.Checked = false;
                    radioDown.Checked = false;
                    break;
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true,
            CallingConvention = CallingConvention.Winapi)]
        static extern short GetKeyState(int keyCode);

        /// <summary>
        /// 改变键状态
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("kernel32.dll")]
        static extern void Sleep(uint msec);


        private void Btn_CodeMacth_Click(object sender, EventArgs e)
        {
            if (GetKeyState(20) == 1)
            {
                Press_Caps_Lock();
            }

            if (GetKeyState(145) == 1)
            {
                Press_Scroll_Lock();
            }

            if (GetKeyState(144) == 1)
            {
                Press_Num_Lock();
            }

            Sleep(100);
            // 2, turn on CAPS LOCK,SCROLL LOCK, NUM LOCK
            Press_Caps_Lock();
            Press_Scroll_Lock();
            Press_Num_Lock();
            // 3, turn off CAPS LOCK, SCROLL LOCK
            Press_Caps_Lock();
            Press_Scroll_Lock();
            // 4, turn on CAPS LOCK, SCROLL LOCK
            Press_Caps_Lock();
            Press_Scroll_Lock();
            // 5, turn off all 3 keys
            Sleep(200);

            Press_Caps_Lock();
            Press_Scroll_Lock();
            Press_Num_Lock();
        }


        private void Press_Caps_Lock()
        {
            keybd_event(20, 0, 0, (UIntPtr)0); //  DOWN
            Sleep(100); // delay for 100 mS
            keybd_event(20, 0, 2, (UIntPtr)0); // UP
            Sleep(10); // delay for 10 mS
        }

        private void Press_Scroll_Lock()
        {
            keybd_event(145, 0, 0, (UIntPtr)0); // DOWN
            Sleep(100); // delay for 100 mS
            keybd_event(145, 0, 2, (UIntPtr)0);// UP
            Sleep(10); // delay for 10 mS
        }

        private void Press_Num_Lock()
        {
            keybd_event(144, 0, 0, (UIntPtr)0); // DOWN
            Sleep(100); // delay for 100 mS
            keybd_event(144, 0, 2, (UIntPtr)0);// UP
            Sleep(10); // delay for 10 mS
        }
    }
}
