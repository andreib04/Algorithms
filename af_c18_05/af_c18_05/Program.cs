using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace af_c18_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lee();
            Console.ReadKey();
        }

        static void Lee()
        {
            Queue_ A = new Queue_();
            A.Push(new TRIDATA(0, 0, 1));

            TextReader load = new StreamReader(@"..\..\MAT.txt");
            List<string> T = new List<string>();
            string buff;

            while((buff = load.ReadLine()) != null)
            {
                T.Add(buff);
            }
            load.Close();

            int n = T.Count();
            int m = T[0].Split(' ').Length;
            int[,] M = new int[n, m];
            
            for(int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for(int j = 0; j < m; j++)
                {
                    M[i, j] = int.Parse(local[j]);
                }
            }

            M[0, 0] = 1;
            while(!A.isMpty())
            {
                TRIDATA tmp = A.Pop();
                if(tmp.l-1 >= 0)
                {
                    if (M[tmp.l-1, tmp.c] == 0) 
                    {
                        A.Push(new TRIDATA(tmp.l - 1, tmp.c, tmp.v+1));       //nord
                        M[tmp.l - 1, tmp.c] = tmp.v + 1;
                    }
                }
                if (tmp.l + 1 >= 0)
                {
                    if (M[tmp.l + 1, tmp.c] == 0)
                    {
                        A.Push(new TRIDATA(tmp.l + 1, tmp.c, tmp.v + 1));       //sud
                        M[tmp.l + 1, tmp.c] = tmp.v + 1;
                    }
                }
                if (tmp.c -1 >= 0)
                {
                    if (M[tmp.l, tmp.c-1] == 0)
                    {
                        A.Push(new TRIDATA(tmp.l, tmp.c - 1, tmp.v + 1));       //est
                        M[tmp.l, tmp.c - 1] = tmp.v + 1;
                    }
                }
                if (tmp.c >= 0)
                {
                    if (M[tmp.l, tmp.c] == 0)
                    {
                        A.Push(new TRIDATA(tmp.l, tmp.c, tmp.v + 1));       //vest
                        M[tmp.l, tmp.c] = tmp.v + 1;
                    }
                }
                
            }
            
            
        }
    }
}
