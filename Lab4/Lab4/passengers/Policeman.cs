using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.passengers
{
    public class Policeman : Passenger
    {
        public Policeman(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }
    }
}
