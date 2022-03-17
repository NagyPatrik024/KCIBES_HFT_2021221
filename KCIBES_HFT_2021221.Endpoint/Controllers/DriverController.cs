using KCIBES_HFT_2021221.Endpoint.Services;
using KCIBES_HFT_2021221.Logic;
using KCIBES_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public DriverController(IDriverLogic dl, IHubContext<SignalRHub> hub)
        {
            this.dl = dl;
            this.hub = hub;
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
            dl.CreateOne(driver.Id, driver.Name, driver.Age, driver.Wins, (int)driver.TeamId, (int)driver.MotorId);
            hub.Clients.All.SendAsync("DriverCreated", driver);
        }

        // PUT /driver
        [HttpPut]
        public void Put([FromBody] Driver driver)
        {
            dl.UpdateDriver(driver.Id, driver.Name, driver.Age, driver.Wins, (int)driver.TeamId, (int)driver.MotorId);
            hub.Clients.All.SendAsync("DriverUpdated", driver);
        }

        // DELETE /driver/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var drivertodelete = dl.GetOne(id);
            dl.DeleteOne(id);
            hub.Clients.All.SendAsync("DriverDeleted", drivertodelete);
        }

    }
}
