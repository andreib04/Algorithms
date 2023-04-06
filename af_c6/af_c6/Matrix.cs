using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c6
{
    public class Matrix
    {
        static Random rnd = new Random();   
        int[,] a;

        public Matrix(int n, int m)
        {
            a = new int[n, m];
        }

        public Matrix(int n, int m, int min, int max)
        {
            a = new int[n, m]; 
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    a[i,j] = rnd.Next(min, max);
                }
            }
        }

        public static Matrix Empty;

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.a.GetLength(0) != B.a.GetLength(1) || A.a.GetLength(1) != B.a.GetLength(0))
                return Empty;
            Matrix ToReturn = new Matrix(A.a.GetLength(0), A.a.GetLength(1));
            for (int i = 0; i < A.a.GetLength(0); i++)
            {
                for (int j = 0; j < A.a.GetLength(1); j++)
                {
                    ToReturn.a[i, j] = A.a[i, j] + B.a[i, j];
                }
            }

            return ToReturn;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            int n = A.a.GetLength(0);
            int m = A.a.GetLength(1);
            if (B.a.GetLength(0) != m)
                return Empty;

            Matrix ToReturn = new Matrix(n, B.a.GetLength(1));
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < B.a.GetLength(1); j++)
                {
                    ToReturn.a[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        ToReturn.a[i, j] += A.a[i, k] * B.a[k, j];
                    }
                }
            }
            return ToReturn;
        }

        public List<string> View()
        {
            List<string> toReturn = new List<string>();
            string buffer;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                buffer = "";
                for(int j = 0; j < a.GetLength(1); j++)
                    buffer += a[i, j];
                toReturn.Add(buffer);
            }
            return toReturn;
        }
    }

}
