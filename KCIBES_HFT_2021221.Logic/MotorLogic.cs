using KCIBES_HFT_2021221.Models;
using KCIBES_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public class MotorLogic : IMotorLogic
    {
        IMotorRepository motorRepo;
        public MotorLogic(IMotorRepository motorRepo)
        {
            this.motorRepo = motorRepo;
        }

        public void CreateOne(Motor motor)
        {
            var q = from x in motorRepo.GetAll()
                    where x.Id == motor.Id
                    select x.Id;
            if (q.Count() > 0)
            {
                throw new ArgumentException("Exists!");
            }
            else
            {
                if (motor.Type == null || String.IsNullOrEmpty(motor.Id.ToString()))
                {
                    throw new Exception("Value is missing");
                }
                else
                {
                    motorRepo.CreateOne(motor);
                }

            }

        }

        public void DeleteOne(int id)
        {

            try
            {
                GetOne(id);
                motorRepo.DeleteOne(id);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }

        }

        public IEnumerable<Motor> GetAll()
        {
            return motorRepo.GetAll();
        }

        public Motor GetOne(int id)
        {
            var q = from x in motorRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (q.Count() > 0)
            {
                return motorRepo.GetOne(id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateMotor(int id, Motor motor)
        {
            motorRepo.UpdateMotor(id, motor);
        }
    }
}
