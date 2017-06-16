using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intentoLaberinto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            //form1.Activate();
            form1.Show();
            this.Hide();

 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
