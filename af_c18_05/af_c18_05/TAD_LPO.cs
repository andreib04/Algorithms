using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c18_05
{
    public class TAD_LPO     //lista permanent ordonata
    {
        int[] v;
        public void Add(int x)
        {
            if (v.Length == 0 || x < v[0])
            {
                int[] temp = new int[v.Length + 1];
                for (int i = 0; i < v.Length; i++)
                    temp[i + 1] = v[i];                         //addBegin
                temp[0] = x;
                v = temp;
            }
            else if(x > v[v.Length - 1])
            {
                int[] temp = new int[v.Length + 1];
                for (int i = 0; i < v.Length; i++)
                    temp[i] = v[i];                         //addEnd
                temp[v[v.Length - 1]] = x;
                v = temp;
            }
            else
            {
                int[] temp = new int[v.Length + 1];
                int k = 0;
                bool first = true;
                for(int i = 0; i < v.Length; i++)
                {
                    if(x > v[i])
                    {
                        k = 1;
                        if (first)
                        {
                            v[i] = x;
                            first = false;
                        }
                    }
                    temp[k + i] = v[i];
                }
            }
        }
    }
}
