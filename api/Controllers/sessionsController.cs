using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Sessions;
using API.Models.Sessions.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sessionsController : ControllerBase
    {
        // GET: api/sessions
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Session> Get()
        {
            IReadAllSessionData readObject = new ReadSessionData();
            return readObject.ReadAllSession();
        }

        // GET: api/sessions/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetSession")]
        public Session Get(int id)
        {
            IReadSession readObject = new ReadSessionData();
            return readObject.ReadSession(id);
        }

        // POST: api/sessions
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Session value)
        {
            ICreateSession insertObject = new CreateSession();
            insertObject.CreateSession(value);
        }

        // PUT: api/sessions/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}", Name = "PutSession")]
        public void Put(int id, [FromBody] Session value)
        {
            IModifySession modifyObject = new ModifySession();
            modifyObject.SaveSession(value, id);
        }

        // DELETE: api/sessions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}", Name = "DeleteSession")]
        public void Delete(int id)
        {
            IDeleteSession deleteObject = new DeleteSession();
            deleteObject.DeleteSession(id);
        }

        // BOOK SESSION: api/session/5
        [EnableCors("Book")]
        [HttpPut("{id}", Name = "BookSession")]
        public void Book(int custId, int id)
        {
            IBookSession modifyObject = new BookSession();
            modifyObject.BookSession(custId, id);
        }

        // CANCEL SESSION: api/session/5
        [EnableCors("Cancel")]
        [Route("sessions/{id}/cancel")]
        //[HttpPut("{id}")]
        //[NonAction]
        protected void Cancel(int id)
        {
            ICancelSession modifyObject = new CancelSession();
            modifyObject.CancelSession(id);
        }
    }
}
