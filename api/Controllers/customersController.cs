using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Customers;
using API.Models.Customers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        // GET: api/customers
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Customer> Get()
        {
            IReadAllCustData readObject = new ReadCustData();
            return readObject.ReadAllCust();
        }

        // GET: api/customers/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            IReadCust readObject = new ReadCustData();
            return readObject.ReadCust(id);
        }

        // POST: api/customers
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            ICreateCust insertObject = new CreateCust();
            insertObject.CreateCust(value);
        }


        // PUT: api/customers/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
            IModifyCust modifyObject = new ModifyCust();
            modifyObject.SaveCust(value, id);
        }

        // DELETE: api/customers/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteCust deleteObject = new DeleteCust();
            deleteObject.DeleteCust(id);
        }
    }
}
