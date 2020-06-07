using Lab4.passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.vehicles
{
    public abstract class Vehicle<T> where T : Passenger
    {
        protected string name;
        protected int passengerCapacity;
        protected List<T> passengers;


        public Vehicle(string name, int passengerCapacity)
        {
            this.name = name;
            this.passengerCapacity = passengerCapacity;
            passengers = new List<T>();
        }

        public void GetIn(T passenger)
        {
            if (passengers.Count() == passengerCapacity)
                throw new Exception("No free places, Mr " + passenger.lastName);
            else
                passengers.Add(passenger);
        }

        public void GetOut(T passenger)
        {
            if (!passengers.Contains(passenger))
                throw new Exception("Passenger " + passenger.lastName + " not found in the vehicle");
        }

        public int CountOfPassengers()
        {
            return passengers.Count();
        }
    }
}
