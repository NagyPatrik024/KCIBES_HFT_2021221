using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        Team GetOne(int id);
        IEnumerable<Team> GetAll();
        void DeleteOne(int id);

        void CreateOne(Team team);
        void UpdateTeam(int id, Team team);

        IEnumerable<Team> TeamsWins();

        IEnumerable<Team> GetTeamsWithMercedesMotor();

        IEnumerable<KeyValuePair<string,double>> GetTeamsAVGAge();

        IEnumerable<Team> GetTeamsWhereWinsGreaterThan(int wins);
    }
}
