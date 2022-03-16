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

        // GET: /driver
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return dl.GetAll();
        }

        // GET /driver/5
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return dl.GetOne(id);
        }

        // POST /driver
        [HttpPost]
        public void Post([FromBody] Driver driver)
        {
            dl.CreateOne(driver.Id, driver.Name, driver.Age, driver.Wins, driver.TeamId, driver.MotorId);
        }

        // PUT /driver
        [HttpPut]
        public void Put([FromBody] Driver driver)
        {
            dl.UpdateDriver(driver.Id, driver.Name, driver.Age, driver.Wins, driver.TeamId, driver.MotorId);
        }

        // DELETE /driver/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.DeleteOne(id);
        }

    }
}
