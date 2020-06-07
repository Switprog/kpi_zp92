using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            dict.Add("Meat", 55.5);
            dict.Add("Milk", 30.3);
            dict.Add("Chocolate", 25.8);
            dict.Add("Bread", 15.4);
            CashRegister cashRegister = new CashRegister(dict);
            cashRegister.AddGood("Chocolate", 2);
            cashRegister.AddGood("Bread", 4);
            cashRegister.AddGood("Meat", 5);
            cashRegister.AddGood("Milk", 3);
            cashRegister.AddGood("Chocolate", 2);
            Console.WriteLine(cashRegister.GetCheck());
            Console.ReadKey();
        }
    }
}
