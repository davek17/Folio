using DK.Folio.IO;
using DK.Folio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Application
{
    public class FolioApplication
    {
        /// <summary>
        /// Application data object
        /// </summary>
        private ApplicationData appData;

        /// <summary>
        /// initializes a new instance of the <see cref="FolioApplication"/> class.
        /// </summary>
        /// <param name="filePath">File path for applicaiton data.  If not set, will default to users documents folder</param>
        public FolioApplication(string filePath = "")
        {
            if(string.IsNullOrWhiteSpace(filePath))
            {
                string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Folio";
                if(!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                filePath = folderPath + "\\AppData.xml";
            }
            this.appData = Serializer.Deserialize(filePath);
            
            if(this.appData.FilePath != filePath)
            {
                this.appData.FilePath = filePath;
                this.Save();
            }
        }

        /// <summary>
        /// Get a list of accounts
        /// </summary>
        public IReadOnlyCollection<Account> Accounts
        {
            get
            {
                return appData.Accounts.AsReadOnly();
            }
        }

        /// <summary>
        /// Get an account by ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Account by ID</returns>
        public Account GetAccount(Guid accountId)
        {
            return appData.Accounts.FirstOrDefault(x => x.AccountID == accountId);
        }

        /// <summary>
        /// Save data
        /// </summary>
        public void Save()
        {
            Serializer.Serialize(appData);
        }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="description"></param>
        /// <param name="currency"></param>
        public void CreateAccount(string description, Currency currency = Currency.GBP)
        {
            Account account = new Account(description, currency);
            appData.Accounts.Add(account);
            this.Save();
        }

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="transactionType">Cash transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction note</param>
        /// <param name="currency">Currency code [Default GBP]</param>
        /// <returns>Cash Transaction</returns>
        public void AddTransaction(Account account, CashTransactionType transactionType, DateTime transactionDate, decimal value, string note = "", Currency currency = Currency.GBP)
        {
            account.AddTransaction(TransactionFactory.GetTransaction(account.AccountID, transactionType, transactionDate, value, note, currency));
        }

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="transactionType">Transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="stockCode">Stock code</param>
        /// <param name="quantity">Stock unit quantity</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction notes</param>
        /// <param name="currency">Currency</param>
        public void AddTransaction(Account account, StockTransactionType transactionType, DateTime transactionDate, string stockCode, decimal quantity, decimal value, string note = "", Currency currency = Currency.GBP)
        {
            account.AddTransaction(TransactionFactory.GetTransaction(account.AccountID, transactionType, transactionDate, stockCode, quantity, value, note, currency));
        }
    }
}
