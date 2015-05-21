using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    public class StockTransaction : Transaction
    {
        /// <summary>
        /// Stock transaction type
        /// </summary>
        private StockTransactionType transactionType;

        /// <summary>
        /// Stock code
        /// </summary>
        private string stockCode;

        /// <summary>
        /// Stock qunatity
        /// </summary>
        private decimal quantity;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockTransaction"/> class
        /// </summary>
        /// <remarks>For serialisation</remarks>
        private StockTransaction()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockTransaction"/> class
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="entryType">Entry type</param>
        /// <param name="transactionType">Transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="stockCode">Stock code</param>
        /// <param name="quantity">Stock unit quantity</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction notes</param>
        /// <param name="currency">Currency</param>
        public StockTransaction(Guid accountId, EntryType entryType, StockTransactionType transactionType, DateTime transactionDate, string stockCode, decimal quantity, decimal value, string note, Currency currency)
            : base(accountId, entryType, transactionDate, value, note, currency)
        {
            this.transactionType = transactionType;
            this.stockCode = stockCode;
            this.quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the stock transaction type
        /// </summary>
        public StockTransactionType TransactionType
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

        /// <summary>
        /// Gets or sets the stock code
        /// </summary>
        public string StockCode
        {
            get
            {
                return this.stockCode;
            }

            set
            {
                this.stockCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the stock unit quantity
        /// </summary>
        public decimal Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
            }
        }
    }
}
