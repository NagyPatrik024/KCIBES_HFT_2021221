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
    public class TeamController : ControllerBase
    {
        ITeamLogic tl;
        IHubContext<SignalRHub> hub;

        public TeamController(ITeamLogic tl, IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
        }

        // GET: /team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return tl.GetAll();
        }

        // GET /team/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return tl.GetOne(id);
        }

        // POST /team
        [HttpPost]
        public void Post([FromBody] Team team)
        {
            tl.CreateOne(team.Id, team.Name, team.MotorId, team.Team_Chief);
            hub.Clients.All.SendAsync("TeamCreated", team);
        }

        // PUT /team
        [HttpPut]
        public void Put([FromBody] Team team)
        {
            tl.UpdateTeam(team.Id, team.Name, team.MotorId, team.Team_Chief);
            hub.Clients.All.SendAsync("TeamUpdated", team);
        }

        // DELETE /team/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teamtodelete = tl.GetOne(id);
            tl.DeleteOne(id);
            hub.Clients.All.SendAsync("TeamDeleted", teamtodelete);
        }

    }
}
