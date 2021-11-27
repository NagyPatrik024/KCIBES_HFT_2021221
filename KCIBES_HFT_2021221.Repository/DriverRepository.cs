using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class DriverRepository : IDriverRepository
    {
        F1DbContext db;
        public DriverRepository(F1DbContext db)
        {
            this.db = db;
        }

        public void UpdateDriver(int id, string name, int age, int wins, int teamid, int motorid)
        {
            var update = GetOne(id);
            update.Name = name;
            update.Age = age;
            update.Wins = wins;
            update.TeamId = teamid;
            update.MotorId = motorid;
            db.SaveChanges();
        }

        public void CreateOne(int id, string name, int age, int wins, int teamid, int motorid)
        {
            Driver driver = new Driver() { Id = id, Name = name, Age = age, Wins = wins, TeamId = teamid, MotorId = motorid };
            db.Drivers.Add(driver);
            db.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Driver driver = db.Drivers.FirstOrDefault<Driver>(x => x.Id == id);
            db.Drivers.Remove(driver);
            db.SaveChanges();
        }

        public Driver GetOne(int id)
        {
            Driver driver = db.Drivers.FirstOrDefault<Driver>(x => x.Id == id);

            return driver;

        }

        public IQueryable<Driver> GetAll()
        {
            return db.Drivers;
        }




    }
}
