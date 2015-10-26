using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    /// <summary>
    /// Root applicaiton data object
    /// </summary>
    public class ApplicationData
    {
        /// <summary>
        /// Accounts list
        /// </summary>
        private List<Account> accounts;

        /// <summary>
        /// Gets or sets the list of accounts
        /// </summary>
        public List<Account> Accounts
        {
            get
            {
                if (this.accounts == null)
                {
                    this.accounts = new List<Account>();
                }
                return this.accounts;
            }

            set
            {
                this.accounts = value;
            }
        }

        /// <summary>
        /// Application data path
        /// </summary>
        public string FilePath { get; set; }
    }
}
