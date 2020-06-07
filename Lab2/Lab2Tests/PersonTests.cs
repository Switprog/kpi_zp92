using System;
using System.IO;
using Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2Tests
{
    [TestClass]
    public class PersonTests
    {
        private string fileName;
        private Person person;

        [TestInitialize]
        public void TestInitialize()
        {
            fileName = "C:/Users/dafna/Desktop/Светлана/Prog/Lab2/Person.json";
            person = new Person("Ivan", "Ivanovich", "Ivanovsky", 19, "male");
            person.ToJson(fileName);
        }

        [TestMethod]
        public void LoadFromJsonTest()
        {
            Person personFromJson = Person.FromJson(fileName);
            Assert.IsTrue(person.Equals(personFromJson));
        }
    }
}
