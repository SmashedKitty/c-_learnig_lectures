using System;
using System.Drawing;
using System.Windows.Forms;



namespace Program1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenWindow1_Click(object sender, EventArgs e)
        {
            Form window1 = new Form2();
            window1.Show();
        }

        private void btnOpenWindow2_Click(object sender, EventArgs e)
        {
            Form3 window2 = new Form3();
            window2.Show();
        }
        private void btnOpenWindow3_Click(object sender, EventArgs e)
        {
            Form4 window3 = new Form4();
            window3.Show();
        }

    }
}