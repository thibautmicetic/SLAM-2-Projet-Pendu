using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu_TP1
{
    public partial class menu : Form
    {

        Form1 form1;
        public menu()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            form1 = new Form1();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void arreterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_fermerForm1_Click(object sender, EventArgs e)
        {
            form1.fermerForm();
        }
    }
}
