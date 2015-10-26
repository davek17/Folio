using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    public class Account
    {
        /// <summary>
        /// List of transactions
        /// </summary>
        private List<Transaction> transactions = new List<Transaction>();

        /// <summary>
        /// Account ID
        /// </summary>
        private Guid accountId;

        /// <summary>
        /// Account balance
        /// </summary>
        private decimal balance = 0.0m;

        /// <summary>
        /// The account name
        /// </summary>
        private string accountName;

        /// <summary>
        /// The account description
        /// </summary>
        private string accountDescription;

        /// <summary>
        /// Currency
        /// </summary>
        private Currency currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        private Account()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class
        /// </summary>
        /// <param name="accountName">Account Description</param>
        /// <param name="currency">Account Currency</param>
        /// <param name="description">The description.</param>
        public Account(string accountName, Currency currency, string description = "")
        {
            if(this.accountId == new Guid())
            {
                this.accountId = Guid.NewGuid();
            }

            this.currency = Currency.GBP;
            this.transactions = new List<Transaction>();            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="accountId">Account ID</param>
        public Account(Guid accountId) : this()
        {
            this.accountId = accountId;
            
        }

        /// <summary>
        /// Add a transaction to this account
        /// </summary>
        /// <param name="transaction"></param>
        public void AddTransaction(Transaction transaction)
        {
            this.transactions.Add(transaction);
        }

        /// <summary>
        /// Gets the list of transactions for this account
        /// </summary>
        public IReadOnlyCollection<Transaction> Transaction
        {
            get
            {
                return this.transactions.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets or sets the account ID
        /// </summary>
        public Guid AccountID
        {
            get
            {
                return this.accountId;
            }

            set
            {
                this.accountId = value;
            }
        }

        /// <summary>
        /// Gets the account balance
        /// </summary>
        public decimal Balance
        {
            get
            {
                if(this.balance == 0.00m)
                {
                    this.CalculateBalance();
                }
                return this.balance;
            }
        }

        /// <summary>
        /// Gets or sets the currency code
        /// </summary>
        public Currency Currency
        {
            get
            {
                return this.currency;
            }

            set
            {
                this.currency = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string AccountDescription
        {
            get
            {
                return this.accountDescription;
            }

            set
            {
                this.accountDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName
        {
            get
            {
                return this.accountName;
            }

            set
            {
                this.accountName = value;
            }
        }

        /// <summary>
        /// Calculate the account balance
        /// </summary>
        private void CalculateBalance()
        {
            foreach(Transaction t in this.transactions)
            {
                if(t.EntryType == EntryType.Credit)
                {
                    balance += t.Value;
                }

                if(t.EntryType == EntryType.Debit)
                {
                    balance -= t.Value;
                }
            }
        }
    }
}
