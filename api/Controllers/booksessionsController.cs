using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Customers;
using API.Models.Sessions;
using API.Models.Sessions.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksessionsController : ControllerBase
    {
        // PUT: api/booksessions/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}/{id2}")]
        public void Put(int id, int id2)
        {
            IBookSession modifyObject = new BookSession();
            modifyObject.BookSession(id2, id);
        }
    }
}
