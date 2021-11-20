using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IMotorRepository
    {
        Motor GetOne(int id);
        IQueryable<Motor> GetAll();

        void DeleteOne(int id);

        void CreateOne(int id, string Type);
        void UpdateMotor(int id, string type);
    }
}
