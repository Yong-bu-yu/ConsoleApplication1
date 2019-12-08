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
        int i;
        protected override void OnLoad(EventArgs e)
        {
            i = -Size.Height;
            SetDesktopLocation(794, 0 - Size.Height);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer3.Tick += Timer3_Tick;
            base.OnLoad(e);
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position.Y==0)
            {
                timer1.Tick += Timer1_Tick;
            }
            else
            {
                timer2.Tick += Timer2_Tick;
            }
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position.Y != 0)
            {
                if (i > (-Size.Height))
                {
                    i -= 1;
                    SetDesktopLocation(794, i);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position.Y == 0)
            {
                if (i <= 0)
                {
                    i += 1;
                    SetDesktopLocation(794, i);
                }
            }
        }
    }
}
