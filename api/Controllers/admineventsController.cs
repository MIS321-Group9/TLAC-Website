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
        [HttpGet("{id}")]
        public AdminEvent Get(int id)
        {
            IReadAdminEvent readObject = new ReadAdminEventData();
            return readObject.ReadAdminEvent(id);
        }

        // POST: api/adminevents
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] AdminEvent value)
        {
            ICreateAdminEvent insertObject = new CreateAdminEvent();
            insertObject.CreateAdminEvent(value);
        }

        // PUT: api/adminevents/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AdminEvent value)
        {
            IModifyAdminEvent modifyObject = new ModifyAdminEvent();
            modifyObject.SaveAdminEvent(value, id);
        }

        // DELETE: api/adminevents/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteAdminEvent deleteObject = new DeleteAdminEvent();
            deleteObject.DeleteAdminEvent(id);
        }
    }
}
