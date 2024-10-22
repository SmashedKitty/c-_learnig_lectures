using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _sender = (ToolStripMenuItem)sender;

            if (_sender.Tag.ToString() == closeToolStripMenuItem.Tag.ToString())
            {
                this.Close();
            }
            else if (_sender.Tag.ToString() == newFormToolStripMenuItem.Tag.ToString())
            {
                new Form().Show();
            }
            else if (_sender.Tag.ToString() == newDialogFormToolStripMenuItem.Tag.ToString())
            {
                new Form1().ShowDialog();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
