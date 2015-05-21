using DK.Folio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Web
{
    public interface IWebService
    {
        /// <summary>
        /// Get stock data for specified stock code
        /// </summary>
        /// <param name="code">Stock code</param>
        /// <returns>Popluated stock object</returns>
        Stock GetStock(string code);
    }
}
