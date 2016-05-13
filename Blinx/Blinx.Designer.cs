namespace Blinx
{
    partial class Blinx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blinx));
            this.pbEye = new System.Windows.Forms.PictureBox();
            this.notifyMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menChangeInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.menRunAtStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.menExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrInterval = new System.Windows.Forms.Timer(this.components);
            this.tmrHide = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).BeginInit();
            this.ctxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbEye
            // 
            this.pbEye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEye.Image = global::Blinx.Properties.Resources.Blink1;
            this.pbEye.Location = new System.Drawing.Point(0, 0);
            this.pbEye.Name = "pbEye";
            this.pbEye.Size = new System.Drawing.Size(100, 50);
            this.pbEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEye.TabIndex = 0;
            this.pbEye.TabStop = false;
            // 
            // notifyMain
            // 
            this.notifyMain.ContextMenuStrip = this.ctxMain;
            this.notifyMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMain.Icon")));
            this.notifyMain.Text = "notifyIcon1";
            this.notifyMain.Visible = true;
            // 
            // ctxMain
            // 
            this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menChangeInterval,
            this.menRunAtStartup,
            this.menExit});
            this.ctxMain.Name = "contextMenuStrip1";
            this.ctxMain.Size = new System.Drawing.Size(158, 70);
            // 
            // menChangeInterval
            // 
            this.menChangeInterval.Name = "menChangeInterval";
            this.menChangeInterval.Size = new System.Drawing.Size(157, 22);
            this.menChangeInterval.Text = "Change Interval";
            this.menChangeInterval.Click += new System.EventHandler(this.changeIntervalToolStripMenuItem_Click);
            // 
            // menRunAtStartup
            // 
            this.menRunAtStartup.Name = "menRunAtStartup";
            this.menRunAtStartup.Size = new System.Drawing.Size(157, 22);
            this.menRunAtStartup.Text = "Run At Startup";
            this.menRunAtStartup.Click += new System.EventHandler(this.runAtStartupToolStripMenuItem_Click);
            // 
            // menExit
            // 
            this.menExit.Name = "menExit";
            this.menExit.Size = new System.Drawing.Size(157, 22);
            this.menExit.Text = "Exit";
            this.menExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tmrInterval
            // 
            this.tmrInterval.Enabled = true;
            this.tmrInterval.Interval = 60000;
            this.tmrInterval.Tick += new System.EventHandler(this.tmrInterval_Tick);
            // 
            // tmrHide
            // 
            this.tmrHide.Interval = 2000;
            this.tmrHide.Tick += new System.EventHandler(this.tmrHide_Tick);
            // 
            // Blinx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(100, 50);
            this.Controls.Add(this.pbEye);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Blinx";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blinx";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Blinx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).EndInit();
            this.ctxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEye;
        private System.Windows.Forms.NotifyIcon notifyMain;
        private System.Windows.Forms.ContextMenuStrip ctxMain;
        private System.Windows.Forms.ToolStripMenuItem menChangeInterval;
        private System.Windows.Forms.ToolStripMenuItem menExit;
        private System.Windows.Forms.Timer tmrInterval;
        private System.Windows.Forms.Timer tmrHide;
        private System.Windows.Forms.ToolStripMenuItem menRunAtStartup;
    }
}

