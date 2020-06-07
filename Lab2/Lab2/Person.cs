using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Lab2
{
    public class Person
    {
        private string first_name;
        private string last_name;
        private string surname;
        private int age;
        private string gender;

        public Person(string first_name, string last_name, string surname,
            int age, string gender)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (first_name == p.first_name) && (last_name == p.last_name)
                    && (surname == p.surname) && (age == p.age) && (gender == p.gender);
            }
        }

        public override int GetHashCode()
        {
            return (int)(first_name.GetHashCode() + last_name.GetHashCode() 
                + surname.GetHashCode() + 31*age + gender.GetHashCode());
        }

        public void ToJson(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public static Person FromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Person>(jsonString);
        }
    }
}
