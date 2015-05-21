using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    /// <summary>
    /// Transaction base class
    /// </summary>
    public abstract class Transaction
    {
        /// <summary>
        /// Account ID
        /// </summary>
        private Guid accountId;

        /// <summary>
        /// Transaction type
        /// </summary>
        private EntryType entryType;

        /// <summary>
        /// Transaction value
        /// </summary>
        private decimal value;

        /// <summary>
        /// Currency
        /// </summary>
        private Currency currency;

        /// <summary>
        /// Transaction date
        /// </summary>
        private DateTime transactionDate;

        /// <summary>
        /// Transaction note
        /// </summary>
        private string note;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <remarks>For serialisation only</remarks>
        internal Transaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <param name="entryType">Transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction note</param>
        /// <param name="currency">Currency code</param>
        /// <remarks>Create new transactions through the transaction factory</remarks>
        internal Transaction(Guid accountId, EntryType entryType, DateTime transactionDate, decimal value, string note, Currency currency)
        {
            this.accountId = accountId;
            this.entryType = entryType;
            this.value = value;
            this.transactionDate = transactionDate;
            this.currency = currency;
            this.note = note;
        }

        /// <summary>
        /// Gets or sets the transaction type
        /// </summary>
        public EntryType EntryType
        { 
            get
            {
                return this.entryType;
            }

            set
            {
                this.entryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the transaction value
        /// </summary>
        public decimal Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
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
        /// Gets or sets the currency
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
        /// Gets or sets the transaction date
        /// </summary>
        public DateTime TransactionDate
        {
            get
            {
                return this.transactionDate;
            }

            set
            {
                this.transactionDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the transaction note
        /// </summary>
        public string Note
        {
            get
            {
                return this.note;
            }

            set
            {
                this.note = value;
            }
        }

    }
}
