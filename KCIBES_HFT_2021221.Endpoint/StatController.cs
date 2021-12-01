using KCIBES_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IDriverLogic dl;
        ITeamLogic tl;

        public StatController(IDriverLogic dl, ITeamLogic tl)
        {
            this.dl = dl;
            this.tl = tl;
        }

        //public IEnumerable<string> GetDriversOfaTeam(string teamname)
        //    public IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers()
        //    public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
        //    public IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM()
        //  public IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motortype)

        // GET: stat/GetDriversOfaTeam/teamname
        [HttpGet]
        [HttpGet("{teamname}")]
        public IEnumerable<string> GetDriversOfaTeam(string teamname)
        {
            return dl.GetDriversOfaTeam(teamname);
        }

        // GET: stat/GetTeamChiefByDrivers
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers()
        {
            return dl.GetTeamChiefByDrivers();
        }

        // GET: stat/GetTeamsAVGAge
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
        {
            return tl.GetTeamsAVGAge();
        }

        // GET: stat/GetTeamsWinsSUM
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM()
        {
            return tl.GetTeamsWinsSUM();
        }

        // GET: stat/GetTeamsByMotor/motortype
        [HttpGet]
        [HttpGet("{motortype}")]
        public IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motortype)
        {
            return tl.GetTeamsByMotor(motortype);
        }





    }
}
