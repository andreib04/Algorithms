using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace parcurgereInAdancime_DFS_
{
    internal class Program
    {
        private static int n;
        private static int m;
        private static bool[,] b;
        private static int[,] a;
        private static bool ok;
        private static int t;
        private static int t1, t2;
        private static int nr;
        private static int max = 0;
        private static bool is1, is2;

        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\matrix.txt");
            List<string> T = new List<string>();

            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                T.Add(buffer);
            }
            load.Close();

             n = T.Count;
             m = T[0].Split(' ').Length;
             a = new int[n,m];
            b = new bool[n, m];

            for(int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for(int j = 0; j < m; j++)
                {
                    a[i,j] = int.Parse(local[j]);
                }
            }

            //ok = false;
            //pA_parcurgere(0, 0);
            //if (ok)
            //{
            //    Console.WriteLine("DA");
            //}                                 //MAIN PT. DrUM
            //else
            //{
            //    Console.WriteLine("NU");
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        if (!b[i, j])
            //        {
            //            nr = 0;
            //            t = a[i, j];              //platou maxim
            //            pA_platouMaxim(i, j);
            //            if (nr > max)
            //                max = nr;
            //        }
            //    }
            //}
            //Console.WriteLine(max);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    is1 = false; is2 = false; nr = 0;
                    if (a[i, j] == 0 && !b[i, j])
                    {                                           //pb teritoriilor
                        pA_teritorii(i, j);
                        if (is1 && !is2)
                            t1 += nr;
                        if (!is1 && is2)
                            t2 += nr;
                    }
                }
            }
            Console.WriteLine(t1 + " : " + t2);
        }

        static void pA_parcurgere(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < m)
            {
                if (!b[i,j])
                {
                    if (a[i,j] == 0)
                    {
                        if (i == n - 1 && j == m - 1 )  ok = true;
                       
                        
                        b[i, j] = true;
                        
                        pA_parcurgere(i - 1, j);
                        pA_parcurgere(i, j + 1);
                        pA_parcurgere(i + 1, j);
                        pA_parcurgere(i, j - 1);
                        
                    }
                }
            }
        }

        static void pA_platouMaxim(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < m)
            {
                if (!b[i, j])
                {
                    if (a[i,j] == t)
                    { 
                        nr++;
                        b[i,j] = true;
                        
                        pA_platouMaxim(i - 1, j);
                        pA_platouMaxim(i, j + 1);
                        pA_platouMaxim(i + 1, j);
                        pA_platouMaxim(i, j - 1);
                    }
                }
            }
        }

        static void pA_teritorii(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < m)
            {
                if (!b[i, j])
                {
                    if (a[i,j] == 0)
                    {
                        b[i,j] = true;
                        nr++;

                        pA_teritorii(i - 1, j);
                        pA_teritorii(i, j + 1);
                        pA_teritorii(i + 1, j);
                        pA_teritorii(i, j - 1);
                    }
                    else
                    {
                        if (a[i, j] == 1) is1 = true;
                        if (a[i, j] == 2) is2 = true;
                    }
                }
            }
        }
        
    }
   
}
