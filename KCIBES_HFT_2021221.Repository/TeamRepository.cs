using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {

        public TeamRepository(F1DbContext ctx) : base(ctx)
        {

        }
        public void UpdateTeamChief(int id, string chiefname)
        {
            Team team = _ctx.Teams.FirstOrDefault<Team>(x => x.TeamId == id);
            if (team != null)
            {
                team.Team_Chief = chiefname;
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

        public override void CreateOne(Team team)
        {
            _ctx.Teams.Add(team);
            _ctx.SaveChanges();
        }

        public override void DeleteOne(int id)
        {
            Team team = _ctx.Teams.FirstOrDefault<Team>(x => x.TeamId == id);
            if (team != null)
            {
                _ctx.Teams.Remove(team);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception(); // TODO 
            }

        }

        public override Team GetOne(int id)
        {
            Team team = _ctx.Teams.FirstOrDefault<Team>(x => x.TeamId == id);
            if (team != null)
            {
                return team;
            }
            else
            {
                throw new Exception(); // TODO 
            }
        }

       


    }
}
