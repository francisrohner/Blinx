using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;

namespace Blinx
{
    public partial class Blinx : Form
    {
        Settings interval;
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

        public enum GWL
        {
            ExStyle = -20
        }

        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x0//0x2
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            
            if(rk.GetValue("Blinx") == null || !rk.GetValue("Blinx").Equals(Application.ExecutablePath.ToString()))
            {
                rk.SetValue("Blinx", Application.ExecutablePath.ToString());
                menRunAtStartup.Text = "[X] Run at startup";
                MessageBox.Show("Blinx will now run at startup", "Blinx");
            }
            else
            {
                rk.DeleteValue("Blinx");
                menRunAtStartup.Text = "Run at startup";
                MessageBox.Show("Blinx will no longer run at startup", "Blinx");
            }

        }

        delegate void FormCallback();
        void HideThisForm()
        {
            if (this.InvokeRequired)
            {
                var d = new FormCallback(HideThisForm);
                this.Invoke(d);
            }
            else
            {
                this.Hide();
            }
        }


        public Blinx()
        {
            InitializeComponent();
            interval = new Settings();
            try
            {
                if (System.IO.File.Exists("Blinx.cfg"))
                {
                    System.IO.StreamReader cfgReader = new System.IO.StreamReader("Blinx.cfg");
                    string strInterval = cfgReader.ReadLine();
                    interval.minutes = int.Parse(strInterval.Substring(strInterval.IndexOf("=") + 1));
                    tmrInterval.Interval = interval.minutes;
                    cfgReader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("There was an issue reading the config file for Blinx.\nThis is likely a file permissions issue!", "Blinx Error");
            }
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
               ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rk.GetValue("Blinx") != null && rk.GetValue("Blinx").Equals(Application.ExecutablePath.ToString()))
                menRunAtStartup.Text = "[X] Run at startup";

            Console.WriteLine("Blinx Ready, running every " + tmrInterval.Interval / 60 / 1000 + " minutes!");

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Thread(new ThreadStart(HideThisForm))).Start();
            tmrHide.Stop();
            tmrInterval.Stop();
            interval.ShowDialog();
            tmrInterval.Interval = interval.minutes;
            tmrInterval.Start();
            try
            {
                System.IO.StreamWriter cfgWriter = new System.IO.StreamWriter("Blinx.cfg");
                cfgWriter.WriteLine("Interval=" + interval.minutes);
                cfgWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("There was an issue saving the config file for Blinx.\nThis is likely a file permissions issue!", "Blinx Error");
            }
        }

        private void tmrHide_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Blinx Vanishes");
            (new Thread(new ThreadStart(HideThisForm))).Start();
            tmrHide.Stop();
            tmrInterval.Start();
        }

        private void tmrInterval_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Blinx Appears");
            this.Show();
            tmrInterval.Stop();
            tmrHide.Start();
        }

        private void Blinx_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
            (new Thread(new ThreadStart(HideThisForm))).Start();
           // t.Start();
        }

        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStartup();
        }
    }
}
