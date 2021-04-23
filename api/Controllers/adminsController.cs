using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Admins;
using API.Models.Admins.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminsController : ControllerBase
    {
        // GET: api/admins
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Admin> Get()
        {
            IReadAllAdminData readObject = new ReadAdminData();
            return readObject.ReadAllAdmin();
        }

        // GET: api/admins/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetAdmin")]
        public Admin Get(int id)
        {
            IReadAdmin readObject = new ReadAdminData();
            return readObject.ReadAdmin(id);
        }

        // POST: api/admins
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Admin value)
        {
            ICreateAdmin insertObject = new CreateAdmin();
            insertObject.CreateAdmin(value);
        }


        // PUT: api/admins/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}", Name = "PutAdmin")]
        public void Put(int id, [FromBody] Admin value)
        {
            IModifyAdmin modifyObject = new ModifyAdmin();
            modifyObject.SaveAdmin(value, id);
        }

        // DELETE: api/admins/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}", Name = "DeleteAdmin")]
        public void Delete(int id)
        {
            IDeleteAdmin deleteObject = new DeleteAdmin();
            deleteObject.DeleteAdmin(id);
        }
    }
}
