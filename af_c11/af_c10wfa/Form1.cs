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


namespace af_c10wfa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyGraphics g = new MyGraphics();
        Graphics grp;

        private void Form1_Load(object sender, EventArgs e)
        {
            g.InitGraph(pictureBox1);
            pFr(200, 200, 120);
            g.Refresh();
        }

        public void Patrat(float x, float y, float l)
        {
            g.grp.DrawLine(Pens.Black, x - l / 2, y - l / 2, x + l / 2, y - l /2);
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
    }

  
}
