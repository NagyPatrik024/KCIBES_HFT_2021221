using KCIBES_HFT_2021221.Logic;
using KCIBES_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using Moq;
using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        DriverLogic dl;
        TeamLogic tl;
        MotorLogic ml;

        [SetUp]
        public void Init()
        {
            var mockDriverRepository = new Mock<IDriverRepository>();
            var mockTeamRepository = new Mock<ITeamRepository>();
            var mockMotorRepository = new Mock<IMotorRepository>();

           

            Motor fakeMotor = new Motor();
            fakeMotor.Id = 2;
            fakeMotor.Type = "Mercedes M11 EQ";

            Team fakeTeam = new Team();
            fakeTeam.Id = 2;
            fakeTeam.Name = "Mclaren";
            fakeTeam.MotorId = 2;
            fakeTeam.Team_Chief = "Andreas Seidl";

            Driver fakeDriver = new Driver();
            fakeDriver.Id = 8;
            fakeDriver.Name = "Daniel Ricciardo";
            fakeDriver.Age = 32;
            fakeDriver.Wins = 8;
            fakeDriver.TeamId = 2;
            fakeDriver.MotorId = 2;



        }



    }
}
