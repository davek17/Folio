using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DK.Folio.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DK.Folio.Models;
namespace DK.Folio.Web.Tests
{
    [TestClass()]
    public class YahooServiceTests
    {
        [TestMethod()]
        public void GetStockTest()
        {
            IWebService service = new YahooService();

            Stock s = service.GetStock("LLOY.L");

            Assert.AreEqual("LLOY.L", s.Code);
        }
    }
}
