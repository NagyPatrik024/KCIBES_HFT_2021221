using KCIBES_HFT_2021221.Logic;
using KCIBES_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class MotorController : ControllerBase
    {

        IMotorLogic ml;

        public MotorController(IMotorLogic ml)
        {
            this.ml = ml;
        }

        // GET: /brand
        [HttpGet]
        public IEnumerable<Motor> Get()
        {
            return ml.GetAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Motor Get(int id)
        {
            return ml.GetOne(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Motor motor)
        {
            ml.CreateOne(motor.Id, motor.Type);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Motor motor)
        {
            ml.UpdateMotor(motor.Id, motor.Type);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.DeleteOne(id);
        }
    }
}
