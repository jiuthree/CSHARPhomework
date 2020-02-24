using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int n=2;
            int j = 0;
            bool[] isPrime=new bool[101];
            for (int i = 0; i < 100; i++) { isPrime[i + 1] = true; }
            for (; n < 101; n++) {
                if (isPrime[n]) {
                    Console.WriteLine(n);
                    for (j = 2 * n; j < 101; j = j + n) { isPrime[j] = false; }
                }


            }
        }
    }
}
