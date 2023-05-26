using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_c18_05
{
    public class TRIDATA
    {
        public int l, c, v;
        public TRIDATA(int l, int c, int v) 
        {
            this.l = l;
            this.c = c;
            this.v = v;
        }

        public string View()
        {
            return l + " " + c + " " + v;
        }
    }

    public class Queue_
    {
        TRIDATA[] v;

        public Queue_()
        {
            v = new TRIDATA[0];
        }

        public string View()
        {
            string toR = "";
            for (int i = 0; i < v.Length; i++)
                toR += v[i].View();
            return toR;
        }

        public bool isMpty()
        {
            if(v.Length == 0) return true;
            return false;
        }

        public void Push(TRIDATA x)
        {
            TRIDATA[] tmp = new TRIDATA[v.Length+1];
            for(int i = 0; i < v.Length; i++)
                tmp[i+1] = v[i];
            tmp[0] = x;
            v = tmp;
        }

        public TRIDATA Pop()
        {
            TRIDATA toR = v[v.Length - 1];
            TRIDATA[] tmp = new TRIDATA[v.Length - 1];
            for(int i = 0; i < v.Length - 1; i++)
                tmp[i] = v[i];
            v = tmp;
            return toR;
        }
    }
}
