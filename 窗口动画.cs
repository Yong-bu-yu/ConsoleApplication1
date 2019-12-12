using System;
using System.Web;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr handle, bool bInvert);
        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            AnimateWindow(Handle, 1000, 0x00040000 + 0x00000008 );
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            timer1.Tick += Timer1_Tick;
            base.OnLoad(e);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            FlashWindow(Handle, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TransparencyKey = BackColor;
            e.Graphics.FillRectangle(Brushes.BlueViolet, ClientRectangle);
            base.OnPaint(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AnimateWindow(Handle, 1000, 0x00040000 + 0x00000008 + 0x00010000);
            base.OnFormClosed(e);
        }
    }
}

//int AW_HOR_POSITIVE=0x00000001; 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略
//int AW_HOR_NEGATIVE=0x00000002; 自右向左显示窗口。当使用AW_CENTER标志时该标志被忽略
//int AW_VER_POSITIVE=0x00000004; 自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略
//int AW_VER_NEGATIVE=0x00000008; 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略
//int AW_CENTER=0x00000010; 若使用AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展
//int AW_HIDE=0x00010000; 隐藏窗口，默认为显示窗口
//int AW_ACTIVATE=0x00020000; 激活窗口。在使用AW_HIDE标志后不要使用此标志
//int AW_SLIDE=0x00040000; 使用滑动类型。默认为滚动动画类型。当使用AW_CENTER标志时，此标志就被忽略
//int AW_BLEND=0x00080000; 使用淡入效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
