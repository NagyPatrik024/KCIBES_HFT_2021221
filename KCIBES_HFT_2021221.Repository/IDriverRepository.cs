using KCIBES_HFT_2021221.Models;
using System.Linq;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IDriverRepository 
    {

        Driver GetOne(int id);
        IQueryable<Driver> GetAll();

        void DeleteOne(int id);

        void CreateOne(Driver driver);
        void UpdateTeam(int id, Team team);   
    }
}
