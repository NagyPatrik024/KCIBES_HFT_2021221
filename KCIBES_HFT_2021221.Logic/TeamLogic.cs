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
        IMotorRepository motorRepo;

        public TeamLogic(ITeamRepository teamRepo, IDriverRepository driverRepo, IMotorRepository motorRepo)
        {
            this.teamRepo = teamRepo;
            this.driverRepo = driverRepo;
            this.motorRepo = motorRepo;
        }

        public void CreateOne(int id, string name, int motorid, string team_chief)
        {
            var q = from x in motorRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (String.IsNullOrEmpty(id.ToString()) || name == null || String.IsNullOrEmpty(motorid.ToString()) || team_chief == null)
            {
                throw new ArgumentNullException("Value is missing");
            }
            else
            {
                if (q.Count() > 0)
                {
                    throw new ArgumentException("Exists!");
                }
                else
                {
                    teamRepo.CreateOne(id, name, motorid, team_chief);
                }
            }

        }

        public void DeleteOne(int id)
        {
            try
            {
                GetOne(id);
                teamRepo.DeleteOne(id);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Team> GetAll()
        {
            return teamRepo.GetAll();
        }

        public Team GetOne(int id)
        {
            var q = from x in teamRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (q.Count() > 0)
            {
                return teamRepo.GetOne(id);
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
        {
            return from x in teamRepo.GetAll()
                   join z in driverRepo.GetAll() on x.Id equals z.TeamId
                   let joinedItem = new { x.Name, z.Age }
                   group joinedItem by joinedItem.Name into grp
                   select new KeyValuePair<string, double>(grp.Key, grp.Average(x => x.Age));
        }

        public IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM()
        {
            return from x in teamRepo.GetAll()
                   join z in driverRepo.GetAll() on x.Id equals z.TeamId
                   let joinedItem = new { x.Name, z.Wins }
                   group joinedItem by joinedItem.Name into grp
                   select new KeyValuePair<string, double>(grp.Key, grp.Sum(x => x.Wins));
        }

        public IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motorname)
        {
            return from x in teamRepo.GetAll()
                   join z in motorRepo.GetAll() on x.MotorId equals z.Id
                   let joinedItem = new { x.Name, z.Type }
                   select new KeyValuePair<string, string>(joinedItem.Name, joinedItem.Type);
        }


        public void UpdateTeam(int id, string name, int motorid, string team_chief)
        {
            DeleteOne(id);
            UpdateTeam(id, name, motorid, team_chief);
        }


    }
}
