using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    class CountThread
    {
        public long passed;
        private long iterationsPerProcess;
        private Thread thread;

        public CountThread(long iterationsPerProcess)
        {
            this.iterationsPerProcess = iterationsPerProcess;
            thread = new Thread(new ThreadStart(this.RunThread));
        }

        public void Start() => thread.Start();
        public void Join() => thread.Join();
        public bool IsAlive => thread.IsAlive;


        public void RunThread()
        {
            Random rnd = new Random();
            double x, y;
            double radius = 1.0;
            passed = 0;
            for (int i = 0; i < iterationsPerProcess; i++)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                if ((x * x + y * y) < radius)
                    passed++;
            }
        }
    }
}
