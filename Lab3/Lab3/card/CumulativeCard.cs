using Lab3.card_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.card
{
    public class CumulativeCard : Card // накопительная
    {
        private int balance;
        private int travelCost;

        public CumulativeCard(long id, int balance, int travelCost) :
            base(id, OwnerType.ORDINARY)
        {
            this.balance = balance;
            this.travelCost = travelCost;
        }

        public void recharge(int sum)
        {
            balance += sum;
        }

        public override bool Verify()
        {
            if (balance >= travelCost)
            {
                balance -= travelCost;
                return true;
            }
            return false;
        }
        
        public override string ToString()
        {
            return "Card type: cumulative card\n" +
                    "Balance: " + balance + "\n" +
                    "Travel cost: " + travelCost + "\n";
        }
    }
}
