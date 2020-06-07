using System;
using System.Collections.Generic;

namespace Lab8
{
    public class Bank
    {
        private string name;
        private List<Account> accounts = new List<Account>();
        private long curtId;

        public Bank(string name)
        {
            this.name = name;
            curtId = 0;
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public void AddAccount(string accountName)
        {
            accounts.Add(new Account(curtId, accountName));
            curtId++;
        }

        public Account GetAccount(long id)
        {
            return accounts.Find(account => account.Id == id);
        }

        public void TransferMoney(Account source, Account destination, int sum)
        {
            if (source.Id > destination.Id)
            {
                lock(destination) {
                    lock(source) {
                        if (source.Withdraw(sum))
                            destination.Recharge(sum);
                    }
                }
            }
            else
            {
                lock(source) {
                    lock(destination) {
                        if (source.Withdraw(sum))
                            destination.Recharge(sum);
                    }
                }
            }
        }

        public long GetTotalBalance()
        {
            long ans = 0;
            foreach (Account account in accounts)
                ans += account.Balance;
            return ans;
        }
    }
}
