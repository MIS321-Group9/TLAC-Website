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
    public class cancelsessionsController : ControllerBase
    {
        // PUT: api/cancelsessions/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id)
        {
            ICancelSession modifyObject = new CancelSession();
            modifyObject.CancelSession(id);
        }
    }
}
