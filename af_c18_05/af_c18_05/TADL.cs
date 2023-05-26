using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace af_c18_05
{
    public class TADL
    {
        private int[] v;

        public string View()
        {
            string toR = "";
            for (int i = 0; i < v.Length; i++)
                toR += v[i].ToString() + " ";
            return toR;
        }

        public void addBegin(int x)
        {
            int[] temp = new int[v.Length + 1];
            for (int i = 0; i < v.Length; i++)
                temp[i + 1] = v[i];
            temp[0] = x;
            v = temp;
        }

        public void addEnd(int x)
        {
            int[] temp = new int[v.Length + 1];
            for (int i = 0; i < v.Length; i++)
                temp[i] = v[i];
            temp[v[v.Length - 1]] = x;
            v = temp;
        }

        public int delBegin()
        {
            int toR = v[0];
            int[] temp = new int[v.Length - 1];
            for (int i = 0; i < v.Length; i++)
                temp[i - 1] = v[i];
            v = temp;
            return toR;
        }

        public int delEnd()
        {
            int toR = v[v.Length - 1];
            int[] temp = new int[v.Length - 1];
            for (int i = 0; i < v.Length; i++)
                temp[i] = v[i];
            v = temp;
            return toR;
        }
    }
    
}
