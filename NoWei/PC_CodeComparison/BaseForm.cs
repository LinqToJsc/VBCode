using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_CodeComparison
{
    public class BaseForm : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Right;
            public int left;
            public int Top;
            public int Bottom;
        }
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        protected override void OnLoad(EventArgs e)
        {
            //如果启用Aero
            if (DwmIsCompositionEnabled())
            {
                MARGINS margins = new MARGINS();
                margins.left = -1;
                margins.Right = -1;
                margins.Top = -1;
                margins.Bottom = -1;
                DwmExtendFrameIntoClientArea(this.Handle, ref margins); //开启全窗体透明效果
            }
            base.OnLoad(e);
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);
        //    if (DwmIsCompositionEnabled())
        //    {
        //        e.Graphics.Clear(Color.White); //将窗体用黑色填充（Dwm 会把黑色视为透明区域）
        //    }
        //}
    }
}
