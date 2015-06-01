using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    /// <summary>
    /// Transactions created through the factory automatically determine transaction type.
    /// </summary>
    public static class TransactionFactory
    {
        /// <summary>
        /// Create a new transaction type
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="transactionType">Cash transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction note</param>
        /// <param name="currency">Currency code</param>
        /// <returns>Cash Transaction</returns>
        public static Transaction GetTransaction(Guid accountId, CashTransactionType transactionType, DateTime transactionDate, decimal value, string note, Currency currency)
        {
            EntryType entryType;

            switch (transactionType)
            {
                case CashTransactionType.Deposit:
                case CashTransactionType.InterestReceived:
                    entryType = EntryType.Credit;
                    break;
                case CashTransactionType.InterestPayment:
                case CashTransactionType.Withdrawal:
                    entryType = EntryType.Debit;
                    break;
                default:
                    return null;
            }

            return new CashTransaction(accountId, entryType, transactionType, transactionDate, value, note, currency);
        }
    
        /// <summary>
        /// Create a new transaction type
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="transactionType">Transaction type</param>
        /// <param name="transactionDate">Transaction date</param>
        /// <param name="stockCode">Stock code</param>
        /// <param name="quantity">Stock unit quantity</param>
        /// <param name="value">Transaction value</param>
        /// <param name="note">Transaction notes</param>
        /// <param name="currency">Currency</param>
        public static Transaction GetTransaction(Guid accountId, StockTransactionType transactionType, DateTime transactionDate, string stockCode, decimal quantity, decimal value, string note,Currency currency)
        {
            EntryType entryType;

            switch (transactionType)
            {
                case StockTransactionType.DividendReceived:
                case StockTransactionType.Sale:
                    entryType = EntryType.Credit;
                    break;
                case StockTransactionType.DividendReinvested:
                case StockTransactionType.Purchase:
                    entryType = EntryType.Debit;
                    break;
                default:
                    return null;
            }

            return new StockTransaction(accountId, entryType, transactionType, transactionDate, stockCode, quantity, value, note, currency);
        }
    }
}
