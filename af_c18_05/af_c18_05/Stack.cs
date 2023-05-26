using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace af_c18_05
{
    public class Stack
    {
        int[] v;

        public string View()
        {
            string toR = "";
            for (int i = 0; i < v.Length; i++)
                toR += v[i].ToString() + " ";
            return toR;
        }

        public void Push(int x)
        {
            int[] tmp = new int[v.Length+1];
            for (int i = 0; i < v.Length; i++) 
                tmp[i+1] = v[i];
            tmp[0] = x;
            v = tmp;
        }

        public int Pop()
        {
            int toR = v[v.Length-1];
            int[] tmp = new int[v.Length-1];
            for(int i = 0; i < v.Length; i++)
                tmp[i-1] = v[i];
            v = tmp;
            return toR;
        }
    }
}
