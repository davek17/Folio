using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DK.Folio.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DK.Folio.Models.Tests
{
    [TestClass()]
    public class TransactionFactoryTests
    {
        [TestMethod()]
        public void GetCreditTransactionTest()
        {
            Transaction t = TransactionFactory.GetTransaction(1, CashTransactionType.Deposit, 10.00m);

            Assert.IsInstanceOfType(t, typeof(CashTransaction));
            Assert.IsTrue(t.Value == 10.00m);
            Assert.IsTrue(t.EntryType == EntryType.Credit);
            Assert.AreEqual(1, t.AccountID);

            CashTransaction c = (CashTransaction)t;

            Assert.IsTrue(c.TransactionType == CashTransactionType.Deposit);
            Assert.IsTrue(c.Value == t.Value);
            Assert.IsTrue(c.EntryType == t.EntryType);
        }

        [TestMethod()]
        public void GetDebitTransactionTest()
        {
            Transaction t = TransactionFactory.GetTransaction(2, CashTransactionType.Withdrawal, 12.00m);

            Assert.IsInstanceOfType(t, typeof(CashTransaction));
            Assert.IsTrue(t.Value == 12.00m);
            Assert.IsTrue(t.EntryType == EntryType.Debit);
            Assert.AreEqual(2, t.AccountID);

            CashTransaction c = (CashTransaction)t;

            Assert.IsTrue(c.TransactionType == CashTransactionType.Withdrawal);
            Assert.IsTrue(c.Value == t.Value);
            Assert.IsTrue(c.EntryType == t.EntryType);
        }
    }
}
