using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IMotorRepository
    {
        Motor GetOne(int id);
        IQueryable<Motor> GetAll();

        void DeleteOne(int id);

        void CreateOne(Motor motor);
        void UpdateMotor(int id, Motor motor);
    }
}
