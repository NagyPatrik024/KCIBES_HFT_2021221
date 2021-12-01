
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

            bool menu = true;
            while (menu)
            {
                menu = Menu();
            }

            #region CRUD - Driver
            /*
            rest.Post<Driver>(new Driver() { Name = "TEST DRIVER", Age = 99, Wins = 99, TeamId = 1, MotorId = 1 }, "driver");
            rest.Put<Driver>(new Driver() { Id = 22, Name = "UPDATED DRIVER", Age = 99, Wins = 99, TeamId = 1, MotorId = 1 }, "driver");
            var driver = rest.GetSingle<Driver>("driver/8");
            rest.Delete(21, "driver");
            var drivers = rest.Get<Driver>("driver");
            */
            #endregion

            #region CRUD - Team
            /*
            rest.Post<Team>(new Team() { Name = "TEST TEAM", MotorId = 1, Team_Chief = "TEST CHIEF" }, "team");
            rest.Put<Team>(new Team() { Id = 12, Name = "UPDATED TEAM", MotorId = 1, Team_Chief = "UPDATED CHIEF" }, "team");
            var team = rest.GetSingle<Team>("team/2");
            rest.Delete(11, "team");
            var teams = rest.Get<Team>("team");
            */
            #endregion

            #region CRUD - Motor
            /*
            rest.Post<Motor>(new Motor() { Type = "TEST MOTOR" }, "motor");
            rest.Put<Motor>(new Motor() { Id = 6, Type = "UPDATED MOTOR" }, "motor");
            var motor = rest.GetSingle<Motor>("motor/2");
            rest.Delete(5, "motor");
            var motors = rest.Get<Motor>("motor");
            */
            #endregion

            #region NONCRUD
            /*
            var teamsavgage = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsAVGAge");
            var teamswinssum = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsWinsSUM");
            var teamchiefbydriver = rest.Get<KeyValuePair<string, string>>("stat/GetTeamChiefByDrivers");
            var driversofateam = rest.Get<string>("stat/GetDriversOfaTeam/Mclaren");
            var teamsbymotor = rest.Get<KeyValuePair<string, string>>("stat/GetTeamsByMotor/Mercedes M11 EQ");*/
            #endregion
        }
        private static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("1: GetOne");
            Console.WriteLine("2: GetAll");
            Console.WriteLine("3: Post");
            Console.WriteLine("4: Update");
            Console.WriteLine("5: Delete");
            Console.WriteLine("6: NonCRUDs");
            Console.WriteLine("7: Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    GetOne();
                    return true;
                case "2":
                    GetAll();
                    return true;
                case "3":
                    Post();
                    return true;
                case "4":
                    Update();
                    return true;
                case "5":
                    Delete();
                    return true;
                case "6":
                    NonCRUDs();
                    return true;
                case "7":
                    return false;
                default:
                    Console.WriteLine("Try again!");
                    System.Threading.Thread.Sleep(500);
                    Menu();
                    return true;
            }
        }
        private static void GetOne()
        {

            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("From which table do you want data? (driver,team,motor)");
            string table = Console.ReadLine();
            string id = "";
            switch (table)
            {
                case "driver":
                    Console.Write("Give me an id:");
                    id = Console.ReadLine();
                    var driver = rest.GetSingle<Driver>($"driver/{id}");
                    Console.WriteLine($"{driver.Id},{driver.Name},{driver.Wins},{driver.TeamId},{driver.MotorId}");
                    Console.ReadKey();
                    Menu();
                    break;
                case "team":
                    Console.Write("Give me an id:");
                    id = Console.ReadLine();
                    var team = rest.GetSingle<Team>($"team/{id}");
                    Console.WriteLine($"{team.Id},{team.Name},{team.Team_Chief},{team.MotorId}");
                    Console.ReadKey();
                    Menu();
                    break;
                case "motor":
                    Console.Write("Give me an id:");
                    id = Console.ReadLine();
                    var motor = rest.GetSingle<Motor>($"motor/{id}");
                    Console.WriteLine($"{motor.Id},{motor.Type}");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong table name! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    GetOne();
                    break;
            }

        }
        private static void GetAll()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("From which table do you want data? (driver,team,motor)");
            string table = Console.ReadLine();
            switch (table)
            {
                case "driver":
                    var drivers = rest.Get<Driver>("driver");
                    foreach (var driver in drivers)
                    {
                        Console.WriteLine($"{driver.Id},{driver.Name},{driver.Wins},{driver.TeamId},{driver.MotorId}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "team":
                    var teams = rest.Get<Team>("team");
                    foreach (var team in teams)
                    {
                        Console.WriteLine($"{team.Id},{team.Name},{team.Team_Chief},{team.MotorId}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "motor":
                    var motors = rest.Get<Motor>("motor");
                    foreach (var motor in motors)
                    {
                        Console.WriteLine($"{motor.Id},{motor.Type}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong table name! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    GetAll();
                    break;
            }
        }
        private static void Post()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("To which table do you want to insert data? (driver,team,motor)");
            string table = Console.ReadLine();
            switch (table)
            {
                case "driver":
                    Console.WriteLine("Name:");
                    string drivername = Console.ReadLine();
                    Console.WriteLine("Age:");
                    int driverage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Wins:");
                    int driverwins = int.Parse(Console.ReadLine());
                    Console.WriteLine("TeamId:");
                    int driverteamid = int.Parse(Console.ReadLine());
                    Console.WriteLine("MotorId:");
                    int drivermotorid = int.Parse(Console.ReadLine());
                    rest.Post<Driver>(new Driver() { Name = drivername, Age = driverage, Wins = driverwins, TeamId = driverteamid, MotorId = drivermotorid }, "driver");
                    Console.WriteLine("Driver added!");
                    Console.ReadKey();
                    Menu();
                    break;
                case "team":
                    Console.WriteLine("Name:");
                    string teamname = Console.ReadLine();
                    Console.WriteLine("MotorId:");
                    int teammotorid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Team Chief:");
                    string teamchief = Console.ReadLine();
                    rest.Post<Team>(new Team() { Name = teamname, MotorId = teammotorid, Team_Chief = teamchief }, "team");
                    Console.WriteLine("Team added!");
                    Console.ReadKey();
                    Menu();
                    break;
                case "motor":
                    Console.WriteLine("Type:");
                    string motortype = Console.ReadLine();
                    rest.Post<Motor>(new Motor() { Type = "TEST MOTOR" }, "motor");
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong table name! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    GetAll();
                    break;
            }
        }
        private static void Update()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("To which table do you want to insert data? (driver,team,motor)");
            string table = Console.ReadLine();
            switch (table)
            {
                case "driver":
                    Console.WriteLine("Id:");
                    int driverid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string drivername = Console.ReadLine();
                    Console.WriteLine("Age:");
                    int driverage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Wins:");
                    int driverwins = int.Parse(Console.ReadLine());
                    Console.WriteLine("TeamId:");
                    int driverteamid = int.Parse(Console.ReadLine());
                    Console.WriteLine("MotorId:");
                    int drivermotorid = int.Parse(Console.ReadLine());

                    rest.Put<Driver>(new Driver() { Id = driverid, Name = drivername, Age = driverage, Wins = driverwins, TeamId = driverteamid, MotorId = drivermotorid }, "driver");
                    Console.WriteLine("Driver added!");
                    Console.ReadKey();
                    Menu();
                    break;
                case "team":
                    Console.WriteLine("Id:");
                    int teamid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string teamname = Console.ReadLine();
                    Console.WriteLine("MotorId:");
                    int teammotorid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Team Chief:");
                    string teamchief = Console.ReadLine();
                    rest.Put<Team>(new Team() { Id = teamid, Name = teamname, MotorId = teammotorid, Team_Chief = teamchief }, "team");
                    Console.WriteLine("Team added!");
                    Console.ReadKey();
                    Menu();
                    break;
                case "motor":
                    Console.WriteLine("Id:");
                    int motorid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type:");
                    string motortype = Console.ReadLine();
                    rest.Put<Motor>(new Motor() { Id = motorid, Type = "TEST MOTOR" }, "motor");
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong table name! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    Update();
                    break;
            }
        }
        private static void Delete()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("From which table do you want to delete? (driver,team,motor)");
            string table = Console.ReadLine();
            int id;
            switch (table)
            {
                case "driver":
                    Console.Write("Give me an id:");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "driver");
                    Console.ReadKey();
                    Menu();
                    break;
                case "team":
                    Console.Write("Give me an id:");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "team");
                    Console.ReadKey();
                    Menu();
                    break;
                case "motor":
                    Console.Write("Give me an id:");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "motor");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong table name! Try Again!");
                    System.Threading.Thread.Sleep(500);
                    Delete();
                    break;
            }
        }
        private static void NonCRUDs()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:17873");
            Console.WriteLine("Choose: \n 1: GetTeamChiefByDrivers \n 2: GetTeamsAVGAge\n 3: GetTeamsWinsSUM\n 4: GetDriversOfaTeam \n 5: GetTeamsByMotor");

            string methods = Console.ReadLine();
            switch (methods)
            {
                case "1":
                    var teamchiefbydriver = rest.Get<KeyValuePair<string, string>>("stat/GetTeamChiefByDrivers");
                    foreach (var item in teamchiefbydriver)
                    {
                        Console.WriteLine($"{item.Key}, {item.Value}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "2":
                    var teamsavgage = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsAVGAge");
                    foreach (var item in teamsavgage)
                    {
                        Console.WriteLine($"{item.Key}, {item.Value}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "3":
                    var teamswinssum = rest.Get<KeyValuePair<string, double>>("stat/GetTeamsWinsSUM");
                    foreach (var item in teamswinssum)
                    {
                        Console.WriteLine($"{item.Key}, {item.Value}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "4":
                    Console.Write("Give me a team name: ");
                    string teamname = Console.ReadLine();
                    var driversofateam = rest.Get<string>($"stat/GetDriversOfaTeam/{teamname}");
                    foreach (var item in driversofateam)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                case "5":
                    Console.Write("Give me a motor type: ");
                    string motortype = Console.ReadLine();
                    var teamsbymotor = rest.Get<KeyValuePair<string, string>>($"stat/GetTeamsByMotor/{motortype}");
                    foreach (var item in teamsbymotor)
                    {
                        Console.WriteLine($"{item.Key}, {item.Value}");
                    }
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Try Again!");
                    System.Threading.Thread.Sleep(500);
                    NonCRUDs();
                    break;
            }

        }




    }
}
