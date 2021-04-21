using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Creditcards;
using API.Models.Creditcards.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class creditcardsController : ControllerBase
    {
        // GET: api/creditcards
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Creditcard> Get()
        {
            IReadAllCCData readObject = new ReadCCData();
            return readObject.ReadAllCC();
        }

        // GET: api/creditcards/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Creditcard Get(int id)
        {
            IReadCC readObject = new ReadCCData();
            return readObject.ReadCC(id);
        }

        // POST: api/creditcards
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Creditcard value)
        {
            ICreateCC insertObject = new CreateCC();
            insertObject.CreateCC(value);
        }


        // PUT: api/creditcards/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Creditcard value)
        {
            IModifyCC modifyObject = new ModifyCC();
            modifyObject.SaveCC(value, id);
        }

        // DELETE: api/creditcards/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteCC deleteObject = new DeleteCC();
            deleteObject.DeleteCC(id);
        }
    }
}
