using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thinput
{
    public partial class Form1 : Form
    {
        int x, y;
        public Form1()
        {
            InitializeComponent();
        }

        #region 后台按键获取

        Win32Api.KeyboardHook hk;
        protected override void OnLoad(EventArgs e)
        {
            this.Text = "thinpt";
            hk = new Win32Api.KeyboardHook();
            hk.SetHook();
            hk.OnKeyDownEvent += Hk_OnKeyDownEvent;
            hk.OnKeyUpEvent += Hk_OnKeyUpEvent;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            base.OnLoad(e);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Proce() == false)
            {
                this.Enabled = false;
                DialogResult=MessageBox.Show(null,"游戏未运行", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                Close();
            }
        }
        bool Proce()
        {
            Process[] process1 = Process.GetProcesses();
            string[] vs = { "th06", "th07", "th07_S", "th08", "th09", "th09c", "th10", "th10chs", "th10cht", "th11", "th11c", "th12", "th12c", "th13", "th13c", "th14", "th15", "th16" };
            for (int i = 0; i < process1.Length; i++)
            {
                for (int j = 0; j < vs.Length; j++)
                {
                    if (vs[j] == process1[i].ProcessName)
                    {
                        label1.Text = vs[j];
                        return true;
                    }
                }
            }
            return false;
        }

        private void Hk_OnKeyUpEvent(object sender, KeyEventArgs e)
        {
            Keys keys = e.KeyCode;
            switch (keys)
            {
                case Keys.Up:
                    Upper.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Down:
                    Down.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Left:
                    Lefts.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Right:
                    Right.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.ShiftKey:
                    Shift.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.ControlKey:
                    Ctrl.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Z:
                    Z.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.X:
                    X.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                default:
                    break;
            }
            label1.Text = "";
        }

        private void Hk_OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            Keys keys = e.KeyCode;
            switch (keys)
            {
                case Keys.Up:
                    Upper.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Upper";
                    break;
                case Keys.Down:
                    Down.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Down";
                    break;
                case Keys.Left:
                    Lefts.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Left";
                    break;
                case Keys.Right:
                    Right.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Right";
                    break;
                case Keys.ShiftKey:
                    Shift.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Shift";
                    break;
                case Keys.ControlKey:
                    Ctrl.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Ctrl";
                    break;
                case Keys.Z:
                    Z.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Z";
                    break;
                case Keys.X:
                    X.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "X";
                    break;
                case Keys.End:
                    Application.Exit();
                    break;
                case Keys.F1:
                    MessageBox.Show("本程序功能为按键反馈,东方系列游戏按键为上,下,左,右,Shift,Ctrl,Z,X,程序退出按键End键退出。");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 快捷菜单
        private void 关闭CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本程序功能为按键反馈,东方系列游戏按键为上,下,左,右,Shift,Ctrl,Z,X,程序退出按键End键退出。");
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.Keyboard)
            { e.Cancel = true; }
        }
        #endregion

        #region 按键获取
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Keys keys = e.KeyCode;
            switch (keys)
            {
                case Keys.Up:
                    Upper.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Upper";
                    break;
                case Keys.Down:
                    Down.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Down";
                    break;
                case Keys.Left:
                    Lefts.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Left";
                    break;
                case Keys.Right:
                    Right.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Right";
                    break;
                case Keys.ShiftKey:
                    Shift.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Shift";
                    break;
                case Keys.ControlKey:
                    Ctrl.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Ctrl";
                    break;
                case Keys.Z:
                    Z.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "Z";
                    break;
                case Keys.X:
                    X.Image = WindowsFormsApp1.Properties.Resources.key_down;
                    label1.Text = "X";
                    break;
                case Keys.End:
                    Application.Exit();
                    break;
                case Keys.F1:
                    MessageBox.Show("本程序功能为按键反馈,东方系列游戏按键为上,下,左,右,Shift,Ctrl,Z,X,程序退出按键End键退出。");
                    break;
                default:
                    break;
            }
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            Keys keys = e.KeyCode;
            switch (keys)
            {
                case Keys.Up:
                    Upper.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Down:
                    Down.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Left:
                    Lefts.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Right:
                    Right.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.ShiftKey:
                    Shift.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.ControlKey:
                    Ctrl.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.Z:
                    Z.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                case Keys.X:
                    X.Image = WindowsFormsApp1.Properties.Resources.key_up;
                    break;
                default:
                    break;
            }
            label1.Text = "";
            base.OnKeyUp(e);
        }
        #endregion

        #region 移动窗体
        /// <summary>
        /// 窗体移动
        /// </summary>
        /// <param name="e">移动窗体</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //    MessageBox.Show("帮助");
            x = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
            y = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += MousePosition.X - x;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - y;//根据鼠标的y坐标窗体的顶部，即Y坐标
                x = MousePosition.X;
                y = MousePosition.Y;
            }
            base.OnMouseMove(e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        #endregion

        #region 外部代码
        public class Win32Api
        {
            #region 常数和结构
            public const int WM_KEYDOWN = 0x100;
            public const int WM_KEYUP = 0x101;
            public const int WM_SYSKEYDOWN = 0x104;
            public const int WM_SYSKEYUP = 0x105;
            public const int WH_KEYBOARD_LL = 13;

            [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封送结构类型 
            public class KeyboardHookStruct
            {
                public int vkCode; //表示一个在1到254间的虚似键盘码 
                public int scanCode; //表示硬件扫描码 
                public int flags;
                public int time;
                public int dwExtraInfo;
            }
            #endregion
            #region Api
            public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
            //安装钩子的函数 
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

            //卸下钩子的函数 
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);

            //下一个钩挂的函数 
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

            [DllImport("user32")]
            public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

            [DllImport("user32")]
            public static extern int GetKeyboardState(byte[] pbKeyState);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
            #endregion

            public class KeyboardHook
            {
                int hHook;
                Win32Api.HookProc KeyboardHookDelegate;
                public event KeyEventHandler OnKeyDownEvent;
                public event KeyEventHandler OnKeyUpEvent;
                public event KeyPressEventHandler OnKeyPressEvent;
                public KeyboardHook() { }
                public void SetHook()
                {
                    KeyboardHookDelegate = new Win32Api.HookProc(KeyboardHookProc);
                    Process cProcess = Process.GetCurrentProcess();
                    ProcessModule cModule = cProcess.MainModule;
                    var mh = Win32Api.GetModuleHandle(cModule.ModuleName);
                    hHook = Win32Api.SetWindowsHookEx(Win32Api.WH_KEYBOARD_LL, KeyboardHookDelegate, mh, 0);
                }
                public void UnHook()
                {
                    Win32Api.UnhookWindowsHookEx(hHook);
                }
                private List<Keys> preKeysList = new List<Keys>();//存放被按下的控制键，用来生成具体的键
                private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
                {
                    //如果该消息被丢弃（nCode<0）或者没有事件绑定处理程序则不会触发事件
                    if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
                    {
                        Win32Api.KeyboardHookStruct KeyDataFromHook = (Win32Api.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.KeyboardHookStruct));
                        Keys keyData = (Keys)KeyDataFromHook.vkCode;
                        //按下控制键
                        if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN))
                        {
                            if (IsCtrlAltShiftKeys(keyData) && preKeysList.IndexOf(keyData) == -1)
                            {
                                preKeysList.Add(keyData);
                            }
                        }
                        //WM_KEYDOWN和WM_SYSKEYDOWN消息，将会引发OnKeyDownEvent事件
                        if (OnKeyDownEvent != null && (wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN))
                        {
                            KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));

                            OnKeyDownEvent(this, e);
                        }
                        //WM_KEYDOWN消息将引发OnKeyPressEvent 
                        if (OnKeyPressEvent != null && wParam == Win32Api.WM_KEYDOWN)
                        {
                            byte[] keyState = new byte[256];
                            Win32Api.GetKeyboardState(keyState);

                            byte[] inBuffer = new byte[2];
                            if (Win32Api.ToAscii(KeyDataFromHook.vkCode, KeyDataFromHook.scanCode, keyState, inBuffer, KeyDataFromHook.flags) == 1)
                            {
                                KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                                OnKeyPressEvent(this, e);
                            }
                        }
                        //松开控制键
                        if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP))
                        {
                            if (IsCtrlAltShiftKeys(keyData))
                            {
                                for (int i = preKeysList.Count - 1; i >= 0; i--)
                                {
                                    if (preKeysList[i] == keyData) { preKeysList.RemoveAt(i); }
                                }
                            }
                        }
                        //WM_KEYUP和WM_SYSKEYUP消息，将引发OnKeyUpEvent事件 
                        if (OnKeyUpEvent != null && (wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP))
                        {
                            KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));
                            OnKeyUpEvent(this, e);
                        }
                    }
                    return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
                }
                //根据已经按下的控制键生成key
                private Keys GetDownKeys(Keys key)
                {
                    Keys rtnKey = Keys.None;
                    foreach (Keys i in preKeysList)
                    {
                        if (i == Keys.LControlKey || i == Keys.RControlKey) { rtnKey = rtnKey | Keys.Control; }
                        if (i == Keys.LMenu || i == Keys.RMenu) { rtnKey = rtnKey | Keys.Alt; }
                        if (i == Keys.LShiftKey || i == Keys.RShiftKey) { rtnKey = rtnKey | Keys.Shift; }
                    }
                    return rtnKey | key;
                }

                private Boolean IsCtrlAltShiftKeys(Keys key)
                {
                    if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.LMenu || key == Keys.RMenu || key == Keys.LShiftKey || key == Keys.RShiftKey) { return true; }
                    return false;
                }
            }
        }
        #endregion
    }
}
