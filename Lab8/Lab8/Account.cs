using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public class Account
    {
        private int balance;
        private string name;
        private long id;


        public Account(long id, string name)
        {
            this.name = name;
            this.balance = 0;
            this.id = id;
        }

        public int Balance
        {
            get { return balance; }
        }

        public long Id
        {
            get { return id; }
        }

        public void Recharge(int amount)
        {
            balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
    }
}
