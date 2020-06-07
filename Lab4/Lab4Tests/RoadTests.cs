using System;
using Lab4;
using Lab4.passengers;
using Lab4.vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab4Tests
{
    [TestClass]
    public class RoadTests
    {
        Road road;

        [TestInitialize]
        public void Initialize()
        {
            road = new Road();
            Taxi<Passenger> taxi = new Taxi<Passenger>("Ford", 4);
            taxi.GetIn(new Passenger("Andrey", "Andreevich", 33));
            road.AddCarToRoad(taxi);
        }

        [TestMethod]
        public void GetCountOfHumansTest()
        {
            Assert.AreEqual(1, road.GetCountOfHumans());
            Assert.AreNotEqual(3, road.GetCountOfHumans());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Car not found")]
        public void RemoveVehicleTest()
        {
            road.RemoveCarOfRoad(new Taxi<Passenger>("Nissan", 4));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Passenger Ivanovich not found in the vehicle")]
        public void GetOutPassengerTest()
        {
            Bus<Passenger> bus = new Bus<Passenger>("Mercedes", 32);
            Passenger passenger = new Passenger("Ivan", "Ivanovich", 37);
            bus.GetOut(passenger);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No free places, Mr Alexeev")]
        public void testFreePlaces()
        {
            PoliceCar<Policeman> policeCar = new PoliceCar<Policeman>("Toyota", 2);
            policeCar.GetIn(new Policeman("Andrey", "Andreevich", 25));
            policeCar.GetIn(new Policeman("Oleg", "Olegovich", 29));
            policeCar.GetIn(new Policeman("Alex", "Alexeev", 30));
        }

        [TestMethod]
        public void testAddVehicle()
        {
            Assert.AreEqual(road.carsInRoad.Count, 1);
            Taxi<Passenger> taxi = new Taxi<Passenger>("Toyota", 4);
            taxi.GetIn(new Passenger("Dima", "Dimich", 33));
            road.AddCarToRoad(taxi);
            Assert.AreEqual(road.carsInRoad.Count, 2);
        }
    }
}
