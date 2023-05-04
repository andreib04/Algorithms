using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace af_c6
{
    internal class MyGraphics
    {
        Bitmap bmp;
        public Graphics g;
        PictureBox display;
        Color backColor = Color.White;
        public int resX, resY;



        public MyGraphics(PictureBox display)
        {
            this.display = display;
            resX = display.Width;
            resY = display.Height;
            bmp = new Bitmap(display.Width, display.Height);
            g = Graphics.FromImage(bmp);
        }

        public Poligon PoligonTranslate(Poligon poligon, PointF translation)
        {
            Matrix C = new Matrix(poligon.length, translation);
            Matrix P = poligon.PoligonToMatrix();
            Matrix T = P + C;

            return T.MatrixToPoligon();
        }

        public Poligon PoligonScale(Poligon poligon, float fx, float fy)
        {
            Matrix M = new Matrix(2, 2);
            M.a[0, 0] = fx;
            M.a[0, 1] = 0;
            M.a[1, 0] = 0;
            M.a[1,1] = fy;

            Matrix P = poligon.PoligonToMatrix();
            Matrix S = M * P;

            return S.MatrixToPoligon();
        }

        public Poligon PoligonRotation(Poligon poligon, float angle, PointF center)
        {
            Matrix M = new Matrix(2, 2);
            M.a[0, 0] = (float)Math.Cos(angle);
            M.a[0, 1] = -(float)Math.Sin(angle);
            M.a[1, 0] = (float)Math.Sin(angle);
            M.a[1, 1] = (float)Math.Cos(angle);

            Matrix C = new Matrix(poligon.length, center);
            Matrix P = poligon.PoligonToMatrix();
            Matrix R = M * (P - C) + C;

            return R.MatrixToPoligon();
        }

        public void Refresh()
        {
            display.Image = bmp;
        }

        public void Clear()
        {
            g.Clear(backColor);
        }
    }
}
