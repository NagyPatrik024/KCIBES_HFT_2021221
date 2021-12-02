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

        // GET: /motor
        [HttpGet]
        public IEnumerable<Motor> Get()
        {
            return ml.GetAll();
        }

        // GET /motor/5
        [HttpGet("{id}")]
        public Motor Get(int id)
        {
            return ml.GetOne(id);
        }

        // POST /motor
        [HttpPost]
        public void Post([FromBody] Motor motor)
        {
            ml.CreateOne(motor.Id, motor.Type);
        }

        // PUT /motor
        [HttpPut]
        public void Put([FromBody] Motor motor)
        {
            ml.UpdateMotor(motor.Id, motor.Type);
        }

        // DELETE /motor/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.DeleteOne(id);
        }
    }
}
