using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace af_curs5
{
    internal class Program
    {

        //Se da prima linie dintr-o matrice
        // 0, 1, 2, ... , n-1
        // Completati matricea astfel incat fiecare element aflat pe pozitia i, j sa nu se mai repete pe linia i si coloana j.
        // Se cere elementul cu valoarea minima
        static void Main(string[] args)
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
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void P4_6()
        {
            TextReader load = new StreamReader(@"..\..\matrice.txt");

            List<string> T = new List<string>();
            string buffer;

            while ((buffer = load.ReadLine()) != null)
            {
                T.Add(buffer);
            }
            load.Close();

            int n = T.Count; // cate elemente sunt
            int m = T[0].Split(' ').Length;

            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(local[j]);
                }
            }

            int k = 1; //contur
            for (int i = k; i < m - 1 - k; i++)
                Console.Write(A[k, i] + " ");
            for (int i = k; i < n - 1 - k; i++)
                Console.Write(A[i, m - 1 - k] + " ");
            for (int i = m - 1 - k; i >= k + 1; i--)
                Console.Write(A[n - 1 - k, i] + " ");
            for (int i = n - 1 - k; i >= 1 + k; i--)
                Console.Write(A[i, k] + " ");
        }

        static void P4_5()
        {
            TextReader load = new StreamReader(@"..\..\matrice.txt");

            List<string> T = new List<string>();
            string buffer;

            while ((buffer = load.ReadLine()) != null)
            {
                T.Add(buffer);
            }
            load.Close();

            int n = T.Count; // cate elemente sunt
            int m = T[0].Split(' ').Length;

            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(local[j]);
                }
            }

            for (int i = 0; i < m - 1; i++)
                Console.Write(A[0, i] + " ");
            for (int i = 0; i < n - 1; i++)
                Console.Write(A[i, m - 1] + " ");
            for (int i = m - 1; i >= 1; i--)
                Console.Write(A[n - 1, i] + " ");
            for (int i = n - 1; i >= 1; i--)
                Console.Write(A[i, 0] + " ");
        }

        static void P4_4()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] A = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    A[i, j] = (i + j) / 2;
        }

        static void P4_3()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] A = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i < j && i + j < n - 1)
                        A[i, j] = 1;
                    if (i > j && i + j > n - 1)
                        A[i, j] = 1;
                }
        }

        static void SteagulMariiBritanii()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] A = new int[n, n];
            //in C# - A are valoarea 0 pentru toate elementele.

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        A[i, j] = 1;
                    if (i + j == n - 1)
                        A[i, j] = 1;
                    if (i == n / 2)
                        A[i, j] = 1;
                    if (j == n / 2)
                        A[i, j] = 1;
                }                                                             //   :( O(n^2)
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine();

            //sau

            for (int i = 0; i < n; i++)
            {
                A[i, i] = 1;
                A[i, n / 2] = 1;                  //O(n) :) mai eficient
                A[n / 2, i] = 1;
                A[i, n - 1 - i] = 1;
            }
        }


        //Se da un vector ce reprezinta altitudini. Se cere cata apa poate retine vectorul.
        //in: 2 5 7 1 3 5 4 0 2 3 2
        //out: 10
        static void MetodaAleatoare()
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int apa = 0;

            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }

            for (int k = 0; k < 10000; k++)
            {
                int p = rnd.Next(n);
                bool bS = false;
                bool bD = false;

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
                    v[p]++;
                }
            }

            Console.WriteLine(apa);
        }
    }
}
