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
    public class DriverController : ControllerBase
    {
        IDriverLogic dl;

        public DriverController(IDriverLogic dl)
        {
            this.dl = dl;
        }

        // GET: /brand
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return dl.GetAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return dl.GetOne(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Driver driver)
        {
            dl.CreateOne(driver.Id, driver.Name, driver.Age, driver.Wins, driver.TeamId, driver.MotorId);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Driver driver)
        {
            dl.UpdateDriver(driver.Id, driver.Name, driver.Age, driver.Wins, driver.TeamId, driver.MotorId);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.DeleteOne(id);
        }

    }
}
