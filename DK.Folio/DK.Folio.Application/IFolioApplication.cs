using DK.Folio.Models;
using System;
using System.Collections.Generic;
namespace DK.Folio.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFolioApplication
    {
        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        IReadOnlyCollection<Account> Accounts { get; }

        /// <summary>
        /// Adds the transaction.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="transactionDate">The transaction date.</param>
        /// <param name="value">The value.</param>
        /// <param name="note">The note.</param>
        /// <param name="currency">The currency.</param>
        
        void AddTransaction(Account account, CashTransactionType transactionType, DateTime transactionDate, decimal value, string note = "", Currency currency = Currency.GBP);
        /// <summary>
        /// Adds the transaction.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="transactionDate">The transaction date.</param>
        /// <param name="stockCode">The stock code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="value">The value.</param>
        /// <param name="note">The note.</param>
        /// <param name="currency">The currency.</param>
        void AddTransaction(Account account, StockTransactionType transactionType, DateTime transactionDate, string stockCode, decimal quantity, decimal value, string note = "", Currency currency = Currency.GBP);
        
        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="currency">The currency.</param>
        void CreateAccount(string description, Currency currency = Currency.GBP);

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        Account GetAccount(Guid accountId);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
