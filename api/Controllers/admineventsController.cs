using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models.AdminEvents;
using API.Models.Admins;
using API.Models.Admins.Interfaces;
using API.Models.AdminEvents.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class admineventsController : ControllerBase
    {
        // GET: api/adminevents
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<AdminEvent> Get()
        {
            IReadAllAdminEventData readObject = new ReadAdminEventData();
            return readObject.ReadAllAdminEvent();
        }

        // GET: api/adminevents/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/adminevents
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/adminevents/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/adminevents/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
