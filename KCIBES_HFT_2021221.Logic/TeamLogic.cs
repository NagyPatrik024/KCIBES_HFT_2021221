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

        public void CreateOne(Team team)
        {
            var q = from x in motorRepo.GetAll()
                    where x.Id == team.Id
                    select x.Id;
            if (q.Count() > 0)
            {
                throw new ArgumentException("Exists!");
            }
            else
            {
                if (String.IsNullOrEmpty(team.Id.ToString()) || team.Name == null || String.IsNullOrEmpty(team.MotorId.ToString()) || team.Team_Chief == null)
                {
                    throw new Exception("Value is missing");
                }
                else
                {
                    teamRepo.CreateOne(team);
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
            var q1 = from x in motorRepo.GetAll()
                     where x.Type == motorname
                     select x.Id;
            var q2 = from x in teamRepo.GetAll()
                     where q1.Contains(x.MotorId)
                     select new KeyValuePair<string, string>(x.Name, x.Motor.Type);
            return q2;


        }


        public void UpdateTeam(int id, Team team)
        {
            teamRepo.UpdateTeam(id, team);
        }
    }
}
