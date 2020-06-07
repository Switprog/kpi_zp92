using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab8Tests
{
    [TestClass]
    public class BankTest
    {
        Bank bank;
        int accountCount = (int)(new Random().NextDouble() * 2500);
        int transactionCount = 100000 + ((int)new Random().NextDouble() * 25000);
        BlockingCollection<Account> blockingCollection = new BlockingCollection<Account>();

        [TestInitialize]
        public void setUp()
        {
            bank = new Bank("PrivatBank");
            for (int i = 0; i < accountCount; i++) {
                bank.AddAccount("Svetlana");
                foreach (Account account in bank.Accounts)
                {
                    account.Recharge((int)(new Random().NextDouble() * 1000));
                }
            }
            Console.WriteLine("Total bank balance before transactions: " + bank.GetTotalBalance() + " $");
        }

        private async Task Transfer() {
            List<Task> tasks = new List<Task>();
            using (blockingCollection) {
                for (int i = 0; i < transactionCount; i++)
                {
                    int sourceId = (int)(new Random().NextDouble() * accountCount);
                    int destId = (int)(new Random().NextDouble() * accountCount);
                    Task t = Task.Run(() =>
                        bank.TransferMoney(bank.GetAccount(sourceId), bank.GetAccount(destId), (int)(new Random().NextDouble() * 10000)));
                    tasks.Add(t);
                }
                {
                    await Task.WhenAll(tasks);
                }
            }
        }

        [TestMethod]
        public async Task TotalBalanceTest()
        {
            long expected = bank.GetTotalBalance();
            await Transfer();
            long actual = bank.GetTotalBalance();
            Console.WriteLine("Total bank balance after transactions: " + actual + " $");
            Assert.AreEqual(expected, actual);
        }
    }
}
