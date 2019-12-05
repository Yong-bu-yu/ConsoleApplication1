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
            打开ToolStripMenuItem.Click += 打开ToolStripMenuItem_Click;
            StreamReader reader = new StreamReader("Menu.txt");
            int i = 文件ToolStripMenuItem.DropDownItems.Count;
            while (reader.Peek() >= 0)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem(reader.ReadLine());
                文件ToolStripMenuItem.DropDownItems.Insert(i, menuitem);
                i++;
                menuitem.Click += Menuitem_Click;
            }
            reader.Close();
            base.OnLoad(e);
        }

        private void Menuitem_Click(object sender, EventArgs e)
        {
            menuStrip1.Show();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();
            StreamWriter writer = new StreamWriter("Menu.txt", true);
            writer.WriteLine(openFileDialog.FileName);
            writer.Flush();
            writer.Close();
            ShowWindows(openFileDialog.FileName);
        }
        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);
            Form f = new Form();
            f.BackgroundImage = p;
            f.Show();
        }
    }
}
