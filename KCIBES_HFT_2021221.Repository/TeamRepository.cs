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

        public void UpdateTeam(int id, string name, int motorid, string team_chief)
        {
            DeleteOne(id);
            CreateOne(id, name, motorid, team_chief);
            db.SaveChanges();
        }

        public void CreateOne(int id, string name, int motorid, string team_chief)
        {
            Team team = new Team() { Id = id, Name = name, MotorId = motorid, Team_Chief = team_chief };
            db.Teams.Add(team);
            db.SaveChanges();
        }
        public void DeleteOne(int id)
        {
            Team team = db.Teams.FirstOrDefault<Team>(x => x.Id == id);
            db.Teams.Remove(team);
            db.SaveChanges();
        }

        public Team GetOne(int id)
        {
            Team team = db.Teams.FirstOrDefault<Team>(x => x.Id == id);

            return team;

        }

        public IQueryable<Team> GetAll()
        {
            return db.Teams;
        }




    }
}
