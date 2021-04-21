using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Discounts;
using API.Models.Discounts.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class discountsController : ControllerBase
    {
        // GET: api/discounts
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Discount> Get()
        {
            IReadAllDisData readObject = new ReadDisData();
            return readObject.ReadAllDis();
        }

        // GET: api/discounts/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Discount Get(int id)
        {
            IReadDis readObject = new ReadDisData();
            return readObject.ReadDis(id);
        }

        // POST: api/discounts
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Discount value)
        {
            ICreateDis insertObject = new CreateDis();
            insertObject.CreateDis(value);
        }


        // PUT: api/discounts/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Discount value)
        {
            IModifyDis modifyObject = new ModifyDis();
            modifyObject.SaveDis(value, id);
        }

        // DELETE: api/discounts/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteDis deleteObject = new DeleteDis();
            deleteObject.DeleteDis(id);
        }
    }
}
