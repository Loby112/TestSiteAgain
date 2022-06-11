using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestSiteRestAPI.Managers;
using TestSiteLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestSiteRestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TestSitesController : ControllerBase{
        private TestSitesManager manager = new TestSitesManager();
        // GET: api/<TestSitesController>
        [HttpGet]
        public ActionResult<IEnumerable<Testsite>> Get([FromQuery] string filter, [FromQuery] string sort) {
            return Ok(manager.GetAll(filter, sort));
        }

        // GET api/<TestSitesController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<TestSitesController>
        [HttpPost]
        public ActionResult<Testsite> Post([FromBody] Testsite value){
            if (value.WaitingTime < 0 || value.Name.Length < 1){
                return BadRequest();
            }

            var result = manager.AddTestsite(value);
            return Created("api/testsites/" + result.Id, result);
        }

        // PUT api/<TestSitesController>/5
        [HttpPut("{id}")]
        public ActionResult<Testsite> Put(int id, [FromBody] Testsite value) {
            if (value.WaitingTime < 0){
                return BadRequest();
            }

            var result = manager.UpdateTestSite(id, value);
            if (result == null){
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<TestSitesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Testsite> Delete(int id){
            var result = manager.DeleteTestsite(id);
            if (result == null){
                return NotFound();
            }

            return Ok(result);
        }
    }
}
