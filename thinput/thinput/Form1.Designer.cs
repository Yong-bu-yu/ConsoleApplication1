namespace thinput
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Shift = new System.Windows.Forms.PictureBox();
            this.Z = new System.Windows.Forms.PictureBox();
            this.X = new System.Windows.Forms.PictureBox();
            this.Ctrl = new System.Windows.Forms.PictureBox();
            this.Upper = new System.Windows.Forms.PictureBox();
            this.Down = new System.Windows.Forms.PictureBox();
            this.Lefts = new System.Windows.Forms.PictureBox();
            this.Right = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lefts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.关闭CToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 54);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::WindowsFormsApp1.Properties.Resources.Question_mark;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.toolStripMenuItem1.ShowShortcutKeys = false;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem1.Text = "帮助(F1)         F1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // 关闭CToolStripMenuItem
            // 
            this.关闭CToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Close_X;
            this.关闭CToolStripMenuItem.Name = "关闭CToolStripMenuItem";
            this.关闭CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.关闭CToolStripMenuItem.ShowShortcutKeys = false;
            this.关闭CToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.关闭CToolStripMenuItem.Text = "关闭(C)          Alt+F4";
            this.关闭CToolStripMenuItem.Click += new System.EventHandler(this.关闭CToolStripMenuItem_Click);
            // 
            // Shift
            // 
            this.Shift.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Shift.Location = new System.Drawing.Point(12, 12);
            this.Shift.Name = "Shift";
            this.Shift.Size = new System.Drawing.Size(30, 30);
            this.Shift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shift.TabIndex = 1;
            this.Shift.TabStop = false;
            // 
            // Z
            // 
            this.Z.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Z.Location = new System.Drawing.Point(48, 12);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(30, 30);
            this.Z.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Z.TabIndex = 2;
            this.Z.TabStop = false;
            // 
            // X
            // 
            this.X.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.X.Location = new System.Drawing.Point(84, 12);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(30, 30);
            this.X.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.X.TabIndex = 3;
            this.X.TabStop = false;
            // 
            // Ctrl
            // 
            this.Ctrl.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Ctrl.Location = new System.Drawing.Point(12, 48);
            this.Ctrl.Name = "Ctrl";
            this.Ctrl.Size = new System.Drawing.Size(30, 30);
            this.Ctrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ctrl.TabIndex = 4;
            this.Ctrl.TabStop = false;
            // 
            // Upper
            // 
            this.Upper.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Upper.Location = new System.Drawing.Point(158, 12);
            this.Upper.Name = "Upper";
            this.Upper.Size = new System.Drawing.Size(30, 30);
            this.Upper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Upper.TabIndex = 5;
            this.Upper.TabStop = false;
            // 
            // Down
            // 
            this.Down.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Down.Location = new System.Drawing.Point(158, 48);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(30, 30);
            this.Down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Down.TabIndex = 6;
            this.Down.TabStop = false;
            // 
            // Lefts
            // 
            this.Lefts.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Lefts.Location = new System.Drawing.Point(122, 48);
            this.Lefts.Name = "Lefts";
            this.Lefts.Size = new System.Drawing.Size(30, 30);
            this.Lefts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Lefts.TabIndex = 7;
            this.Lefts.TabStop = false;
            // 
            // Right
            // 
            this.Right.Image = global::WindowsFormsApp1.Properties.Resources.key_up;
            this.Right.Location = new System.Drawing.Point(194, 48);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(30, 30);
            this.Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Right.TabIndex = 8;
            this.Right.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(237, 89);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Lefts);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Upper);
            this.Controls.Add(this.Ctrl);
            this.Controls.Add(this.X);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.Shift);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolTip1.SetToolTip(this, "本程序由永不语制作");
            this.TopMost = true;
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lefts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 关闭CToolStripMenuItem;
        private System.Windows.Forms.PictureBox Shift;
        private System.Windows.Forms.PictureBox Z;
        private System.Windows.Forms.PictureBox X;
        private System.Windows.Forms.PictureBox Ctrl;
        private System.Windows.Forms.PictureBox Upper;
        private System.Windows.Forms.PictureBox Down;
        private System.Windows.Forms.PictureBox Lefts;
        private System.Windows.Forms.PictureBox Right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

