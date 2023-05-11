using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace af_c6
{
    public class MyGraphics
    {
        Bitmap bmp;
        public Graphics grp;
        PictureBox display;
        Color backColor = Color.White;
        public int resX, resY;

        public void InitGraph(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            resX = display.Width;
            resY = display.Height;
            grp = Graphics.FromImage(bmp);
            Clear();
            Refresh();
        }

        public void Refresh()
        {
            display.Image = bmp;
        }

        public void Clear()
        {
            grp.Clear(backColor);
        }
    }
}