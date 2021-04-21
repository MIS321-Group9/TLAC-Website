using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Trainers;
using API.Models.Trainers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class trainersController : ControllerBase
    {
        // GET: api/trainers
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Trainer> Get()
        {
            IReadAllTrainerData readObject = new ReadTrainerData();
            return readObject.ReadAllTrainer();
        }

        // GET: api/trainers/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Trainer Get(int id)
        {
            IReadTrainer readObject = new ReadTrainerData();
            return readObject.ReadTrainer(id);
        }

        // POST: api/trainers
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Trainer value)
        {
            ICreateTrainer insertObject = new CreateTrainer();
            insertObject.CreateTrainer(value);
        }


        // PUT: api/trainers/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trainer value)
        {
            IModifyTrainer modifyObject = new ModifyTrainer();
            modifyObject.SaveTrainer(value, id);
        }

        // DELETE: api/trainers/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteTrainer deleteObject = new DeleteTrainer();
            deleteObject.DeleteTrainer(id);
        }
    }
}
