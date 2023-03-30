using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace af_c3
{
    internal class Program
    {

        //O singura parcurgere (in timp real)

        //O(nlogn) quicksort, mergesort, heapsort 
        // .Sort (introsort)

        
        static void Main(string[] args)
        {

            int suma = 0;
            for(int i = 0; i < 5; i++) {
                suma += i;
            }
            Console.WriteLine(suma);
           // Console.WriteLine(Varianta2(5));
            //int n, m;
            //string[] t = Console.ReadLine().Split(' ');
            
            //n = int.Parse(t[0]);
            //m = int.Parse(t[1]);
            //int[] a = new int[n];
            //int[] b = new int[m];

            //for (int i = 0; i < n; i++)
            //    a[i] = int.Parse(t[i]);
            //for(int i = 0; i < n; i++) 
            //    b[i] = int.Parse(t[i]);

            //int nr = 0;
            //for(int i = 0; i < n; i++)
            //{
            //    for(int j = 0; j < m; j++)
            //    {
            //        if (na(a[i], b[j]))
            //            nr++;
            //    }
            //}
        }

        static bool na(int a, int b)
        {
            int c1 = a % 10;
            int c2 = (a / 10) % 10;
            int x1 = b % 10;
            int x2 = (b / 10) % 10;
            if ((c1 == x1 && c2 == x2) || (c1 == x2 && c2 == x1))
                return true;
            return false;
        }


        // 1 1 1 5 5 5 5 9 9 11 20 20 20
        // 1 3 5 4 9 2 11 1 20 3

        public void Prob2()
        {
            TextReader load = new StreamReader(@"..\..\bac.txt");
            int x = int.Parse(load.ReadLine());
            int y = 0;
            int numAparitii = 1;
            while (true)
            {
                if (x == y)
                {
                    numAparitii++;
                }
                else
                {
                    Console.WriteLine(x + " " + numAparitii);
                    numAparitii = 1;
                }
                x = y;
            }
        }

        public void Prob1()
        {
            bool ok = true;
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[10];
            for (int i = 0; i < 9; i++)
            {
                v[i] = cif(n, i);
                if (v[i] % 2 == 0)
                {
                    ok = false;
                }
            }
            if (!ok) Console.Write(-1);
            else
            {
                int t = 0;
                for (int i = 9; i >= 0; i--)
                {
                    for (int j = 0; j < v[i]; j++)
                    {
                        t *= 10 + i;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < v[i]; j++)
                    {
                        t *= 10 + i;
                    }
                }
            }
        }

        public int cif(int n, int b)
        {
            int[] v = new int[9];
            while(n != 0)
            {
                v[n % 10]++;
                n = n / 10;
            }
            return v[b];
        }


        public void Varianta3()
        {
            int m1, m2, m3;
            int x = int.Parse(Console.ReadLine()); m1 = x;
            x = int.Parse(Console.ReadLine()); m2 = x;
            x = int.Parse(Console.ReadLine()); m3 = x;

            if (m1 > m2) { int axu = m1; m1 = m2; m2 = axu; }
            if (m1 > m3) { int aux = m1; m1 = m3; m3 = aux; }
            if (m2 > m3) { int aux = m2; m2 = m3; m3 = aux; }
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 3; i < n; i++)
            {
                x = int.Parse(Console.ReadLine());
                if (x >= m3)
                {
                    m1 = m2;
                    m2 = m3;
                    m3 = x;
                }
                else if (x >= m2)
                {
                    m1 = m2;
                    m2 = x;
                }
                else if (x >= m1)
                {
                    m1 = x;
                }
                Console.WriteLine(m1 + m2 + m3);
            }
        }


        //v[i] < 1000
        public static int Varianta2(int n )
        {
           // int n = int.Parse(Console.ReadLine());
            int[] v = new int[1001];
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                v[x]++;
            }

            int suma = 0;
            int k = 0;

            for (int i = 1000; i >= 0; i--)
            {
                while (v[i] != 0 && k != 3)
                {
                    suma += i;
                    v[i]--;
                    k++;

                }
                if (k == 3)
                {
                    break;
                }
            }

            // Console.WriteLine(suma);
            return suma;
        }


        //Se da un sir de numere, se cere sa se determine suma celor mai mari 3 valori dintre acestea.
        // n <= 10000
        //0 < v[i] < 1 mld
        public void Varianta1()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (v[i] < v[j])
                    {                                           //bubble sort
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }
                }
            }
            int suma = v[n - 1] + v[n - 2] + v[n - 3];
            Console.WriteLine(suma);
        }
    }
}
