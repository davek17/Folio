using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DK.Folio.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace DK.Folio.Application.Tests
{
    [TestClass()]
    public class FolioApplicationTests
    {

        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Folio\\TestAppData.xml";
        FolioApplication app;

        [TestInitialize]
        public void ClearDown()
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            app = new FolioApplication(path);
        }

        [TestMethod()]
        public void FolioApplicationTest()
        {
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void GetAccountTest()
        {
            Assert.IsTrue(app.Accounts.Count == 0); 

            app.CreateAccount("Test Account");

            Assert.IsTrue(app.Accounts.Count == 1);            
        }

        [TestMethod()]
        public void AddTransactionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTransactionTest1()
        {
            Assert.Fail();
        }
    }
}
