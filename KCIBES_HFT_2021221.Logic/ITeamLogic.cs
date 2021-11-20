using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        Team GetOne(int id);
        IEnumerable<Team> GetAll();
        void DeleteOne(int id);

        void CreateOne(int id, string name, int motorid, string team_chief);
        void UpdateTeam(int id, string name, int motorid, string team_chief);

        IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motorname);

        IEnumerable<KeyValuePair<string,double>> GetTeamsAVGAge();

        IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM();
    }
}
