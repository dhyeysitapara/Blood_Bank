using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Bank
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer so it doesn't fire again
            timer1.Stop();

            // Open the main form
            Mainform main = new Mainform();
            main.Show();

            // Hide or close the splash screen
            this.Hide();

            // Optional: close splash when main is closed
            main.FormClosed += (s, args) => this.Close();
        }
    }
}
