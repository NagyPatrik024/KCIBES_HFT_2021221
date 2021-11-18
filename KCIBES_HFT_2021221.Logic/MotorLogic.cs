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
            motorRepo.CreateOne(motor);
        }

        public void DeleteOne(int id)
        {
            motorRepo.DeleteOne(id);
        }

        public IEnumerable<Motor> GetAll()
        {
            return motorRepo.GetAll();
        }

        public Motor GetOne(int id)
        {
            return motorRepo.GetOne(id);
        }

        public void UpdateMotor(int id, Motor motor)
        {
            motorRepo.UpdateMotor(id, motor);
        }
    }
}
