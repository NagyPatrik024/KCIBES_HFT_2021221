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
        public void UpdateMotor(int id, Motor motor)
        {
            Motor motor_ = db.Motors.FirstOrDefault(x => x.Id == id);
            DeleteOne(id);
            CreateOne(motor);
            db.SaveChanges();
        }

        public void CreateOne(Motor motor)
        {
            db.Motors.Add(motor);
            db.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Motor motor = db.Motors.FirstOrDefault(x => x.Id == id);
            if (motor != null)
            {
                db.Motors.Remove(motor);
                db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public Motor GetOne(int id)
        {
            Motor motor = db.Motors.FirstOrDefault(x => x.Id == id);
            if (motor != null)
            {
                return motor;
            }
            else
            {
                throw new Exception();
            }
        }

        public IQueryable<Motor> GetAll()
        {
            return db.Motors;
        }
    }
}
