using KCIBES_HFT_2021221.Models;
using KCIBES_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public class DriverLogic : IDriverLogic
    {
        IDriverRepository driverRepo;
        ITeamRepository teamRepo;

        public DriverLogic(IDriverRepository driverRepo, ITeamRepository teamRepo)
        {
            this.driverRepo = driverRepo;
            this.teamRepo = teamRepo;
        }
        public void CreateOne(int id, string name, int age, int wins, int teamid, int motorid)
        {
            var q = from x in driverRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (String.IsNullOrEmpty(id.ToString()) || name == null || String.IsNullOrEmpty(age.ToString()) || String.IsNullOrEmpty(wins.ToString()) || String.IsNullOrEmpty(teamid.ToString()) || String.IsNullOrEmpty(motorid.ToString()))
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
                    driverRepo.CreateOne(id, name, age, wins, teamid, motorid);
                }
            }
        }

        public void DeleteOne(int id)
        {
            try
            {
                GetOne(id);
                driverRepo.DeleteOne(id);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Driver> GetAll()
        {
            return driverRepo.GetAll();
        }

        public IEnumerable<string> GetDriversOfaTeam(string teamname)
        {
            return from x in driverRepo.GetAll()
                   where x.Team.Name == teamname
                   select x.Name;
        }

        public Driver GetOne(int id)
        {
            var q = from x in driverRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (q.Count() > 0)
            {
                return driverRepo.GetOne(id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers()
        {

            return from x in driverRepo.GetAll()
                   select new KeyValuePair<string, string>(x.Name, x.Team.Team_Chief);

            //return from x in driverRepo.GetAll()
            //       join z in teamRepo.GetAll() on x.TeamId equals z.Id
            //       let joinedItem = new { x.Name, z.Team_Chief }
            //       select new KeyValuePair<string, string>(joinedItem.Name, joinedItem.Team_Chief);
        }

        public void UpdateDriver(int id, string name, int age, int wins, int teamid, int motorid)
        {
            DeleteOne(id);
            UpdateDriver(id, name, age, wins, teamid, motorid);
        }
    }
}
