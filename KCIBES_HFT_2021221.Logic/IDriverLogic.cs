using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Logic
{
    public interface IDriverLogic
    {
        Driver GetOne(int id);
        IEnumerable<Driver> GetAll();
        void DeleteOne(int id);
        void CreateOne(int id, string name, int age, int wins, int teamid, int motorid);
        void UpdateDriver(int id, string name, int age, int wins, int teamid, int motorid);
        IEnumerable<string> GetDriversOfaTeam(string teamname);

        IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers(); 



    }
}
