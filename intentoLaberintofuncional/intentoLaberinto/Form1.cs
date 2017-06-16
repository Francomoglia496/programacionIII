using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        public int limiteV = 0;
        public int limiteH = 0;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // padd == 20. LimiteV y LimiteH deben ser mùltiplos de padd


            /*while (limiteV < this.Height - 80)
                limiteV += 20;

            while (limiteH < this.Width - 80)
                limiteH += 20;

            Lab.Generar(g, limiteH, limiteV, primeraVez);
            primeraVez = false;*/

            while (limiteV < panel1.Height - 100)
            {
                limiteV += 20;
                //limiteH += 20;
            }

            while (limiteH < panel1.Width - 100)
            {
                limiteH += 20;
            }

            Lab.Generar(g, limiteH, limiteV, primeraVez);
            primeraVez = false;

            this.pictureBox1.Image = Image.FromFile(@"E:\Facu\programacionIII\intentoLaberinto\SampImag.jpg");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
            primeraVez = true;
            Lab = new Maze();

        

            //Image imgImage = new Image();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Timers.Timer miTimer = new System.Timers.Timer();
            miTimer.Elapsed += new ElapsedEventHandler(eventoTimer);
            miTimer.Interval = 200;
            miTimer.Enabled = true;
            GC.KeepAlive(miTimer);

        }

        private void eventoTimer(object sender, ElapsedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            moveImage(pictureBox1.Location.X, pictureBox1.Location.Y);
        }

        private void moveImage(int x, int y)
        {
            //- pictureBox1.Width
            //panel1.Width 
            if (x < panel1.Width - 100)
            {
                //pictureBox1.Left += 10;

                pictureBox1.Location = new Point(pictureBox1.Location.X + 20 );

            }
            //pictureBox1.Height
            else if (y < panel1.Height - 100 )
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 20);
                //pictureBox1.Top = y + 10;
            }

            else if (x > panel1.Width - 100)
            {
                //pictureBox1.Left += 10;

                pictureBox1.Location = new Point(pictureBox1.Location.X - 20, pictureBox1.Location.Y);

            }
            //pictureBox1.Height
            else if (y > panel1.Height - 100)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 20);
                //pictureBox1.Top = y + 10;
            }

        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D)
                pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);

            else if (e.KeyCode == Keys.A)
                pictureBox1.Location = new Point(pictureBox1.Location.X - 17, pictureBox1.Location.Y);

            else if (e.KeyCode == Keys.S)
                pictureBox1.Location = new Point(pictureBox1.Location.X , pictureBox1.Location.Y + (10 - (int)3.0f));

            else if (e.KeyCode == Keys.W)
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - (10 - (int)3.0f));

            Refresh();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }

      
    }
}
