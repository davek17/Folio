using DK.Folio.Application;
using DK.Folio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.ViewModels
{
    public class ToolBarViewModel : ViewModel
    {
        /// <summary>
        /// The accounts list
        /// </summary>
        private IReadOnlyCollection<Account> accountsList;

        /// <summary>
        /// The selected account
        /// </summary>
        private Account selectedAccount;

        /// <summary>
        /// The folio application
        /// </summary>
        private IFolioApplication folioApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBarViewModel"/> class.
        /// </summary>
        /// <param name="folioApplication">The folio application.</param>
        public ToolBarViewModel(IFolioApplication folioApplication)
        {
            this.folioApplication = folioApplication;
            this.AccountsList = folioApplication.Accounts;

            this.SelectedAccount = this.accountsList.FirstOrDefault();
            
        }

        /// <summary>
        /// Gets the accounts list.
        /// </summary>
        /// <value>
        /// The accounts list.
        /// </value>
        public IReadOnlyCollection<Account> AccountsList
        {
            get
            {
                return this.accountsList;
            }
            private set
            {
                this.accountsList = value;
                this.NotifyPropertyChanged("AccountsList");
            }
        }

        /// <summary>
        /// Gets or sets the selected account.
        /// </summary>
        /// <value>
        /// The selected account.
        /// </value>
        public Account SelectedAccount
        {
            get
            {
                return this.selectedAccount;
            }

            set
            {
                this.selectedAccount = value;
                this.NotifyPropertyChanged("SelectedAccount");
            }
        }
    }
}
