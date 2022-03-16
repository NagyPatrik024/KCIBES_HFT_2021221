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
    public class TeamController : ControllerBase
    {
        ITeamLogic tl;

        public TeamController(ITeamLogic tl)
        {
            this.tl = tl;
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
        }

        // PUT /team
        [HttpPut]
        public void Put([FromBody] Team team)
        {
            tl.UpdateTeam(team.Id, team.Name, team.MotorId, team.Team_Chief);
        }

        // DELETE /team/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.DeleteOne(id);
        }

    }
}
