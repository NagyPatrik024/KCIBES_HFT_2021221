using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Data
{
    class F1DbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Motor> Motors { get; set; }
        public F1DbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\myDB.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity
                .HasOne(driver => driver.Team)
                .WithMany(team => team.Drivers)
                .HasForeignKey(driver => driver.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(team => team.Motor)
                .WithMany(motor => motor.Teams)
                .HasForeignKey(team => team.MotorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Motor Ferrari = new Motor() { MotorId = 1, Type = "Ferrari 064" };
            Motor Mercedes = new Motor() { MotorId = 2, Type = "Mercedes M11 EQ" };
            Motor Honda = new Motor() { MotorId = 3, Type = "Honda RA620H" };
            Motor Renault = new Motor() { MotorId = 4, Type = "	Renault E-Tech 20B"};

            Team TeamFerrari = new Team() { TeamId = 1, Name = "Ferrari", MotorId = Ferrari.MotorId, Team_Chief = "Mattia Binotto", };
            Team TeamMclaren = new Team() { TeamId = 2, Name = "Mclaren", MotorId = Mercedes.MotorId, Team_Chief = "Andreas Seidl" };
            Team TeamRedBull = new Team() { TeamId = 3, Name = "Red Bull Racing", MotorId = Honda.MotorId, Team_Chief = "Christian Horner" };
            Team TeamMercedes = new Team() { TeamId = 4, Name = "Mercedes", MotorId = Mercedes.MotorId, Team_Chief = "Toto Wolff" };
            Team TeamAlpine = new Team() { TeamId = 5, Name = "Alpine", MotorId = Renault.MotorId, Team_Chief = "Davide Brivio" };
            Team TeamAlphatauri = new Team() { TeamId = 6, Name = "Alphatauri", MotorId = Honda.MotorId, Team_Chief = "Franz Tost" };
            Team TeamAstonMartin = new Team() { TeamId = 7, Name = "Aston Martin", MotorId = Mercedes.MotorId, Team_Chief = "Andrew Green" };
            Team TeamWilliams = new Team() { TeamId = 8, Name = "Williams", MotorId = Mercedes.MotorId, Team_Chief = "Jost Capito" };
            Team TeamAlfaRomeo = new Team() { TeamId = 9, Name = "Alfa Romeo Racing", MotorId = Ferrari.MotorId, Team_Chief = "Frédéric Vasseur" };
            Team TeamHass = new Team() { TeamId = 10, Name = "Haas", MotorId = Ferrari.MotorId, Team_Chief = "Guenther Steiner"};

            Driver VER = new Driver() { DriverId = 1, Name = "Max Verstappen", DateofBirth = "30/09/1997", Wins = 17 , TeamId=TeamRedBull.TeamId};
            Driver HAM = new Driver() { DriverId = 2, Name = "Lewis Hamilton", DateofBirth = "07/01/1985", Wins = 100, TeamId =TeamMercedes.TeamId};
            Driver BOT = new Driver() { DriverId = 3, Name = "Valtteri Bottas", DateofBirth = "28/08/1989", Wins = 10, TeamId = TeamMercedes.TeamId };
            Driver NOR = new Driver() { DriverId = 4, Name = "Lando Norris", DateofBirth = "13/11/1999", Wins = 0, TeamId = TeamMclaren.TeamId };
            Driver PER = new Driver() { DriverId = 5, Name = "Sergio Perez", DateofBirth = "26/01/1990", Wins = 2, TeamId = TeamRedBull.TeamId };
            Driver SAI = new Driver() { DriverId = 6, Name = "Carlos Sainz", DateofBirth = "01/09/1994", Wins = 0, TeamId = TeamFerrari.TeamId };
            Driver LEC = new Driver() { DriverId = 7, Name = "Charles Leclerc", DateofBirth = "16/10/1997", Wins = 2, TeamId = TeamFerrari.TeamId };
            Driver RIC = new Driver() { DriverId = 8, Name = "Daniel Ricciardo", DateofBirth = "01/07/1989", Wins = 8, TeamId = TeamMclaren.TeamId};
            Driver GAS = new Driver() { DriverId = 9, Name = "Pierre Gasly", DateofBirth = "07/02/1996", Wins = 1, TeamId = TeamAlphatauri.TeamId};
            Driver ALO = new Driver() { DriverId = 10, Name = "Fernando Alonso", DateofBirth = "29/07/1981", Wins = 32, TeamId = TeamAlpine.TeamId};
            Driver OCO = new Driver() { DriverId = 11, Name = "Esteban Ocon", DateofBirth = "17/09/1996", Wins = 1, TeamId = TeamAlpine.TeamId };
            Driver VET = new Driver() { DriverId = 12, Name = "Sebastian Vetel", DateofBirth = "03/07/1987", Wins = 53, TeamId = TeamAstonMartin.TeamId};
            Driver STR = new Driver() { DriverId = 13, Name = "Lance Stroll",DateofBirth = "03/07/1987", Wins = 0, TeamId = TeamAstonMartin.TeamId };
            Driver TSU = new Driver() { DriverId = 14, Name = "Yuki Tsunoda", DateofBirth = "11/05/2000", Wins = 0, TeamId = TeamAlphatauri.TeamId };
            Driver RUS = new Driver() { DriverId = 15, Name = "George Russel", DateofBirth = "15/02/1998", Wins = 0, TeamId =TeamWilliams.TeamId };
            Driver LAT = new Driver() { DriverId = 16, Name = "Nicholas Latifi", DateofBirth = "29/06/1995", Wins = 0, TeamId = TeamWilliams.TeamId };
            Driver RAI = new Driver() { DriverId = 17, Name = "Kimi Raikonnen", DateofBirth = "17/10/1979", Wins = 21, TeamId = TeamAlfaRomeo.TeamId};
            Driver GIO = new Driver() { DriverId = 18, Name = "Antonio Giovinazzi", DateofBirth = "14/12/1993", Wins = 0, TeamId = TeamAlfaRomeo.TeamId };
            Driver MSC = new Driver() { DriverId = 19, Name = "Mick Schumacher", DateofBirth = "22/03/1999", Wins = 0, TeamId = TeamHass.TeamId };
            Driver MAZ = new Driver() { DriverId = 20, Name = "Nikita Mazepin", DateofBirth = "02/03/1999", Wins = 0, TeamId = TeamHass.TeamId };
        }
    }
}
