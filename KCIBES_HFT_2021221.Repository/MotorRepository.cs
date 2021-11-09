using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class MotorRepository : Repository<Motor>, IMotorRepository
    {
        public MotorRepository(F1DbContext ctx) : base(ctx)
        {

        }
        public void UpdateType(int id, string motortype)
        {
            Motor motor = _ctx.Motors.FirstOrDefault(x => x.Id == id);
            if (motor != null)
            {
                motor.Type = motortype;
                _ctx.SaveChanges();
            }
            else 
            {
                throw new Exception();
            }
        }

        public override void CreateOne(Motor motor)
        {
            _ctx.Motors.Add(motor);
            _ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            Motor motor = _ctx.Motors.FirstOrDefault(x => x.Id == id);
            if (motor != null)
            {
                _ctx.Motors.Remove(motor);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public override Motor GetOne(int id)
        {
            Motor motor = _ctx.Motors.FirstOrDefault(x => x.Id == id);
            if (motor != null)
            {
                return motor;
            }
            else
            {
                throw new Exception();
            }
        }

      
    }
}
