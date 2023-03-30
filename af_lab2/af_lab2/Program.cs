using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace af_lab2
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] v = new int[1000];
            for(int i = 0; i< 100; i++)
            {
                v[i] = rnd.Next(1, 101);
                Console.Write(v[i] + " ");
            }

            Console.WriteLine();

            int k = 0;
            bool ok = true;
            do
            {
                for (int i = 0; i < v.Length-1;i++)
                {
                    if (v[i] < v[i + 1])
                    {
                        int aux = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = aux;
                        ok = false;
                    }

                }
                k++;
            } while (!ok);

            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }

        }


//afisati cele mai mari 2 numere de 3 cifre pozitive care nu apar in fisier
        public void CeleMaiMari2nrCenuApar()
        {
            TextReader load = new StreamReader(@"..\..\data.in");
            string buffer;
            int n;
            int k = 0;
            bool[] found = new bool[1000];
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                for (int i = 0; i < local.Length; i++)
                {
                    n = int.Parse(local[i]);
                    if (n > 99 && n < 1000)
                        found[n] = true;
                }
            }

            for (int i = 999; i >= 100; i--)
            {
                if (!found[i])
                {
                    Console.Write(i + " ");
                    k++;
                    if (k == 2)
                        break;
                }
            }

        }


        public void Numarare()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[10];

            while (n != 0)
            {
                v[n % 10]++;
                n = n / 10;
            }

            int max = 0;
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < v[i]; j++)
                {
                    max = max * 10 + i;
                }
            }

            int min = 0;
            if (v[0] != 0)
            {
                int idx = 1;
                while (v[idx] == 0)
                {
                    idx++;
                }
                min = idx;
                v[idx]--;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < v[i]; j++)
                {
                    min = min * 10 + i;
                }
            }

            Console.Write(min + " " + "\n" + max + " ");
        }

        //se da un nr intreg, construiti minimul si maximul care se poate determina cu cifrele acestuia
        public void Sortare()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[16];

            int k = 0;
            while (n != 0)
            {
                v[k] = n % 10;
                n = n / 10;
                k++;
            }

            for (int i = 0; i < k - 1; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (v[i] > v[j])
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }
                }
            }

            int max = 0;
            for (int i = k - 1; i >= 0; i--)
            {
                max = max * 10 + v[i];
            }

            int min = 0;
            if (v[0] == 0)
            {
                int idx = 1;
                while (v[idx] == 0) idx++;
                int aux = v[0]; v[0] = v[idx]; v[idx] = aux;
            }

            for (int i = 0; i < k; i++)
            {
                min = min * 10 + v[i];
            }

            Console.Write(min + " " + max);
        }
    }
}
