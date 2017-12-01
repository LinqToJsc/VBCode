using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PC_CodeComparison
{
    public partial class Form2 : Form
    {
        private TextBox[] TextKeys;
        private int[] TextKeyCodes = new[] { 33, 34, 9, 13, 116, 190 };

        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public const int WH_KEYBOARD = 2;
        public const int WH_KEYBOARD_LL = 13;

        //键盘消息
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        private const int KEY_CAPS_LOCK = 20;
        private const int KEY_NUM_LOCK = 144;
        private const int KEY_SCROLL_LOCK = 145;

        //委托   
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        static int hHook = 0;
        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。   
        static HookProc KeyBoardHookProcedure;

        public bool Shift_Press_Flag = false;
        public bool Alt_Press_Flag = false;
        public bool Mask_Input_Display = false;

        private bool Scroll_Lock_On_Flag;
        private bool Caps_Lock_On_Flag;
        private bool Num_Lock_On_Flag;

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

        //设置钩子   
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子   
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll")]
        //调用下一个钩子   
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        //获取键名的字符串
        [DllImport("user32", EntryPoint = "GetKeyNameText")]
        private static extern int GetKeyNameText(int lParam, StringBuilder lpBuffer, int nSize);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TextKeys = new[] { Text_Key1, Text_Key2, Text_Key3, Text_Key4, Text_Key5, Text_Key6 };
            Hook_Start();
        }


        private void Hook_Start()
        {
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //如果设置钩子失败.   
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        private void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
        }

        private int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            bool Key_Down_Flag = false;
            var keyName = string.Empty;
            int sKey = 0;
            if (nCode >= 0)
            {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                    Key_Down_Flag = true;
                else
                    Key_Down_Flag = false;

                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                sKey = kbh.scanCode & 0xff;
                sKey = sKey * 65536;
                StringBuilder strKeyName = new StringBuilder(255);
                if (GetKeyNameText(sKey, strKeyName, 255) > 0)
                    keyName = strKeyName.ToString().Trim(new char[] { ' ', '\0' });
                if (keyName.Length > 3 && keyName.Substring(0, 3) == "Num")
                {
                    sKey = sKey + 0x1000000;
                    if (GetKeyNameText(sKey, strKeyName, 255) > 0)
                        keyName = strKeyName.ToString().Trim(new char[] { ' ', '\0' });
                    //if (kbh.vkCode == 33 || kbh.vkCode == 105)
                    //    keyName = "Page Up";
                    //if (kbh.vkCode == 34 || kbh.vkCode == 99)
                    //    keyName = "Page Down";

                    //if (kbh.vkCode == 38 || kbh.vkCode == 104)
                    //    keyName = "Up";
                    //if (kbh.vkCode == 40 || kbh.vkCode == 98)
                    //    keyName = "Down";
                }
                Keys k = (Keys)Enum.Parse(typeof(Keys), kbh.vkCode.ToString());

                if (kbh.vkCode == (int)Keys.P || kbh.vkCode == (int)Keys.T)
                {
                    Mask_Input_Display = true;
                }

                if (Mask_Input_Display)
                {
                    if (Key_Down_Flag)
                    {
                        //124 [F4] is end flag of parameter input
                        if (kbh.vkCode == (int)Keys.F4)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (kbh.vkCode == (int)Keys.F4)
                            Mask_Input_Display = false;
                    }
                }
                else
                {
                    if (kbh.vkCode == (int)Keys.LShiftKey)
                    {
                        if (Key_Down_Flag)
                            Shift_Press_Flag = true;
                        else
                            Shift_Press_Flag = false;
                    }
                    if (kbh.vkCode == (int)Keys.LMenu) // k== L_Alt
                    {
                        if (Key_Down_Flag)
                            Alt_Press_Flag = true;
                        else
                            Alt_Press_Flag = false;
                    }

                    var Key_Action = "";
                    if (Key_Down_Flag)
                        Key_Action = "按：" + keyName + "   :" + DateTime.Now.ToString("HH:MM:ss,fff");
                    else
                        Key_Action = "放：" + keyName + "   :" + DateTime.Now.ToString("HH:MM:ss,fff");

                    OptListBox.Items.Add(Key_Action);
                    OptListBox.SelectedIndex = OptListBox.Items.Count - 1;
                    if (Key_Down_Flag == false && kbh.vkCode != (int)Keys.LShiftKey && kbh.vkCode != (int)Keys.LControlKey && kbh.vkCode != (int)Keys.LMenu)
                    {
                        OptListBox.Items.Add(" ");
                        OptListBox.SelectedIndex = OptListBox.Items.Count - 1;
                    }

                    if (Key_Down_Flag)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            var textKey = TextKeys[i];
                            textKey.BackColor = SystemColors.Window;
                            if (kbh.vkCode == TextKeyCodes[i])
                            {
                                
                                textKey.BackColor = Color.DarkRed;
                                textKey.Text = keyName;
                            }
                        }
                        // ESC for stop F5, share same button
                        if (kbh.vkCode == (int)Keys.Escape)
                            TextKeys[4].Text = "ESC";
                        // Shift + F5
                        if (kbh.vkCode == (int)Keys.F5 && Shift_Press_Flag && Key_Down_Flag)
                            TextKeys[4].Text = "Shift F5";
                        // Alt + Tab
                        if (kbh.vkCode == (int)Keys.Tab && Alt_Press_Flag && Key_Down_Flag)
                            TextKeys[2].Text = "Alt Tab";
                    }

                }
            }
            return 1;
            //return CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            //清对码
            Clear_Match_Code();
            //清屏
            cmdClear_Click();
        }

        private void Btn_ClearScreen_Click(object sender, EventArgs e)
        {
            cmdClear_Click();
        }

        private void Btn_Code_Click(object sender, EventArgs e)
        {
            //var t1 = DateTime.Now;
            Set_Match_Code();
            cmdClear_Click();
            //var t2 = DateTime.Now;

            //var t3 = t2 - t1;
            //OptListBox.Items.Add("一次对码执行完成用时 > " + t3.Seconds + "." + t3.Milliseconds);

        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Hook_Clear();
            this.Dispose();
            this.Close();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void cmdClear_Click()
        {
            OptListBox.Items.Clear();
            Text_Fs.Text = "";
            Text_Js.Text = "";
            Text_Dy.Text = "";

            for (int i = 0; i < TextKeys.Length; i++)
            {
                var textBox = TextKeys[i];
                textBox.Text = "按键" + (i + 1);
                textBox.BackColor = Color.White;
            }
        }

        //开始对码
        private void Set_Match_Code()
        {
            //卸钩子
            Hook_Clear();
            if (GetKeyState(145) == 1)
                Scroll_Lock_On_Flag = true;
            else
                Scroll_Lock_On_Flag = false;

            if (GetKeyState(20) == 1)
                Caps_Lock_On_Flag = true;
            else
                Caps_Lock_On_Flag = false;

            if (GetKeyState(144) == 1)
                Num_Lock_On_Flag = true;
            else
                Num_Lock_On_Flag = false;

            // 1, turn off all 3 keys, status = 0
            if (Scroll_Lock_On_Flag)
                Press_Scroll_Lock();

            if (Caps_Lock_On_Flag)
                Press_Caps_Lock();

            if (Num_Lock_On_Flag)
                Press_Num_Lock();

            Sleep(NorvayConfig.CodeSleep);

            // 2, turn on CAPS LOCK,SCROLL LOCK, NUM LOCK, status = 7
            Press_Caps_Lock();
            Press_Scroll_Lock();
            Press_Num_Lock();

            // 3, turn off CAPS LOCK, SCROLL LOCK, status = 1
            Press_Caps_Lock();
            Press_Scroll_Lock();

            // 4, turn on Caps LOCK, SCROLL LOCK, status = 7
            Press_Caps_Lock();
            Press_Scroll_Lock();

            // 5, turn off all 3 keys, status = 0
            Sleep(NorvayConfig.CodeSleep);

            Press_Caps_Lock();
            Press_Scroll_Lock();
            Press_Num_Lock();


            // ' 安装钩子
            Hook_Start();
        }

        private void Clear_Match_Code()
        {
            //卸钩子
            Hook_Clear();
            if (GetKeyState(145) == 1)
                Scroll_Lock_On_Flag = true;
            else
                Scroll_Lock_On_Flag = false;

            if (GetKeyState(20) == 1)
                Caps_Lock_On_Flag = true;
            else
                Caps_Lock_On_Flag = false;

            if (GetKeyState(144) == 1)
                Num_Lock_On_Flag = true;
            else
                Num_Lock_On_Flag = false;


            // 1, turn off all 3 keys, status = 0
            if (Scroll_Lock_On_Flag)
                Press_Scroll_Lock();

            if (Caps_Lock_On_Flag)
                Press_Caps_Lock();

            if (Num_Lock_On_Flag)
                Press_Num_Lock();

            Sleep(NorvayConfig.ClearCodeSleep);

            // 2, turn on SCROLL LOCK, NUM LOCK
            Press_Scroll_Lock();
            Press_Num_Lock();

            Sleep(NorvayConfig.ClearCodeSleep); //                            ' delay for 10 mS

            // 3, turn off SCROLL LOCK
            Press_Scroll_Lock();

            Sleep(NorvayConfig.ClearCodeSleep); //                            ' delay for 10 mS

            //' 4, turn on SCROLL LOCK
            Press_Scroll_Lock();

            Sleep(NorvayConfig.ClearCodeSleep); //                          ' delay for 10 mS

            // 5, turn off all keys
            Press_Scroll_Lock();
            Press_Num_Lock();

            // 安装钩子
            Hook_Start();
        }

        private void Press_Caps_Lock()
        {
            keybd_event(20, 0, 0, (UIntPtr)0); //  DOWN
            Sleep(10); // delay for 10 mS
            keybd_event(20, 0, 2, (UIntPtr)0); // UP
            Sleep(NorvayConfig.SampSleep); // delay for 30 mS
        }

        private void Press_Scroll_Lock()
        {
            keybd_event(145, 0, 0, (UIntPtr)0); // DOWN
            Sleep(10); // delay for 10 mS
            keybd_event(145, 0, 2, (UIntPtr)0);// UP
            Sleep(NorvayConfig.SampSleep); // delay for 50 mS
        }

        private void Press_Num_Lock()
        {
            keybd_event(144, 0, 0, (UIntPtr)0); // DOWN
            Sleep(10); // delay for 10 mS
            keybd_event(144, 0, 2, (UIntPtr)0);// UP
            Sleep(NorvayConfig.SampSleep); // delay for 50 mS
        }


        private void Handle_Input()
        {

        }
    }


}
