using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class CashRegister
    {
        private Dictionary<string, int> goods;
        private Dictionary<string, double> prices;

        public CashRegister(Dictionary<string, double> prices)
        {
            this.prices = prices;
            goods = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Goods
        {
            get { return goods; }
        }

        public void AddGood(string name, int count)
        {
            if (goods.ContainsKey(name))
                goods[name]++;
            else
                goods.Add(name, count);
        }

        public double GetPrice(string name)
        {
            return prices[name];
        }

        public string GetCheck()
        {
            SortedDictionary<string, int> sortedGoods = new SortedDictionary<string, int>(goods);
            string check = "";
            double total = 0;
            foreach (string key in sortedGoods.Keys)
            {
                check += key + "   " + GetPrice(key) + " hrn  x" + goods[key]
                    + "  " + goods[key] * GetPrice(key) + " hrn\n";
                total += goods[key] * GetPrice(key);
            }

            return check + "Total sum = " + total + " hrn";

        }
    }
}
