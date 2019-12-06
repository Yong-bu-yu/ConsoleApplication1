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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            展开关闭其他项ToolStripMenuItem.Click += 展开关闭其他项ToolStripMenuItem_Click;
            员工录入ToolStripMenuItem.Visible = false;
            添加用户ToolStripMenuItem.Visible = false;
            设置密码ToolStripMenuItem.Visible = false;
            修改密码ToolStripMenuItem.Visible = false;
            忘记密码ToolStripMenuItem.Visible = false;
            base.OnLoad(e);
        }
        bool flag = true;
        private void 展开关闭其他项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                员工录入ToolStripMenuItem.Visible = true;
                添加用户ToolStripMenuItem.Visible = true;
                设置密码ToolStripMenuItem.Visible = true;
                修改密码ToolStripMenuItem.Visible = true;
                忘记密码ToolStripMenuItem.Visible = true;
                flag = false;
            }
            else
            {
                员工录入ToolStripMenuItem.Visible = false;
                添加用户ToolStripMenuItem.Visible = false;
                设置密码ToolStripMenuItem.Visible = false;
                修改密码ToolStripMenuItem.Visible = false;
                忘记密码ToolStripMenuItem.Visible = false;
                flag = true;
            }
        }
    }
}
