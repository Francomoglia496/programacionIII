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
    public partial class Form1 : Form
    {
        private Maze Lab;
        private bool primeraVez;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // padd == 20. LimiteV y LimiteH deben ser mùltiplos de padd

            int limiteV = 0, limiteH = 0;

            /*while (limiteV < this.Height - 80)
                limiteV += 20;

            while (limiteH < this.Width - 80)
                limiteH += 20;

            Lab.Generar(g, limiteH, limiteV, primeraVez);
            primeraVez = false;*/

            while (limiteV < panel1.Height - 100)
            {
                limiteV += 20;
                limiteH += 20;
            }

            /*while (limiteH < this.Width - 100)
            {
                limiteH += 20;
            }*/

            Lab.Generar(g, limiteH, limiteV, primeraVez);
            primeraVez = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            primeraVez = true;
            Lab = new Maze();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }

    }
}
