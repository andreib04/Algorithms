using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace af_lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\matrice.txt");
            List<string> T = new List<string>();
            string buffer;

            while((buffer = load.ReadLine()) != null)
            {
                T.Add(buffer);
            }
            load.Close();

            int n = T.Count();
            int m = T[0].Split(' ').Length;
            int[,] A = new int[n, m];

            for(int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for(int j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(local[j]);
                }
            }

            int min = 0;
           
            if (n < min)
                min = n;
            if (m < min)
                min = m;
            for (int k = 0; k < Math.Abs(n+m) / 2; k++)
            {
                for (int i = k; i < m - 1 - k; i++)
                    Console.Write(A[k, i] + " ");
                for (int i = k; i < n - 1 - k; i++)
                    Console.Write(A[i, m - 1 - k] + " ");
                for (int i = m - 1 - k; i >= k + 1; i--)
                    Console.Write(A[n - 1 - k, i] + " ");
                for (int i = n - 1 - k; i >= k + 1; i--)
                    Console.Write(A[i, k] + " ");
            }

            if (min % 2 == 1)
            {
                for (int i = 0; i < min; i++)
                {
                    Console.Write(A[n / 2, m / 2] + " ");
                }
            }



        }

        private void ElementeSaNuSeRepete()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] A = new int[n, m];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    bool[] T = new bool[n * m];
                    for(int k = 0; k < j; k++)
                    {
                        T[A[i, k]] = true;
                    }
                    for(int k = 0; k < i; k++)
                    {
                        T[A[k, j]] = true;
                    }
                    int idx = 0;
                    while (T[idx]) idx++;
                    A[i, j] = idx;
                }
            }

            for(int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
        }

        private void SteagMareaBritanie()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] A = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                A[i, i] = 1;
                A[i, n / 2] = 1;
                A[n / 2, i] = 1;
                A[i, n - 1 - i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void RetineApa()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
                v[i] = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int apa = 0;

            for (int k = 0; k < 10000; k++)
            {
                bool bS = false;
                bool bD = false;
                int p = rnd.Next(n);
                for (int i = p - 1; i >= 0; i--)
                {
                    if (v[i] > v[p])
                    {
                        bS = true;
                        break;
                    }
                }
                for (int i = p + 1; i < n; i++)
                {
                    if (v[i] > v[p])
                    {
                        bD = true;
                        break;
                    }
                }
                if (bS && bD)
                {
                    apa++;
                }
            }

            Console.WriteLine(apa);
        }
    }
}
