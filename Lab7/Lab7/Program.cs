using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            long start = Environment.TickCount;
            double monoPi = new MonteCarlo().GetPiMono();
            long finish = Environment.TickCount - start;
            Console.WriteLine("Mono time " + finish);

            start = Environment.TickCount;
            double parallelPi = new MonteCarlo().GetPiParallel();
            finish = Environment.TickCount - start;
            Console.WriteLine("Parallel time " + finish + "ms");

            Console.WriteLine("Mono Pi: " + monoPi);
            Console.WriteLine("Parallel Pi: " + parallelPi);
            Console.ReadKey();
        }
    }
}
