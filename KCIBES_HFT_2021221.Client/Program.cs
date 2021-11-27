
using KCIBES_HFT_2021221.Client;
using KCIBES_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace KCIBES_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:17873");

            #region CRUD - Driver
            rest.Post<Driver>(new Driver() { Name = "TEST DRIVER", Age = 99, Wins = 99, TeamId = 1, MotorId = 1 }, "driver");
            rest.Put<Driver>(new Driver() { Id = 22, Name = "UPDATED DRIVER", Age = 99, Wins = 99, TeamId = 1, MotorId = 1 }, "driver");
            var driver = rest.GetSingle<Driver>("driver/8");
            rest.Delete(21, "driver");
            var drivers = rest.Get<Driver>("driver");
            #endregion

            #region CRUD - Team
            rest.Post<Team>(new Team() { Name = "TEST TEAM", MotorId = 1, Team_Chief = "TEST CHIEF" }, "team");
            rest.Put<Team>(new Team() { Id = 12, Name = "UPDATED TEAM", MotorId = 1, Team_Chief = "UPDATED CHIEF" }, "team");
            var team = rest.GetSingle<Team>("team/2");
            rest.Delete(11, "team");
            var teams = rest.Get<Team>("team");
            #endregion

            #region CRUD - Motor
            rest.Post<Motor>(new Motor() { Type = "TEST MOTOR" }, "motor");
            rest.Put<Motor>(new Motor() { Id = 6, Type = "UPDATED MOTOR" }, "motor");
            var motor = rest.GetSingle<Motor>("motor/2");
            rest.Delete(5, "motor");
            var motors = rest.Get<Motor>("motor");
            #endregion



            #region NONCRUD
            //public IEnumerable<string> GetDriversOfaTeam(string teamname)
            //public IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers()
            //public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
            //public IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM()
            //public IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motortype)
            var teamsavgage = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsAVGAge");
            var teamswinssum = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsWinsSUM");
            var teamchiefbydriver = rest.Get<KeyValuePair<string, string>>("stat/GetTeamChiefByDrivers");
            var driversofateam = rest.Get<string>("stat/GetDriversOfaTeam?teamname=Mclaren");
            var teamsbymotor = rest.Get<KeyValuePair<string, string>>("stat/GetTeamsByMotor?motortype=Mercedes M11 EQ");
            #endregion
        }
    }
}
