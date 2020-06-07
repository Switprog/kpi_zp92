using Lab4.passengers;
using Lab4.vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Road
    {
        public List<Vehicle<Passenger>> carsInRoad = new List<Vehicle<Passenger>>();

        public int GetCountOfHumans()
        {
            int count = 0;
            foreach (Vehicle<Passenger> vehicle in carsInRoad)
            {
                count += vehicle.CountOfPassengers();
            }
            return count;

        }

        public void AddCarToRoad(Vehicle<Passenger> vehicle)
        {
            carsInRoad.Add(vehicle);
        }

        public void RemoveCarOfRoad(Vehicle<Passenger> vehicle)
        {
            if (!carsInRoad.Contains(vehicle))
                throw new Exception("Car not found");
            else
                carsInRoad.Remove(vehicle);
        }
    }
}
