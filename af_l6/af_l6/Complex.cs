using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_l6
{
    public class Complex
    {
        float real, imaginar;

        public Complex(string data)
        {

        }

        public Complex(float real, float imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
        }

        public Complex() { }

        public void Read()
        {
             real = float.Parse(Console.ReadLine());
             imaginar = float.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            if (imaginar == 0 && real == 0)
                return "0";
            else if (imaginar == 0)
                return real.ToString();
            else if (real == 0)
            {
                if (imaginar < 0)
                {
                    if (imaginar == -1)
                        return "-i";
                    else
                        return "-i" + Math.Abs(imaginar);
                }
                else
                {
                    if (imaginar == 1)
                        return "i";
                    else
                        return "i" + imaginar;
                }
            }
            else
            {

                if (imaginar < 0)
                    return real + "-i" + Math.Abs(imaginar);
                else
                    return real + "+i" + imaginar;
            }
            
        }

        public static Complex operator +(Complex a, Complex b)
        {
            Complex toR = new Complex();
            toR.real = a.real + b.real;
            toR.imaginar = a.imaginar + b.imaginar;

            return toR;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex toR = new Complex();
            toR.real = a.real - b.real;
            toR.imaginar = a.imaginar - b.imaginar;

            return toR;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            Complex toR = new Complex();
            toR.real = (a.real * b.real) - (a.imaginar * b.imaginar);
            toR.imaginar = (a.real * b.imaginar) + (b.real * a.imaginar);

            return toR;
        }

        public static Complex operator /(Complex a, Complex b)
        {
            Complex cj = b.conj();
            Complex up = a * cj;
            Complex dw = b * cj;

            Complex toR = new Complex();
            toR.real = up.real / dw.real;
            toR.imaginar = up.imaginar / dw.real;

            return toR;
        }

        public  Complex conj()
        {
            Complex toR = new Complex();
            toR.real = this.real;
            toR.imaginar = -this.imaginar;
            return toR;
        }

        public static bool operator <(Complex a, Complex b)
        {
            if (a.modul() < b.modul())
                return true;
            return false;
        }

        public static bool operator >(Complex a, Complex b)
        {
            return !(a < b);
        }

        public float modul()
        {
            return (float)Math.Sqrt(real * real + imaginar * imaginar);
        }
    }
}
