using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {

        public DriverRepository(F1DbContext ctx) : base(ctx)
        {

        }
        public void ChangeTeam(int id, Team team)
        {
            Driver driver = _ctx.Drivers.FirstOrDefault<Driver>(x => x.DriverId == id);
            if (driver != null)
            {
                driver.Team = team;
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

        public override void CreateOne(Driver driver)
        {
            _ctx.Drivers.Add(driver);
            _ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            Driver driver = _ctx.Drivers.FirstOrDefault<Driver>(x => x.DriverId == id);
            if (driver != null)
            {
                _ctx.Drivers.Remove(driver);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }

        }

        public override Driver GetOne(int id)
        {
            Driver driver = _ctx.Drivers.FirstOrDefault<Driver>(x => x.DriverId == id);
            if (driver != null)
            {
                return driver;
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

        public override void UpdateOne(int id, Driver item)
        {
            Driver driver = _ctx.Drivers.FirstOrDefault<Driver>(x => x.DriverId == id);
            if (driver != null)
            {
                _ctx.Drivers.Remove(driver);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }
    }
}
