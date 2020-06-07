using Lab4.passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.vehicles
{
    public class FireTrack<T> : Car<Firefighter>
    {
        public FireTrack(string name, int passengerCapacity)
            : base(name, passengerCapacity)
        {

        }
    }
}
