using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IMotorRepository : IRepository<Motor>
    {
        void UpdateType(int id, string motortype);
    }
}
