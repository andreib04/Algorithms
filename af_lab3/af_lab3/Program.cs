using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace af_lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\BAC.IN");
            string buffer = load.ReadLine();
            string[] local = buffer.Split(' ');
            int[] v = new int[101];

            for(int i = 0; i < local.Length; i++)
            {
                v[i] = int.Parse(local[i]);
            }


            for (int i = 0; i < local.Length - 1; i++)
            {
                for (int j = i + 1; j < local.Length; j++)
                {
                    if (v[i] > v[j])
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }
                }
            }

            int max1 = 0;
            int max2 = 0;
            int auxx = 0;
            for (int i = 0; i < local.Length; i++)
            {
                if (Impar(v[i]))
                {
                    if (max1 < v[i])
                    {
                        auxx = max1;
                        max1 = v[i];
                        
                    }
                    
                    if (max2 < v[i])
                        max2 = v[i];
                    if(max2 == max1)
                        max1 = auxx;
                }
            }
            Console.WriteLine(max1 +" " +max2);

        }

        static bool Impar(int n)
        {
            if (n % 2 == 0)
                return false;
            return true;
        }

        static void Varfuri()
        {
            TextReader load = new StreamReader(@"..\..\varf.txt");
            int nr = 0;
            int min = 0;
            bool first = true;
            int x = int.Parse(load.ReadLine());
            int y = int.Parse(load.ReadLine());
            int z; string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                z = int.Parse(buffer);
                if (y > z && y > x)
                {
                    if (first)
                    {
                        nr = y;
                        first = false;
                        min = Math.Abs(y - x) + Math.Abs(z - y);
                    }
                    else
                    {
                        if (min > Math.Abs(y - x) + Math.Abs(z - y))
                        {
                            nr = y;
                            min = Math.Abs(y - x) + Math.Abs(z - y);
                        }
                    }
                }
                x = y; y = z;
            }
            Console.WriteLine(nr);
        }

        static void P05()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(t[i]);
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (v[i] > v[j])
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }
                }
            }

            for (int i = 0; i < n; i++)
                if (Digits(v[i]))
                    Console.Write(v[i] + " ");
        }

        static bool Digits(int n)
        {
            while (n / 10 != 0)
            {
                if (n % 10 != (n / 10) % 10)
                    return false;

                n /= 10;
            }
            return true;
        }

        static void P03()
        {
            TextReader load = new StreamReader(@"..\..\numere.txt");
            string buffer;
            int k = 0;
            int[] v = new int[10];
            double final = 0;
            int n = 0;
            while ((buffer = load.ReadLine()) != null)
            {
                n = int.Parse(buffer);
                while (n != 0)
                {
                    v[k] = n % 10;
                    n /= 10;
                    k++;
                }
            }

            for (int i = 0; i < k - 1; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (v[i] > v[j])
                        (v[i], v[j]) = (v[j], v[i]);
                }
            }

            for (int i = k - 1; i >= 0; i--)
            {
                final = final * 10 + v[i];
            }
            Console.WriteLine(final);
            Console.ReadKey();
        }

        static void P04()
        {
            TextReader load = new StreamReader(@"..\..\produse.txt");

            string buffer;
            int[] v = new int[101];
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                v[int.Parse(local[0])] += int.Parse(local[1]) * int.Parse(local[2]);
            }
            for (int i = 0; i < 100; i++)
            {
                if (v[i] != 0)
                {
                    Console.WriteLine(i + " " + v[i]);
                }
            }

            Console.ReadKey();
        }
    }
}
