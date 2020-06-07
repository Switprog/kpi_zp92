using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class MonteCarlo
    {
        private static long iterationsTotal = 10_000_000_0;

        public static long getIterationsTotal()
        {
            return iterationsTotal;
        }

        public double GetPiMono()
        {
            double x, y;
            double radius = 1.0;
            long passed = 0;
            Random rnd = new Random();
            for (int i = 0; i < iterationsTotal; ++i)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                if ((x * x + y * y) < radius)
                    passed++;
            }
            return ((double)passed / iterationsTotal) * 4.0;

        }

        public double GetPiParallel()
        {
            int n = Environment.ProcessorCount;
            long passedTotal = 0, iterationsPerProcess = iterationsTotal / n;
            CountThread[] countThreads = new CountThread[n];
            for (int i = 0; i<n; i++) {
                countThreads[i] = new CountThread(iterationsPerProcess);
                countThreads[i].Start();
            }
            foreach (CountThread countThread in countThreads) {
                countThread.Join();
                passedTotal += countThread.passed;
            }
            return ((double) passedTotal / iterationsTotal) * 4.0;

        }
    }
}
