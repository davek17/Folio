using DK.Folio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.Web
{
    public class YahooService : IWebService
    {
        /// <summary>
        /// Web client
        /// </summary>
        WebClient client;

        /// <summary>
        /// initializes a new instance of the <see cref="YahooService"/> class
        /// </summary>
        public YahooService()
        {
            client = new WebClient();
        }

        /// <summary>
        /// Load Stock Data
        /// </summary>
        /// <param name="code">Stock Code</param>
        /// <returns>True On Success</returns>
        public Stock GetStock(string code)
        {
            string url = "http://finance.yahoo.com/d/quotes.csv?s=" + code + "&f=nsl1hgkjw1rdeoqxvr5m3m4yt8";

            string returnCSV = client.DownloadString(url);
            return this.PopulateStock(returnCSV);            
        }


        /// <summary>
        /// Extracts values from CSV string downloaded.
        /// </summary>
        /// <param name="csvstring">Downloaded CSV string</param>
        private Stock PopulateStock(string csvstring)
        {
            Stock stock = new Stock();

            string[] splitString = csvstring.Split(',');
            stock.Name = splitString[0].Replace("\"", "");  // Strip quotations.
            stock.Code = splitString[1].Replace("\"", "");  // Strip quotations.

            if(splitString[2] == "N/A")
            {
                throw new Exception("Stock not found.");
            }

            stock.Price = ToDecimal(splitString[2]);
            stock.DaysHigh = ToDecimal(splitString[3]);
            stock.DaysLow = ToDecimal(splitString[4]);
            stock.YearHigh = ToDecimal(splitString[5]);
            stock.YearLow = ToDecimal(splitString[6]);
            stock.Change = ToDecimal(splitString[7]);
            stock.PERatio = ToDecimal(splitString[8]);
            stock.DividendPerShare = ToDecimal(splitString[9]);
            stock.EarningsPerShare = ToDecimal(splitString[10]);
            stock.Open = ToDecimal(splitString[11]);

            stock.ExDividendDate = splitString[12];
            stock.StockExchange = splitString[13];
            stock.Volume = ToDecimal(splitString[14]);
            stock.PEGRatio = ToDecimal(splitString[15]);
            stock.FiftyDayMovingAverage = ToDecimal(splitString[16]);
            stock.TwoHundredDayMovingAverage = ToDecimal(splitString[17]);
            stock.DividendYield = ToDecimal(splitString[18]);
            stock.OneyrTargetPrice = ToDecimal(splitString[19]);

            return stock;
        }

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Decimal value of string or 0</returns>
        private static decimal ToDecimal(string text)
        {
            decimal val;

            if(decimal.TryParse(text, out val))
            {
                return val;
            }
            else
            {
                return default(decimal);
            }
        }

    }
}
