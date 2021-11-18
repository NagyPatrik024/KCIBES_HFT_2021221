using KCIBES_HFT_2021221.Models;
using KCIBES_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public class TeamLogic : ITeamLogic
    {
        ITeamRepository teamRepo;
        IDriverRepository driverRepo;

        public TeamLogic(ITeamRepository teamRepo, IDriverRepository driverRepo)
        {
            this.teamRepo = teamRepo;
            this.driverRepo = driverRepo;
        }

        public void CreateOne(Team team)
        {
            teamRepo.CreateOne(team);
        }

        public void DeleteOne(int id)
        {
            teamRepo.DeleteOne(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return teamRepo.GetAll();
        }

        public Team GetOne(int id)
        {
            return teamRepo.GetOne(id);
        }

        public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
        {
            return from x in teamRepo.GetAll()
                   join z in driverRepo.GetAll() on x.Id equals z.TeamId
                   let joinedItem = new { x.Name, z.Age }
                   group joinedItem by joinedItem.Name into grp
                   select new KeyValuePair<string, double>(grp.Key, grp.Average(x => x.Age));
        }

        public IEnumerable<Team> GetTeamsWhereWinsGreaterThan(int wins)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetTeamsWithMercedesMotor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> TeamsWins()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(int id, Team team)
        {
            teamRepo.UpdateTeam(id, team);
        }
    }
}
