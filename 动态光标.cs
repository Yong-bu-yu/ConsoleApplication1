using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);

        [DllImport("user32.dll")]
        public static extern uint DestroyCursor(IntPtr cursorHandle);
        protected override void OnLoad(EventArgs e)
        {
            Label label = new Label();
            label.Size = new Size(100, 100);
            label.Location = new Point(0, 0);
            Controls.Add(label);
            label.Text = "改变鼠标";
            label.Click += Label_Click;
            base.OnLoad(e);
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Cursor myCursor = new Cursor(Cursor.Current.Handle);
            IntPtr colorCursorHandle = LoadCursorFromFile(@"C:\Windows\Cursors\aero_busy_xl.ani");
            //dinosau2.ani为windows自带的光标：
            myCursor.GetType().InvokeMember("handle", BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Instance |
            BindingFlags.SetField, null, myCursor,
            new object[] { colorCursorHandle });
            this.Cursor = myCursor;
        }
    }
}
