using System.Collections.Generic;
using System.Linq;
using TestSiteLib;

namespace TestSiteRestAPI.Managers {
    public class TestSitesManager{
        private static int nextId = 1;
        private static List<Testsite> testsiteList = new List<Testsite>(){
            new Testsite(){Id = nextId++, Name = "Roskilde", WaitingTime = 10},
            new Testsite(){Id = nextId++, Name = "Copenhagen", WaitingTime = 11},
            new Testsite(){Id = nextId++, Name = "Vejle", WaitingTime = 4},
            new Testsite(){Id = nextId++, Name = "Greve", WaitingTime = 111},
            new Testsite(){Id = nextId++, Name = "RoskildeWest", WaitingTime = 1},
        };

        public IEnumerable<Testsite> GetAll(string filter, string sort){
            var result = testsiteList;
            if (filter != null){
                result = result.FindAll(t => t.Name.Contains(filter));
                if (sort != null){
                    if (sort.ToLower() == "name")
                        result = result.OrderBy(t => t.Name).ToList();
                }

                if (sort != null){
                    if (sort.ToLower() == "time") {
                        result = result.OrderBy(t => t.WaitingTime).ToList();
                    }
                }

                return result;
            }

            if (sort != null){
                if (sort.ToLower() == "name"){
                            result = result.OrderBy(t => t.Name).ToList();
                }
                if (sort.ToLower() == "time"){
                    result = result.OrderBy(t => t.WaitingTime).ToList();
                }
                return result;
            }

            return result;
        }

        public Testsite AddTestsite(Testsite newTestsite){
            newTestsite.Id = nextId++;
            testsiteList.Add(newTestsite);
            return newTestsite;
        }

        public Testsite DeleteTestsite(int id){
            var result = testsiteList.Find(t => t.Id == id);
            testsiteList.Remove(result);
            return result;
        }

        public Testsite UpdateTestSite(int id, Testsite updaTestsite){
            int index = testsiteList.FindIndex(t => t.Id == id);
            testsiteList[index].WaitingTime = updaTestsite.WaitingTime;
            return testsiteList[index];
        }
    }
}
