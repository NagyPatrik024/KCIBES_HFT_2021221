using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public interface IMotorLogic
    {
        Motor GetOne(int id);
        IEnumerable<Motor> GetAll();
        void DeleteOne(int id);

        void CreateOne(Motor motor);
        void UpdateMotor(int id, Motor motor);

        
    }
}
