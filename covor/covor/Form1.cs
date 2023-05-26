using af_c6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace covor
{
    public partial class Form1 : Form
    {
        MyGraphics g = new MyGraphics();
        Graphics grp;
        public static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);
            PointF A = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF B = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF C = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));
            PointF D = new PointF(rnd.Next(10, this.pictureBox1.Width - 10), rnd.Next(20, this.pictureBox1.Height - 10));

            Patrat2(A, B, C, D);
            g.Refresh();
        }

        public static float distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public void Patrat2(PointF A, PointF B, PointF C, PointF D)
        {
            

            if (distance(A, B) >= 1)
            {
                PointF M1 = new PointF((A.X + B.X) / 3, (A.Y + B.Y) / 3);
                PointF M2 = new PointF((A.X + B.X) / 3, (A.Y + B.Y) / 3);

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

    }
}
