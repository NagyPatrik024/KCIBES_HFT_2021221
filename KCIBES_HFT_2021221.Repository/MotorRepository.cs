using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class MotorRepository : IMotorRepository
    {
        F1DbContext db;
        public MotorRepository(F1DbContext db)
        {
            this.db = db;
        }
        public void UpdateMotor(int id, string type)
        {
            var update = GetOne(id);
            update.Type = type;
            db.SaveChanges();
        }


        public void CreateOne(int id, string type)
        {
            Motor motor = new Motor() { Id = id, Type = type };
            db.Motors.Add(motor);
            db.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Motor motor = db.Motors.FirstOrDefault(x => x.Id == id);

            db.Motors.Remove(motor);
            db.SaveChanges();

        }

        public Motor GetOne(int id)
        {
            Motor motor = db.Motors.FirstOrDefault(x => x.Id == id);
            return motor;

        }

        public IQueryable<Motor> GetAll()
        {
            return db.Motors;
        }


    }
}
