using af_c6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace af_c10wfa
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        MyGraphics g = new MyGraphics();
        Graphics grp;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);
            pFr(200, 200, 120);
            g.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);

            PointF A = new PointF(500, 400);
            PointF B = new PointF(100, 100);
            PointF C = new PointF(600, 200);

            TriunghiSierpinski(A, B, C);
            g.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);
            PointF A = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF B = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF C = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF D = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));

            Patrat2(A, B, C, D);
            g.Refresh();
        }

        public void Patrat2(PointF A, PointF B, PointF C, PointF D)
        {
            if (distance(A, B) >= 1)
            {
                PointF M1 = new PointF((A.X + B.X) /3, (A.Y + B.Y)/3);
                PointF M2 = new PointF((A.X + B.X) /3, (A.Y + B.Y) /3);

                PointF N1 = new PointF((B.X + C.X) / 3, (B.Y + C.Y) / 3);
                PointF N2 = new PointF((B.X + C.X) / 3, (B.Y + C.Y) / 3);

                PointF P1 = new PointF((C.X + D.X) / 3, (C.Y + D.Y) / 3);
                PointF P2 = new PointF((C.X + D.X) / 3, (C.Y + D.Y) / 3);

                PointF Q1 = new PointF((D.X + A.X) / 3, (D.Y + A.Y) / 3);
                PointF Q2 = new PointF((D.X + A.X) / 3, (D.Y + A.Y) / 3);

                PointF I1 = new PointF((M1.X + P2.X) / 3, (M1.Y + P2.Y) / 3);
                PointF I2 = new PointF((M2.X + P1.X) / 3, (M2.Y + P1.Y) / 3);

                PointF J1 = new PointF((P2.X + M1.X) / 3, (P2.Y + M1.Y) / 3);
                PointF J2 = new PointF((M2.X + P1.X) / 3, (M2.Y + P1.Y) / 3);

                g.grp.DrawLine(Pens.Red, A, B);
                g.grp.DrawLine(Pens.Red, B, C);
                g.grp.DrawLine(Pens.Red, C, D);
                g.grp.DrawLine(Pens.Red, D, A);

                Patrat2(A, M1, I1, Q2);
                Patrat2(M2, B, N1, I2);
                Patrat2(J2, N2, C, P1);
                Patrat2(Q1, J1, P2, D);
                Patrat2(I1, I2, J2, J1);
            }
        }

        
        public void TriunghiSierpinski(PointF A, PointF B, PointF C)
        {
            if (distance(A, B) >= 1)
            {
                PointF M = new PointF((A.X + C.X) / 2, (A.Y + C.Y) / 2);
                PointF N = new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);
                PointF P = new PointF((C.X + B.X) / 2, (C.Y + B.Y) / 2);

                Triunghi(A, B, C);

                TriunghiSierpinski(M, C, P);
                TriunghiSierpinski(N, P, B);
                TriunghiSierpinski(A, M, N);
            }
        }

        public void Triunghi(PointF A, PointF B, PointF C)
        {
            g.grp.DrawLine(Pens.Red, A, B);
            g.grp.DrawLine(Pens.Red, A, C);
            g.grp.DrawLine(Pens.Red, B, C);
        }

        public void Patrat(float x, float y, float l)
        {
            g.grp.DrawLine(Pens.Black, x - l / 2, y - l / 2, x + l / 2, y - l / 2);
            g.grp.DrawLine(Pens.Black, x + l / 2, y - l / 2, x + l / 2, y + l / 2);
            g.grp.DrawLine(Pens.Black, x + l / 2, y + l / 2, x - l / 2, y + l / 2);
            g.grp.DrawLine(Pens.Black, x - l / 2, y + l / 2, x - l / 2, y - l / 2);
        }

        public void pFr(float x, float y, float l)
        {
            if (l > 1)
            {
                Patrat(x, y, l);
                pFr(x - l / 2, y - l / 2, l / 2);
                pFr(x + l / 2, y - l / 2, l / 2);
                pFr(x - l / 2, y + l / 2, l / 2);
                pFr(x + l / 2, y + l / 2, l / 2);
            }
        }

        public static float distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

    }
}
