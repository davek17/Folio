using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DK.Folio.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DK.Folio.Models;
using System.IO;
namespace DK.Folio.IO.Tests
{
    [TestClass()]
    public class SerializerTests
    {
        /// <summary>
        /// Path for testing of file output
        /// </summary>
        const string path =  @"C:\Users\dtkirkham\Documents\GitHub\Folio\DK.Folio\TestData\accounts.txt";

        [TestMethod()]
        public void SerializeTest()
        {           

            if(File.Exists(path))
            {
                File.Delete(path);
            }

            ApplicationData data = new ApplicationData();
            data.FilePath = path;

            List<Account> accountsList = new List<Account>();

            Account account = new Account("", Currency.GBP);
            Transaction c = TransactionFactory.GetTransaction(account.AccountID, CashTransactionType.Deposit, DateTime.Today, 10.00m, "", Currency.GBP);
            Transaction c2 = TransactionFactory.GetTransaction(account.AccountID, CashTransactionType.Withdrawal, DateTime.Today, 5.00m, "Five pounds", Currency.GBP);

            account.AddTransaction(c);
            account.AddTransaction(c2);

            accountsList.Add(account);

            data.Accounts = accountsList;

            Serializer.Serialize(data);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            this.SerializeTest();

            ApplicationData desData = Serializer.Deserialize(path);

            Assert.AreEqual(5.00m, desData.Accounts[0].Balance);

        }

        [TestMethod()]
        public void SerializeStockTest()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            ApplicationData data = new ApplicationData();
            data.FilePath = path;

            List<Account> accountsList = new List<Account>();

            Account account = new Account("", Currency.GBP);
            Transaction c = TransactionFactory.GetTransaction(account.AccountID, StockTransactionType.Purchase, DateTime.Today, "LLOY.L", 50m, 10.00m, "", Currency.GBP);
            Transaction c2 = TransactionFactory.GetTransaction(account.AccountID, StockTransactionType.Sale, DateTime.Today, "LLOY.L", 50m, 20.00m, "Sale", Currency.GBP);

            account.AddTransaction(c);
            account.AddTransaction(c2);

            accountsList.Add(account);

            data.Accounts = accountsList;

            Serializer.Serialize(data);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void DeserializeStockTest()
        {
            this.SerializeStockTest();

            ApplicationData desData = Serializer.Deserialize(path);

            Assert.AreEqual(10.00m, desData.Accounts[0].Balance);
        }

        [TestMethod()]
        public void SerializeMixTest()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            ApplicationData data = new ApplicationData();
            data.FilePath = path;

            List<Account> accountsList = new List<Account>();

            Account account = new Account("", Currency.GBP);
            Transaction c = TransactionFactory.GetTransaction(account.AccountID, CashTransactionType.Deposit, DateTime.Today, 10.00m, "", Currency.GBP);
            Transaction c2 = TransactionFactory.GetTransaction(account.AccountID, CashTransactionType.Withdrawal, DateTime.Today, 5.00m, "Five pounds", Currency.GBP);
            Transaction c3 = TransactionFactory.GetTransaction(account.AccountID, StockTransactionType.Purchase, DateTime.Today, "LLOY.L", 50m, 10.00m, "", Currency.GBP);
            Transaction c4 = TransactionFactory.GetTransaction(account.AccountID, StockTransactionType.Sale, DateTime.Today, "LLOY.L", 50m, 20.00m, "Sale", Currency.GBP);

            account.AddTransaction(c);
            account.AddTransaction(c2);
            account.AddTransaction(c3);
            account.AddTransaction(c4);

            accountsList.Add(account);

            data.Accounts = accountsList;

            Serializer.Serialize(data);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void DeserializeMixTest()
        {
            this.SerializeMixTest();

            ApplicationData desData = Serializer.Deserialize(path);

            Assert.AreEqual(15.00m, desData.Accounts[0].Balance);
        }
    }
}
