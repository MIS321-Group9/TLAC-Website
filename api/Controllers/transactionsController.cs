using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Transactions;
using API.Models.Transactions.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transactionsController : ControllerBase
    {
        // GET: api/transactions
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Transaction> Get()
        {
            IReadAllTransData readObject = new ReadTransData();
            return readObject.ReadAllTrans();
        }

        // GET: api/transactions/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Transaction Get(int id)
        {
            IReadTrans readObject = new ReadTransData();
            return readObject.ReadTrans(id);
        }

        // POST: api/transactions
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Transaction value)
        {
            ICreateTrans insertObject = new CreateTrans();
            insertObject.CreateTrans(value);
        }

        // PUT: api/transactions/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Transaction value)
        {
            IModifyTrans modifyObject = new ModifyTrans();
            modifyObject.SaveTrans(value, id);
        }

        // DELETE: api/transactions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteTrans deleteObject = new DeleteTrans();
            deleteObject.DeleteTrans(id);
        }
    }
}
