using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSiteRestAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSiteLib;

namespace TestSiteRestAPI.Managers.Tests{
    [TestClass()]
    public class TestSitesManagerTests{
        private static TestSitesManager manager;
        private static IEnumerable<Testsite> testList;

        [TestInitialize]
        public void Init(){
            manager = new TestSitesManager();
            testList = new List<Testsite>();
        }

        [TestMethod()]
        public void GetAllTest(){
            testList = manager.GetAll("", "");
            var result = testList.ElementAt(0);
            Assert.IsNotNull(testList);
            //Giver problemer fordi testene ikke kører i rækkefølge fra top til bund 
            //Assert.AreEqual(5, testList.Count());
            Assert.AreEqual("Roskilde", result.Name );
            testList = manager.GetAll("Roskilde", "name");
            Assert.AreEqual(testList.Count(), 2);
            Assert.AreEqual("Roskilde", testList.ElementAt(0).Name);

        }

        [TestMethod()]
        public void AddDeleteTestsiteTest(){
            Testsite testAdd = new Testsite(){Id = 6, Name = "Greve", WaitingTime = 5};
            manager.AddTestsite(testAdd);
            testList = manager.GetAll("", "");
            Assert.AreEqual(6, testList.Count());
            manager.DeleteTestsite(6);
            testList = manager.GetAll("", "");
            Assert.AreEqual(5, testList.Count());

        }


        [TestMethod()]
        public void UpdateTestSiteTest() {
            manager.UpdateTestSite(5, 9);
            testList = manager.GetAll("", "");
            Assert.AreEqual(9, testList.ElementAt(4).WaitingTime);
        }
    }
}


namespace TestSiteRestAPITests.Managers {
    internal class TestSitesManagerTests {
    }
}
