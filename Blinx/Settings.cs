using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blinx
{
    public partial class Settings : Form
    {
        public int minutes;
        public Boolean flash;
        public Color flashColor;
        public char size;

        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            minutes = (int) nudIntervalMinutes.Value * 60 * 1000;
            this.Hide();
        }

        private void Interval_VisibleChanged(object sender, EventArgs e)
        {
            if(minutes != 0)
            nudIntervalMinutes.Value = minutes / (60 * 1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button2.BackColor = colorDialog1.Color;
        }
        
    }
}
