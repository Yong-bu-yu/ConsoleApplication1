using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        protected override void OnLoad(EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer1.Tick += Timer1_Tick;
            timer2.Tick += Timer2_Tick;
            base.OnLoad(e);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Alternate);
            graphicsPath.AddEllipse(new RectangleF(pictureBox2.ClientRectangle.X + 15, pictureBox2.ClientRectangle.Y + 15, pictureBox2.ClientRectangle.Width - 30, pictureBox2.ClientRectangle.Height - 30));
            Region region = new Region(graphicsPath);
            pictureBox2.Invalidate(region);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer();
        }

        void Timer()
        {
            int s = DateTime.Now.Second, m = DateTime.Now.Minute, h = DateTime.Now.Hour;
            label1.Text = "时间：" + DateTime.Now.ToString();
            Pen pen = new Pen(Color.LightSteelBlue, 6);
            g = pictureBox2.CreateGraphics();
            Pen myPen = new Pen(Color.LightSlateGray, 3);
            Point Cpoint = new Point(pictureBox2.ClientRectangle.Width / 2, pictureBox2.ClientRectangle.Height / 2);
            Point Spoint = new Point((int)(Cpoint.X + (Math.Sin(6 * DateTime.Now.Second * Math.PI / 180)) * 90), (int)(Cpoint.Y - (Math.Cos(6 * DateTime.Now.Second * Math.PI / 180)) * 90));
            Point Mpoint = new Point((int)(Cpoint.X + (Math.Sin(6 * DateTime.Now.Minute * Math.PI / 180)) * 65), (int)(Cpoint.Y - (Math.Cos(6 * DateTime.Now.Minute * Math.PI / 180)) * 65));
            Point Hpoint = new Point((int)(Cpoint.X + (Math.Sin(30 * DateTime.Now.Hour * Math.PI / 180)) * 45), (int)(Cpoint.Y - (Math.Cos(30 * DateTime.Now.Hour * Math.PI / 180)) * 45));
            //g.Clear(BackColor);
            g.DrawEllipse(pen, new RectangleF(new PointF(3, 3), new SizeF(pictureBox2.Size.Width - 9, pictureBox2.Height - 9)));
            g.DrawEllipse(myPen, new RectangleF(new PointF(3, 3), new SizeF(pictureBox2.Size.Width - 6, pictureBox2.Height - 6)));
            g.DrawLine(myPen, new Point((int)(Cpoint.X + (Math.Sin(6 * DateTime.Now.Second * Math.PI / 180)) * 112), (int)(Cpoint.Y - (Math.Cos(6 * DateTime.Now.Second * Math.PI / 180)) * 112)), new Point((int)(Cpoint.X + (Math.Sin(6 * DateTime.Now.Second * Math.PI / 180)) * 100), (int)(Cpoint.Y - (Math.Cos(6 * DateTime.Now.Second * Math.PI / 180)) * 100)));
            Point point = new Point(Cpoint.X + 3, Cpoint.Y + 3);
            g.DrawLine(pen, point, Spoint);
            g.DrawLine(pen, point, Mpoint);
            g.DrawLine(pen, point, Hpoint);
            g.DrawLine(new Pen(Brushes.IndianRed,3), Cpoint, Spoint);
            g.DrawLine(new Pen(Brushes.CornflowerBlue,3), Cpoint, Mpoint);
            g.DrawLine(new Pen(Brushes.Black,3), Cpoint, Hpoint);
            g.DrawString(s.ToString(), new Font(FontFamily.GenericMonospace, 9, FontStyle.Bold, GraphicsUnit.Point, new byte(), false), Brushes.IndianRed, new PointF(Spoint.X - 9, Spoint.Y - 9));
            g.DrawString(m.ToString(), new Font(FontFamily.GenericMonospace, 9, FontStyle.Bold, GraphicsUnit.Point, new byte(), false), Brushes.CornflowerBlue, new PointF(Mpoint.X - 12, Mpoint.Y - 12));
            g.DrawString(h.ToString(), new Font(FontFamily.GenericMonospace, 9, FontStyle.Bold, GraphicsUnit.Point, new byte(), false), Brushes.Black, new PointF(Hpoint.X - 12, Hpoint.Y - 12));
        }
    }
}
