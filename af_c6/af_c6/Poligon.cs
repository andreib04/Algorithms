using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace af_c6
{
    internal class Poligon
    {
        public static Random rnd = new Random();
        PointF[] points;

        public Poligon(int n, int max_X, int max_Y)
        {
            points = new PointF[n];
            for(int i = 0; i < n; i++)
            {
                points[i] = new PointF(rnd.Next(max_X), rnd.Next(max_Y));
            }
        }

        public Poligon(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            List<string> lines = new List<string>();
            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                lines.Add(buffer);
            }
            load.Close();

            points = new PointF[lines.Count];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(float.Parse(lines[i].Split(' ')[0]), float.Parse(lines[i].Split(' ')[1]));
            }

        }

        public float Perimetru()
        {
            float rez = 0;

            for(int i = 0; i < points.Length; i++)
            {
                rez += MyMath.distance(points[i], points[(i + 1) % points.Length]);
            }

            return rez;
        }

        public PointF G()
        {
            float rezX = 0;
            float rezY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                rezX += points[i].X;
                rezY += points[i].Y;
            }

            return new PointF(rezX / points.Length, rezY / points.Length);
        }

        public float Area()
        {
            float area = 0;
            for(int i = 0; i < points.Length; i++)
            {
                area += (points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X) * 0.5f;
            }
            return area;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawPolygon(Pens.Red, points);
        }

    }
}
