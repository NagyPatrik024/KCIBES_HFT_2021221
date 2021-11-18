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
            driverRepo.CreateOne(driver);
        }

        public void DeleteOne(int id)
        {
            driverRepo.DeleteOne(id);
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
            return driverRepo.GetOne(id);
        }

        public void UpdateDriver(int id, Driver driver)
        {
            driverRepo.UpdateDriver(id, driver);
        }
    }
}
