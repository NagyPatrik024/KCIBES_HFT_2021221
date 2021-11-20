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
        public void CreateOne(Driver driver)
        {
            var q = from x in driverRepo.GetAll()
                    where x.Id == driver.Id
                    select x.Id;
            if (q.Count() > 0)
            {
                throw new ArgumentException("Exists!");
            }
            else
            {
                if (String.IsNullOrEmpty(driver.Id.ToString()) || driver.Name == null || String.IsNullOrEmpty(driver.Age.ToString()) || String.IsNullOrEmpty(driver.Wins.ToString()) || String.IsNullOrEmpty(driver.TeamId.ToString()) || String.IsNullOrEmpty(driver.MotorId.ToString()))
                {
                    throw new Exception("Value is missing");
                }
                else
                {
                    driverRepo.CreateOne(driver);
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
            var q1 = from x in teamRepo.GetAll()
                     where x.Name == teamname
                     select x.Id;

            var q2 = from x in driverRepo.GetAll()
                     where q1.Contains(x.TeamId)
                     select x.Name;

            return q2.ToList();
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
                   join z in teamRepo.GetAll() on x.TeamId equals z.Id
                   let joinedItem = new { x.Name, z.Team_Chief }
                   select new KeyValuePair<string, string>(joinedItem.Name, joinedItem.Team_Chief);
        }

        public void UpdateDriver(int id, Driver driver)
        {
            driverRepo.UpdateDriver(id, driver);
        }
    }
}
