using KCIBES_HFT_2021221.Logic;
using KCIBES_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using Moq;
using KCIBES_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

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

            Team fakeTeam = new Team() { Id = 2, Name = "Mclaren", MotorId = 2, Team_Chief = "Andreas Seidl" };
            Motor fakeMotor = new Motor() { Id = 2, Type = "Mercedes M11 EQ" };
            var drivers = new List<Driver>()
            {
             new Driver() {
                 Id = 4,
                 Name = "Lando Norris",
                 Age = 22,
                 Wins = 0,
                 TeamId = 2,
                 MotorId = 2,
                 Team = fakeTeam,
                 Motor = fakeMotor},
             new Driver() {
                 Id = 8,
                 Name = "Daniel Ricciardo",
                 Age = 32,
                 Wins = 8,
                 TeamId = 2,
                 MotorId = 2,
                 Team = fakeTeam,
                 Motor = fakeMotor}
            }.AsQueryable();

            var teamlist = new List<Team> { fakeTeam }.AsQueryable();
            var motorlist = new List<Motor> { fakeMotor }.AsQueryable();
            mockDriverRepository.Setup((t) => t.GetAll()).Returns(drivers);
            mockTeamRepository.Setup((t) => t.GetAll()).Returns(teamlist);
            mockMotorRepository.Setup((t) => t.GetAll()).Returns(motorlist);
            dl = new DriverLogic(mockDriverRepository.Object, mockTeamRepository.Object);
            tl = new TeamLogic(mockTeamRepository.Object, mockDriverRepository.Object, mockMotorRepository.Object);
            ml = new MotorLogic(mockMotorRepository.Object);
        }

        [TestCase(5, null)]
        public void MotorCreateTest(int id, string type)
        {
            Assert.That(() => ml.CreateOne(id, type), Throws.TypeOf<ArgumentNullException>());
        }
        [TestCase(5, null, 20, 4, 2, 2)]
        public void DriverCreateTest(int id, string name, int age, int wins, int teamid, int motorid)
        {
            Assert.That(() => dl.CreateOne(id, name, age, wins, teamid, motorid), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(11, "Ujcsapat", 4, null)]
        public void TeamCreateTest(int id, string name, int motorid, string team_chief)
        {
            Assert.That(() => tl.CreateOne(id, name, motorid, team_chief), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(10)]
        public void DriverDeleteOneTest(int id)
        {
            Assert.That(() => dl.DeleteOne(id), Throws.TypeOf<KeyNotFoundException>());
        }

        //TODO kell még egy
        [TestCase(10,"Daniel Ricciardo",32,9,2,2)]
        public void UpdateDriverTest(int id, string name, int age, int wins, int teamid, int motorid)
        {
            Assert.That(() => dl.UpdateDriver(id, name, age, wins, teamid, motorid), Throws.TypeOf<KeyNotFoundException>());
        }

        [TestCase("Mclaren")]
        public void GetDriversOfaTeamTest(string teamname)
        {
            var expected = new List<string>()
            {
                "Lando Norris",
                "Daniel Ricciardo"
            };
            Assert.That(dl.GetDriversOfaTeam(teamname), Is.EqualTo(expected));
        }

        [Test]
        public void GetTeamChiefByDriversTest()
        {
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Lando Norris","Andreas Seidl"),
                new KeyValuePair<string, string>("Daniel Ricciardo","Andreas Seidl")
            };

            Assert.That(dl.GetTeamChiefByDrivers(), Is.EqualTo(expected));
        }

        [Test]
        public void GetTeamsAVGAgeTest()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Mclaren",27)
            };
            Assert.That(tl.GetTeamsAVGAge(), Is.EqualTo(expected));
        }

        [Test]
        public void GetTeamsWinsSUMTest()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Mclaren",8)
            };
            Assert.That(tl.GetTeamsWinsSUM(), Is.EqualTo(expected));
        }

        [TestCase("Mercedes M11 EQ")]
        public void GetTeamsByMotorTest(string motortype)
        {
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Mclaren","Mercedes M11 EQ")
            };
            Assert.That(tl.GetTeamsByMotor(motortype), Is.EqualTo(expected));
        }





    }
}
