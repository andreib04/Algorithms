using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_l9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int v0 = n / 1000000; n = n % 1000000;
            int v1 = n / 100000; n = n % 100000;
            int v2 = n / 10000; n = n % 10000;
            int v3 = n / 1000; n = n % 1000;
            int v4 = n / 100; n = n % 100;
            int v5 = n / 10; n = n % 10;
            int v6 = n / 1;

            baseR(v0, "(M)", "(M)", "(M)");
            baseR(v1, "(C)", "(D)", "(M)");
            baseR(v2, "(X)", "(L)", "(C)");
            baseR(v3, "M", "(V)", "(X)");
            baseR(v4, "C", "D", "M");
            baseR(v5, "X", "L", "C");
            baseR(v6, "I", "V", "X");
        }

        static void baseR(int n, string sl, string sm, string sh)
        {
            switch (n)
            {
                case 1: Console.Write(sl);
                    break;
                case 2: Console.Write(sl+sl);
                    break;
                case 3: Console.Write(sl + sl + sl);
                    break;
                case 4: Console.Write(sl + sm);
                    break;
                case 5: Console.Write(sm);
                    break;
                case 6: Console.Write(sm + sl);
                    break;
                case 7: Console.Write(sm + sl + sl);
                    break;
                case 8: Console.Write(sm + sl + sl + sl);
                    break;
                case 9: Console.Write(sl + sh);
                    break;
                case 10: Console.Write(sh);
                    break;
            }
           
        }

        static void P01()
        {
            int suma = int.Parse(Console.ReadLine());
            int[] v = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
            int[] r = new int[v.Length];

            for(int i = 0; i < v.Length; i++)
            {
                r[i] = suma / v[i];
                suma %= v[i];
            }

            for(int i = 0; i < r.Length; i++)
            {
                Console.Write(r[i] + " ");
            }
        }

        static void P02()
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
                case 'V':
                case 'v': return 5;
                case 'I':
                case 'i': return 1;
            }
            return -1;
        }

        static void P03()
        {
            spectacol[] s = new spectacol[101];
            //load din fisier

            for(int i = 0; i < s.Length - 1; i++)
            {
                for(int j = i + 1; j < s.Length; j++)
                {
                    if (s[i].tFinal > s[j].tFinal)
                    {
                        int aux = s[i].tFinal;
                        s[i].tFinal = s[j].tFinal;
                        s[j].tFinal = aux;
                    }
                }
            }

            s[0].View();
            int tF = s[0].tFinal;

            for(int i = 0; i < s.Length; i++)
            {
                if (s[0].tInitial >= tF)
                {
                    s[i].View();
                    tF = s[i].tFinal;
                }
            }


        }
    }
}
