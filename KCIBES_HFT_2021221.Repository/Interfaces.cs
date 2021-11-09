using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();

        void UpdateOne(int id, T item);

        void DeleteOne(int id);

        void CreateOne(T item);
    }

    public interface IDriverRepository : IRepository<Driver>
    {
        void ChangeTeam(int id, Team team);
    }
    public interface IMotorRepository : IRepository<Motor>
    {
        void ChangeType(int id, string motortype);
    }
    public interface ITeamRepository : IRepository<Team>
    {
        void ChangeTeamChief(int id, string chiefname);
    }
}
