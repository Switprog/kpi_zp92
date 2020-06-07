using Lab4.passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.vehicles
{
    public class PoliceCar<T> : Car<Policeman>
    {
        public PoliceCar(string name, int passengerCapacity)
            : base(name, passengerCapacity)
        {

        }
    }
}
