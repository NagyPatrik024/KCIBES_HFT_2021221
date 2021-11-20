using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IDriverRepository 
    {
        Driver GetOne(int id);
        IQueryable<Driver> GetAll();

        void DeleteOne(int id);
        //Id = 1, Name = "Max Verstappen", Age = 24, Wins = 17, TeamId = 3, MotorId = 3 
        void CreateOne(int id, string name, int age, int wins, int teamid, int motorid);
        void UpdateDriver(int id, string name, int age, int wins, int teamid, int motorid); 
        

    }
}
