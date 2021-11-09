using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IDriverRepository : IRepository<Driver>
    {
        void UpdateTeam(int id, Team team);
    }
}
