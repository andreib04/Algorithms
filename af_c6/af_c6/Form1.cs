using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace af_c6
{
    public partial class Form1 : Form
    {
        MyGraphics g;
        Poligon[] test;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int size = 1;
            g = new MyGraphics(pictureBox1);
            test = new Poligon[size];
            test[0] = new Poligon(@"..\..\test.txt");
            g.Clear();
            test[0].Draw(g.g);
            for(int i = 1; i < size; i++)
            {
                test[i] = new Poligon(3, g.resX, g.resY);
                test[i].Draw(g.g);
            }


            Matrix test1 = new Matrix(3, 3, 0, 2);
            Matrix test2 = new Matrix(3, 3, 0, 2);
            Matrix test3 = test1 * test2;

            ViewMatrix(test1);
            ViewMatrix(test2);
            ViewMatrix(test3);



            g.Refresh();
        }

        public void ViewMatrix(Matrix matrix)
        {
            foreach (string s in matrix.View())
                listBox1.Items.Add(s);
            listBox1.Items.Add(" ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test[0].Perimetru().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointF G = test[0].G();
            g.g.DrawEllipse(Pens.Black, G.X - 2, G.Y - 2, 5, 5);
            g.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Poligon X = g.PoligonTranslate(test[0], new Point(200, 100));
            X.Draw(g.g);

            g.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Poligon X = g.PoligonScale(test[0], 1, 2);
            X.Draw(g.g);

            g.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Poligon X = g.PoligonScale(test[0], 0.2f, test[0].G());
            X.Draw(g.g);

            g.Refresh();
        }
    }
}
