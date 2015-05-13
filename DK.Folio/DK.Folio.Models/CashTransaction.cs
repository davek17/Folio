using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    public class CashTransaction : Transaction
    {
        /// <summary>
        /// Cash transaction type
        /// </summary>
        private CashTransactionType transactionType;

        public CashTransaction()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CashTransaction"/> class.
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="entryType">Entry type</param>
        /// <param name="transactionType">Transaction type</param>
        /// <param name="value">Transaction value</param>
        public CashTransaction(Guid accountId, EntryType entryType, CashTransactionType transactionType, decimal value) : base (accountId, entryType, value)
        {
            this.transactionType = transactionType;
        }

        /// <summary>
        /// Gets or sets the transaction type
        /// </summary>
        public CashTransactionType TransactionType
        {
            get
            {
                return this.transactionType;
            }

            set
            {
                this.transactionType = value;
            }
        }
    }
}
