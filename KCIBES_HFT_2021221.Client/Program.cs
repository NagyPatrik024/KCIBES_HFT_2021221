
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


            rest.Post<Motor>(new Motor()
            {
                Type = "RedBull engine"
            }, "motor");

            var motors = rest.Get<Motor>("motor");
            //public IEnumerable<string> GetDriversOfaTeam(string teamname)
            //    public IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDrivers()
            //    public IEnumerable<KeyValuePair<string, double>> GetTeamsAVGAge()
            //    public IEnumerable<KeyValuePair<string, double>> GetTeamsWinsSUM()
            //  public IEnumerable<KeyValuePair<string, string>> GetTeamsByMotor(string motortype)

            var teamsavgage = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsAVGAge");

            var teamswinssum = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsWinsSUM");

            var teamchiefbydriver = rest.Get<KeyValuePair<string, string>>("stat/GetTeamChiefByDrivers");

            var driversofateam = rest.Get<string>("stat/GetDriversOfaTeam?teamname=Mclaren");

            var teamsbymotor = rest.Get<KeyValuePair<string, string>>("stat/GetTeamsByMotor?motortype=Mercedes M11 EQ");
            ;

        }
    }
}
