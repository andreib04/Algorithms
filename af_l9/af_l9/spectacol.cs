using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_l9
{
    public class spectacol
    {
        public int tInitial;
        public int tFinal;

        public spectacol(int tInitial, int tFinal)
        {
            this.tInitial = tInitial;
            this.tFinal = tFinal;
        }

        public void View()
        {
            Console.WriteLine(tInitial + " " + tFinal); 
        }
    }
}
