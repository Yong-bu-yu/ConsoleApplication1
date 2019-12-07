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
        protected override void OnLoad(EventArgs e)
        {
            button1.Text = "设置";
            button2.Text = "打开";
            button3.Text = "编辑";
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);
            listView1.Items.Add("设置密码", "设置密码", 2);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            base.OnLoad(e);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button3.SendToBack();
            button3.Dock = DockStyle.Top;
            button2.SendToBack();
            button2.Dock = DockStyle.Top;
            button1.SendToBack();
            button1.Dock = DockStyle.Top;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("编辑工作进度报告", "编辑工作进度报告", 5);
            listView1.Items.Add("编辑项目设计图", "编辑项目设计图", 6);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button2.Dock = DockStyle.Top;
            button1.SendToBack();
            button1.Dock = DockStyle.Top;
            button3.Dock = DockStyle.Bottom;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("近期工作记录", "近期工作记录", 3);
            listView1.Items.Add("近期工作计划", "近期工作计划", 4);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button1.Dock = DockStyle.Top;
            button2.Dock = DockStyle.Bottom;
            button3.SendToBack();
            button3.Dock = DockStyle.Bottom;
            listView1.BringToFront();
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);
            listView1.Items.Add("设置密码", "设置密码", 2);
        }
    }
}
