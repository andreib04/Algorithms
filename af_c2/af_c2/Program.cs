using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c2
{
    internal class Program
    {
        /// <summary>
        /// se da un nr intreg
        /// construiti numarul min si max ce se poate construi cu cifrele acestuia
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {



           
            
            
            


            
            
        }
            
        
            //In fisierul data.in se gasesc nr intregi in intervalul -10^9 . 10^9; n < 10^9;
            //Afisati cele mai mari 2 numere de 3 cifre care nu apar in fisier pozitive
        public void Prob3()
        {
            int n;
            string buffer;
            string[] local;
            int k = 0;
            bool[] found = new bool[1000];
            TextReader load = new StreamReader(@"..\..\data.in");
            while ((buffer = load.ReadLine()) != null)
            {
                local = buffer.Split(' ');
                for (int i = 0; i < local.Length; i++)
                {
                    n = int.Parse(local[i]);
                    if (n > 99 && n < 1000)
                        found[n] = true;
                }
            }

            for (int i = 999; i >= 99; i--)
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

        public void Metoda2Sortare()
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
                        int aux = v[i]; v[i] = v[j]; v[j] = aux;
                    }
                }
            }

            int max = 0;
            for (int i = k - 1; i >= 0; i--)
            {
                max = max * 10 + v[i];
            }

            if (v[0] == 0)
            {
                int idx = 1;
                while (v[idx] == 0) idx++;
                (v[0], v[idx]) = (v[idx], v[0]);
            }

            int min = 0;
            for (int i = 0; i < k; i++)
                min = min * 10 + v[i];

            Console.WriteLine("max: " + max + " " + "min: " + min);
        }
        public void Metoda1Numarare()
        {
          
            
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[10];
            while(n != 0)
            {
                v[n % 10]++;
                n /= 10;
            }

            int max = 0;
            for(int i = 9; i >= 0; i--) 
            { 
                for(int j = 0; j < v[i]; j++)
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
            for(int i = 0; i < 9; i++)
            
            {
                for(int j = 0; j < v[i]; j++)
                {
                    min = min * 10 + i;
                }
            }

            Console.WriteLine("max: " + max);
            Console.WriteLine("min " + min);
        }

        public void SelectionSort(int[] v)
        {
            int aux = 0;
            for(int j = 0; j < v.Length-1; j++)
            {
            int min = v[j];
            int poz = j;
            for(int i = j+1;i<v.Length;i++)
            {
                if(v[i] < min)
                {
                    min = v[i];
                    poz = 1;
                }
            }
            aux = v[j]; v[j] = v[poz]; v[poz] = aux;
            }
             
        }

        public void BubbleSort(int[] v)
        {
          
            int kk = 0;
            int aux = 0;
            bool ok = true;
            do
            {
                for (int i = 0; i < v.Length - 1 - kk; i++)
                {
                    if (v[i] < v[i + 1])
                    {
                        aux = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = aux;
                        ok = false;
                    }
                }
                kk++;
            } while (!ok);
        }
    }
}
