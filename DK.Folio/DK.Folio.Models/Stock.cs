using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DK.Folio.Models
{
    /// <summary>
    /// Stock object to hold data retrieved from external service.
    /// </summary>
    public class Stock
    {
        private string stockCode;
        private decimal stockPrice;
        private decimal dayHigh;
        private decimal dayLow;
        private decimal _52high;
        private decimal _52low;
        private decimal dayValueChange;
        private decimal peRatio;
        private decimal dividendPS;
        private decimal earningsPS;
        private decimal daysOpen;
        private decimal volume;
        private decimal peg;
        private decimal _50dayAvg;
        private decimal _200dayAvg;
        private decimal yield;
        private decimal _1yrtarget;

        [XmlAttribute("symbol")]
        public string Code { get { return this.stockCode; } set { this.stockCode = value; } }

        [XmlElement("Ask")]
        public decimal Price { get { return this.stockPrice; } set { this.stockPrice = value; } }

        // Financials
        public decimal Change { get { return this.dayValueChange; } set { this.dayValueChange = value; } }
        public decimal DaysHigh { get { return this.dayHigh; } set { this.dayHigh = value; } }
        public decimal DaysLow { get { return this.dayLow; } set { this.dayLow = value; } }
        public decimal YearHigh { get { return this._52high; } set { this._52high = value; } }
        public decimal YearLow { get { return this._52low; } set { this._52low = value; } }
        public decimal DividendYield { get { return this.yield; } set { this.yield = value; } }
        public decimal EarningsPerShare { get { return this.earningsPS; } set { this.earningsPS = value; } }
        public decimal DividendPerShare { get { return this.dividendPS; } set { this.dividendPS = value; } }
        public decimal FiftyDayMovingAverage { get {return this._50dayAvg; } set { this._50dayAvg = value; } }
        public decimal TwoHundredDayMovingAverage { get { return this._200dayAvg; } set { this._200dayAvg = value; } }
        public decimal OneyrTargetPrice { get { return this._1yrtarget; } set { this._1yrtarget = value; } }
        public decimal PERatio { get { return this.peRatio; } set { this.peRatio = value; } }
        public decimal Open { get { return this.daysOpen; } set { this.daysOpen = value; } }
        public decimal Volume { get { return this.volume; } set { this.volume = value; } }
        public decimal PEGRatio { get { return this.peg; } set { this.peg = value; } }

        // Information
        public string Currency { get; set; }
        public string ExDividendDate { get; set; }
        public string DividendPayDate { get; set; }
        public string Name { get; set; }
        public string StockExchange { get; set; }
        
    }
}
