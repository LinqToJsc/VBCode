using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_CodeComparison
{
    public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

    public partial class Form1 : Form
    {
        public const int WH_KEYBOARD = 2;
        public const int WH_KEYBOARD_LL = 13;

        //键盘消息
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        public struct KEYMSGS
        {
            public long vKey; //'虚拟码   (and &HFF)
            public long sKey; //'扫描码
            public long flag; //'键按下：128 抬起：0
            public long time; //'Window运行时间      
        }

        // 键盘虚拟码
        private const int KEY_TAB = 9;
        private const int KEY_ENTER = 13;
        private const int KEY_CAPS_LOCK = 20;
        private const int KEY_ESC = 27;
        private const int KEY_PGUP = 33;
        private const int KEY_PGDN = 34;
        private const int KEY_P = 80;
        private const int KEY_T = 84;
        private const int KEY_F4 = 115;
        private const int KEY_F5 = 116;
        private const int KEY_NUM_LOCK = 144;
        private const int KEY_SCROLL_LOCK = 145;
        private const int KEY_L_SHIFT = 160;
        private const int KEY_L_ALT = 164;
        private const int KEY_DOT = 190;

        private int lHook;

        public KEYMSGS keyMsg ;

        private bool Mask_Input_Display;

        private int Current_Bit;
        private int Key_On_Define;

        private long Input_Key;

        private string strKeyName;
        private long strLen;

        private bool Shift_Press_Flag;
        private bool Alt_Press_Flag;


        private HookProc KeyboardHookProcedure;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 改变键状态
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        static extern short GetKeyState(int keyCode);

        [DllImport("kernel32.dll")]
        static extern void Sleep(uint msec);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        //下一个钩挂的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        //获取键名的字符串
        [DllImport("user32", EntryPoint = "GetKeyNameText")]
        private static extern int GetKeyNameText(int lParam, StringBuilder lpBuffer, int nSize);

        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(int destination, int source, int length);

        private void Form1_Load(object sender, EventArgs e)
        {
            Text_Key2.Text = "GJJJ";
            Text_Key3.Text = "DKK";
            Text_Key2.BackColor = Color.DarkRed;
            OptListBox.Items.Add("的接口对接");
            OptListBox.Items.Add("");
            OptListBox.Items.Add("反对反对了解了");
            AddHook();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            DelHook();
            this.Dispose();
            this.Close();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Text_Key1.Text = "按键1";
            Text_Key1.BackColor = Color.White;
            Text_Key2.Text = "按键2";
            Text_Key2.BackColor = Color.White;
            Text_Key3.Text = "按键3";
            Text_Key3.BackColor = Color.White;
            Text_Key4.Text = "按键4";
            Text_Key4.BackColor = Color.White;
            Text_Key5.Text = "按键5";
            Text_Key5.BackColor = Color.White;
            Text_Key6.Text = "按键6";
            Text_Key6.BackColor = Color.White;
        }

        private void Btn_ClearScreen_Click(object sender, EventArgs e)
        {
            Text_Key1.Text = "按键1";
            Text_Key1.BackColor = Color.White;
            Text_Key2.Text = "按键2";
            Text_Key2.BackColor = Color.White;
            Text_Key3.Text = "按键3";
            Text_Key3.BackColor = Color.White;
            Text_Key4.Text = "按键4";
            Text_Key4.BackColor = Color.White;
            Text_Key5.Text = "按键5";
            Text_Key5.BackColor = Color.White;
            Text_Key6.Text = "按键6";
            Text_Key6.BackColor = Color.White;

            Text_Js.Text = "";
            Text_Fs.Text = "";
            Text_Dy.Text = "";

            OptListBox.Items.Clear();

        }

        private void Btn_Code_Click(object sender, EventArgs e)
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


        /// <summary>
        /// 安装钩子
        /// </summary>
        private void AddHook()
        {
            if (lHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                Process curProcess = Process.GetCurrentProcess();
                ProcessModule curModule = curProcess.MainModule;
                lHook = (int)SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure,
                    GetModuleHandle(curModule.ModuleName), 0);
                
            }
            
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        private void DelHook()
        {
            if (lHook != 0)
                UnhookWindowsHookEx((IntPtr)lHook);
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            int i;
            int sKey;
            int vKey;
            bool Key_Down_Flag;
            string Key_Action;


            if ((nCode >= 0))
            {
                //CopyMemory(keyMsg,lParam,len)

                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                    Key_Down_Flag = true;
                else
                    Key_Down_Flag = false;

                //sKey = keyMsg.sKey And &HFF;
                //sKey = sKey*65536;
                sKey = 0;
                strLen = GetKeyNameText(sKey, new StringBuilder("dsd"), 250);

            }
            return CallNextHookEx(lHook, nCode, wParam, lParam);
        }
    }
}
