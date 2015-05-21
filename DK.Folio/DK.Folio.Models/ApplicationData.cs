﻿using System;
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
        /// Gets or sets the list of accounts
        /// </summary>
        public List<Account> Accounts { get; set; }
    }
}
