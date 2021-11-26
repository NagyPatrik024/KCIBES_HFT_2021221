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

        // GET: /brand
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return tl.GetAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return tl.GetOne(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Team team)
        {
            tl.CreateOne(team.Id, team.Name, team.MotorId, team.Team_Chief);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Team team)
        {
            tl.UpdateTeam(team.Id, team.Name, team.MotorId, team.Team_Chief);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.DeleteOne(id);
        }

    }
}
