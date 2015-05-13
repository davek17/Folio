﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Models
{
    class StockTransaction : Transaction
    {
        public StockTransaction() : base(Guid.NewGuid(), EntryType.Credit, 0.0m)
        {

        }
    }
}
