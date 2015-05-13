using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
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
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <param name="entryType">Transaction type</param>
        /// <param name="value">Transaction value</param>
        public Transaction(Guid accountId, EntryType entryType, decimal value)
        {
            this.accountId = accountId;
            this.entryType = entryType;
            this.value = value;
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
    }
}
