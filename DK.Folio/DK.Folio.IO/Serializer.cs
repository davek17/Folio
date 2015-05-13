using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.IO
{
    /// <summary>
    /// Serialize and deserialize portfolios
    /// </summary>
    public class Serializer
    {

        public void Serialize()
        {
        /* Here we will iterate through each portfolio
         * convert each transaction to a serializable transaction
         * and then write to XML
         */
        }

        public void Deserialize()
        {
            /* Here we will read each transaction into a serializable transaction, then convert into
             * normal transactions through the factory methods
             * and finally convert into portfolios.
             */
        }

    }
}
