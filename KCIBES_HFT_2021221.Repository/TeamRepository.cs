using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class TeamRepository : ITeamRepository
    {

        F1DbContext db;
        public TeamRepository(F1DbContext db) 
        {
            this.db = db;
        }
        public void UpdateTeamChief(int id, string chiefname)
        {
            Team team = db.Teams.FirstOrDefault<Team>(x => x.Id == id);
            if (team != null)
            {
                team.Team_Chief = chiefname;
                db.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

        public void CreateOne(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        public void DeleteOne(int id)
        {
            Team team = db.Teams.FirstOrDefault<Team>(x => x.Id == id);
            if (team != null)
            {
                db.Teams.Remove(team);
                db.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }

        }

        public Team GetOne(int id)
        {
            Team team = db.Teams.FirstOrDefault<Team>(x => x.Id == id);
            if (team != null)
            {
                return team;
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

        public IQueryable<Team> GetAll()
        {
            return db.Teams;
        }
    }
}
