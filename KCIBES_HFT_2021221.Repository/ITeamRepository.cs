using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void UpdateTeamChief(int id, string chiefname);
    }
}
