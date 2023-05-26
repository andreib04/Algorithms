using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c18_05
{
    public class Queue
    {
        int[] v;

        public string View()
        {
            string toR = "";
            for(int i = 0; i < v.Length; i++)
                toR += v[i].ToString() + " ";
            return toR;
        }

        public void Push(int x)
        {
            int[] temp = new int[v.Length + 1];
            for (int i = 0; i < v.Length; i++)
                temp[i + 1] = v[i];
            temp[0] = x;
            v = temp;
        }

        public int Pop()
        {
            int toR = v[v.Length - 1];
            int[] temp = new int[v.Length - 1];
            for(int i = 0; i < v.Length; i++)
                temp[i] = v[i];
            v = temp;
            return toR;
        }
    }
}
