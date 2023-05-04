using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c9
{
    /// <summary>
    /// ALGORITMUL GREEDY
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string T = Console.ReadLine();
            int toR = 0;

            for(int i = 0; i < T.Length - 1; i++)
            {
                if (RtoV(T[i]) >= RtoV(T[i + 1]))
                {
                    toR += RtoV(T[i]);
                }
                else
                {
                    toR -= RtoV(T[i]);
                }
            }
            toR += RtoV(T[T.Length - 1]);
            Console.WriteLine(toR);
        }

        static int RtoV(char c)
        {
            switch (c)
            {
                case 'M':
                case 'm': return 1000;
                case 'D':
                case 'd': return 500;
                case 'C':
                case 'c': return 100;
                case 'L':
                case 'l': return 50;
                case 'X':
                case 'x': return 10;
            }
            return -1;
        }

        //se da o suma (s) si un set de valori (bancnote) v
        //se cere sa se 
        //se cere nr minim de bancnote care se poate folosi
        static void P01()
        {
            int s = int.Parse(Console.ReadLine());
            int[] v = new int[] { 1000, 500, 100, 10, 5, 1 };
            int[] r = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                r[i] = s / v[i];
                s = s % v[i];
            }

            for (int i = 0; i < r.Length; i++)
                Console.Write(r[i] + " ");
        }

        //se dau n spectacole (prin timpul initial si timpul final)
        //ora la care incepe si ora la care se termina
        //avand la dispozitie o singura scena, se cere sa se programeze un nr maxim de spectacole 
        //(sa nu existe mai mult de 1 spectacol pe scena in acelasi timp)
        static void P02()
        {
            spectacol[] s = new spectacol[101];
            //load(fisier);

            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i].tFinal > s[j].tFinal)
                    {
                        spectacol aux = s[i];
                        s[i] = s[j];
                        s[j] = aux;
                    }
                }
            }

            s[0].View();
            int tF = s[0].tFinal;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i].tInitial >= tF)
                {
                    s[i].View();
                    tF = s[i].tFinal;
                }
            }
        }

        //se da un numar in scrierea romana, se cere valoarea acestora
        //MMCMCLXXIV
        static void P03()
        {

        }
    }
}
