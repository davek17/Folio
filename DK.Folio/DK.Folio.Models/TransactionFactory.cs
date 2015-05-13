using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    /// <summary>
    /// Transactions created through the factory automatically determine transaciton type.
    /// </summary>
    public static class TransactionFactory
    {
        /// <summary>
        /// Create a new transaction type
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="transactionType">Cash transaction type</param>
        /// <param name="value">Transaction value</param>
        /// <returns>Cash Transaction</returns>
        public static Transaction GetTransaction(Guid accountId, CashTransactionType transactionType, decimal value)
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

            return new CashTransaction(accountId, entryType, transactionType, value);
        }
    }
}
