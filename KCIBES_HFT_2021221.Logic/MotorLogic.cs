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

        public void CreateOne(int id, string type)
        {
            var q = from x in motorRepo.GetAll()
                    where x.Id == id
                    select x.Id;
            if (type == null || String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("Value is missing");
            }
            else
            {
                if (q.Count() > 0)
                {
                    throw new ArgumentException("Exists");
                }
                else
                {
                    motorRepo.CreateOne(id, type);
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

        public void UpdateMotor(int id, string type)
        {
            if (type == null || String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("Value is missing");
            }
            else
            {

                try
                {
                    GetOne(id);
                    motorRepo.UpdateMotor(id, type);
                }
                catch (Exception)
                {
                    throw new KeyNotFoundException();
                }

            }
        }
    }
}
