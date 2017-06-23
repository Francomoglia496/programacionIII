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
        int varx, vary = 0;
        TimeSpan time;

        //Graphics g2 = new Graphics(panel1);

        public Form1()
        {
            InitializeComponent();
        }

        //public int limiteV = 0;
        //public int limiteH = 0;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int limiteV = 0;
            int limiteH = 0;

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
                limiteV += 15;
                //limiteH += 20;
            }

            while (limiteH < panel1.Width - 100)
            {
                limiteH += 15;
            }

            Lab.Generar(g, limiteH, limiteV, primeraVez);
            primeraVez = false;

            //this.pictureBox1.Image = Image.FromFile("SampImag.jpg");

            /*
            foreach (int cComponente in Lab.pila1)
            {
                foreach (int item in Lab.pila2)
                {
                    richTextBox1.Text += cComponente + " " + item + "\n";
                    richTextBox1.Text += Lab.celda0[cComponente,item]  + "\n";

                }

            }
            */


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
            moveImage(0, 0);
        }

        private void moveImage(int x, int y)
        {

            if (Lab.ultimax == x && Lab.ultimay == y)
            {
                const string message = "GANADOR!!";
                const string caption = "Jeugo Terminado";

                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                this.Close();
            }
            else
            {
                if (Lab.celda0[x, y].E != 1 && Lab.celda0[x, y].E != 3 && Lab.celda0[x, y + 1].visitado == false)
                {
                    y++;
                    //pictureBox1.Location = new Point(Lab.celda0[x, y].punto.X, Lab.celda0[x, y].punto.Y);
                    pictureBox1.Location = new Point(Lab.celda0[x, y].punto.X + 3, Lab.celda0[x, y].punto.Y + 3);

                    Lab.celda0[x, y].visitado = true;

                    //g2.DrawRectangle(Lab.pen3, x, y, 15, 15);

                    richTextBox1.Text += " " + Lab.celda0[x, y].punto.X + " " + Lab.celda0[x, y].punto.Y + "derecha \n";
                    moveImage(x, y);

                }

                if (Lab.celda0[x, y].S != 1 && Lab.celda0[x, y].S != 3 && Lab.celda0[x + 1, y].visitado == false)
                {
                    x++;
                    //pictureBox1.Location = new Point(x, y);
                    pictureBox1.Location = new Point(Lab.celda0[x, y].punto.X + 3, Lab.celda0[x, y].punto.Y + 3);

                    Lab.celda0[x, y].visitado = true;

                    richTextBox1.Text += " " + Lab.celda0[x, y].punto.X + " " + Lab.celda0[x, y].punto.Y + "sur \n";

                    moveImage(x, y);

                }

                if (Lab.celda0[x, y].O != 1 && Lab.celda0[x, y].O != 3 && Lab.celda0[x, y - 1].visitado == false)
                {
                    y--;
//                    pictureBox1.Location = new Point(x, y);
                    pictureBox1.Location = new Point(Lab.celda0[x, y].punto.X + 3, Lab.celda0[x, y].punto.Y + 3);

                    Lab.celda0[x, y].visitado = true;

                    richTextBox1.Text += " " + Lab.celda0[x, y].punto.X + " " + Lab.celda0[x, y].punto.Y + "izq \n";

                    moveImage(x, y);

                }

                if (Lab.celda0[x, y].N != 1 && Lab.celda0[x, y].N != 3 && Lab.celda0[x - 1, y].visitado == false)
                {
                    x--;
                    pictureBox1.Location = new Point(Lab.celda0[x, y].punto.X + 3, Lab.celda0[x, y].punto.Y + 3);

//                    pictureBox1.Location = new Point(x, y);
                    Lab.celda0[x, y].visitado = true;

                    richTextBox1.Text += " " + Lab.celda0[x, y].punto.X + " " + Lab.celda0[x, y].punto.Y + "norte \n";

                    moveImage(x, y);

                }
            }


        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            /*
             
            int a = Lab.celda0[varx , vary+1].punto.X;
            int b = Lab.celda0[varx, vary + 1].punto.Y;

            richTextBox1.Text += "varx " + a + "\n";
            richTextBox1.Text += "vary " + b + "\n";
            */

//            richTextBox1.Text += varx + "\n";
//            richTextBox1.Text += vary + "\n";

            if (e.KeyCode == Keys.D) {

                if (Lab.celda0[varx, vary].E != 1 && Lab.celda0[varx, vary].E != 3)
                {
                    vary++;

                }
                //pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X, Lab.celda0[varx , vary].punto.Y);
                //pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);
            }

            else if (e.KeyCode == Keys.A) {
                //pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);

                if (Lab.celda0[varx, vary].O != 1 && Lab.celda0[varx, vary].O != 3)
                {
                    vary--;
                    //pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X, Lab.celda0[varx, vary].punto.Y);
                }

            }

            else if (e.KeyCode == Keys.S)
            {
                //pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);

                if (Lab.celda0[varx, vary].S != 1 && Lab.celda0[varx, vary].S != 3)
                {
                    varx++;
                    //pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X, Lab.celda0[varx, vary].punto.Y);
                }
                }
            else if (e.KeyCode == Keys.W)
            {
                //pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);

                if (Lab.celda0[varx, vary].N != 1 && Lab.celda0[varx, vary].N != 3)
                {
                    varx--;
                    //pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X, Lab.celda0[varx, vary].punto.Y);

                }

                }

            pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X + 3, Lab.celda0[varx, vary].punto.Y + 3);

            
            if (Lab.celda0[varx, vary].punto == Lab.celda0[Lab.ultimax,Lab.ultimay].punto)
            {
                const string message = "GANADOR!!";
                const string caption = "Jeugo Terminado";

                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            }
            //g.DrawRectangle(pen2, x, y, padd, padd);
            
            //Refresh();



        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int item in Lab.pila1)
            {
                richTextBox1.Text += " " + item + " \n";
                //richTextBox1.Text += " " + Lab.pila2.Peek() + " \n";


            
            }


            int limiteV = 0;
            int limiteH = 0;

            //this.pictureBox1.Image = Image.FromFile(@"E:\Facu\programacionIII\intentoLaberintofuncional\SampImag.jpg");
            this.pictureBox1.Image = Image.FromFile(@"C:\Users\Lenovo\Documents\Visual Studio 2012\Projects\programacionIII\intentoLaberintofuncional\SampImag.jpg");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(Lab.celda0[varx, vary].punto.X + 3, Lab.celda0[varx, vary].punto.Y + 3);

            time = TimeSpan.Parse("00:03:00");

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;

            timer.Tick += (a, b) =>
            {
                time = time.Subtract(new TimeSpan(0, 0, 1));
                label1.Text = time.ToString();

                if (time.Minutes == 0)
                {
                    timer.Stop();

                    const string message = "Lo Siento Perdiste, quieres volver a empezar?";
                    const string caption = "Jeugo Terminado";

                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the no button was pressed ...
                    if (result == DialogResult.No)
                    {
                        // cancel the closure of the form.
                        //e.Cancel = true;
                        //Form1 form1 = new Form1();
                        this.Close();

                    }
                    else
                    {

                        Graphics g = panel1.CreateGraphics();


                        while (limiteV < panel1.Height - 100)
                        {
                            limiteV += 15;
                            //limiteH += 20;
                        }

                        while (limiteH < panel1.Width - 100)
                        {
                            limiteH += 15;
                        }

                        Lab.Generar(g, limiteH, limiteV, primeraVez);
                        primeraVez = false;


                    }

                    return;
                }
                
            };

            timer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
