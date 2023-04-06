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
