using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Admins;
using api.Models.Admins.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/admins
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Admin> Get()
        {
            IReadAllAdminData readObject = new ReadAdminData();
            return readObject.ReadAllAdmin();
        }

        // GET: api/admins/1
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
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

        // PUT: api/admins/1
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}", Name = "Put")]
        public void Put(int id, [FromBody] Admin value)
        {
            IModifyAdmin modifyObject = new ModifyAdmin();
            modifyObject.SaveAdmin(value, id);
        }

        // DELETE: api/admins/1
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}", Name = "Delete")]
        public void Delete(int id)
        {
            IDeleteAdmin deleteObject = new DeleteAdmin();
            deleteObject.DeleteAdmin(id);
        }
    }
}