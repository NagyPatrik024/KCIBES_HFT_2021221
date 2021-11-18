using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    interface IMotorLogic
    {
        Motor GetOne(int id);
        IQueryable<Motor> GetAll();
        void DeleteOne(int id);

        void CreateOne(Motor motor);
        void UpdateType(int id, string motortype);
    }
}
