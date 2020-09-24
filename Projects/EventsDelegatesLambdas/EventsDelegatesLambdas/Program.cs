using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int> multDel = (m, n, o) => m * n * o;
            Console.WriteLine(multDel(4, 3, 7));
            Console.ReadKey();
        }
    }
}
