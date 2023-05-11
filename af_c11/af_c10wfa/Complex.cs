using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c10wfa
{
    public class Complex
    {
        double real, imaginar;

        public Complex(double real, double imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
        }

        public Complex() { }

        public string View()
        {
            return real + " +i" + imaginar;
        }

        public static Complex operator +(Complex A, Complex B)
        {
            Complex toR = new Complex();
            toR.real = A.real + B.real;
            toR.imaginar = A.imaginar + B.imaginar;
            return toR;
        }

        //public static Complex operator +(Complex A, Complex B) => new Complex(A.real + B.real, A.imaginar + B.imaginar);

        public static Complex operator -(Complex A, Complex B) => new Complex(A.real - B.real, A.imaginar - B.imaginar);

        public static Complex operator *(Complex A, Complex B)
        {
            Complex toR = new Complex();
            toR.real = A.real * B.real - A.imaginar * B.imaginar;
            toR.imaginar = A.imaginar * B.real + A.real * B.imaginar;
            return toR;
        }

        public static Complex operator /(Complex A, Complex B)
        {
            Complex ConjB = Conjugat(B);
            Complex up = A * ConjB;
            Complex down = B * ConjB;

            Complex toR = new Complex();
            toR.real = up.real / down.real;
            toR.imaginar = up.imaginar / down.real;
            return toR;
        }

        public static Complex Conjugat(Complex A)
        {
            Complex toR = new Complex();
            toR.real = A.real;
            toR.imaginar = -A.imaginar;
            return toR;
        }

        public double Modul()
        {
            return Math.Sqrt(real * real + imaginar * imaginar);
        }
    }
}
