using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface ITeamRepository
    {
        Team GetOne(int id);
        IQueryable<Team> GetAll();

        void DeleteOne(int id);
        //Id = 1, Name = "Ferrari", MotorId = 1, Team_Chief = "Mattia Binotto" 
        void CreateOne(int id, string name, int motorid, string team_chief);
        void UpdateTeam(int id, string name, int motorid, string team_chief);
    }
}
