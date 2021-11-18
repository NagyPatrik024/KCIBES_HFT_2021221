using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface ITeamRepository
    {
        Team GetOne(int id);
        IQueryable<Team> GetAll();

        void DeleteOne(int id);

        void CreateOne(Team Team);
        void UpdateTeam(int id, Team team);
    }
}
