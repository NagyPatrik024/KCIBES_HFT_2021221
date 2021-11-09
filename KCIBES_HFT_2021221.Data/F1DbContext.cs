using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Data
{
    public class F1DbContext : DbContext
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
            modelBuilder.Entity<Driver>(entity =>
            {
                entity
                .HasOne(driver => driver.Motor)
                .WithMany(motor => motor.Drivers)
                .HasForeignKey(driver => driver.MotorId)
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


            Motor Ferrari = new Motor() { Id = 1, Type = "Ferrari 064" };
            Motor Mercedes = new Motor() { Id = 2, Type = "Mercedes M11 EQ" };
            Motor Honda = new Motor() { Id = 3, Type = "Honda RA620H" };
            Motor Renault = new Motor() { Id = 4, Type = "	Renault E-Tech 20B" };

            Team TeamFerrari = new Team() { Id = 1, Name = "Ferrari", MotorId = 1, Team_Chief = "Mattia Binotto" };
            Team TeamMclaren = new Team() { Id = 2, Name = "Mclaren", MotorId = 2, Team_Chief = "Andreas Seidl" };
            Team TeamRedBull = new Team() { Id = 3, Name = "Red Bull Racing", MotorId = 3, Team_Chief = "Christian Horner" };
            Team TeamMercedes = new Team() { Id = 4, Name = "Mercedes", MotorId = 2, Team_Chief = "Toto Wolff" };
            Team TeamAlpine = new Team() { Id = 5, Name = "Alpine", MotorId = 4, Team_Chief = "Davide Brivio" };
            Team TeamAlphatauri = new Team() { Id = 6, Name = "Alphatauri", MotorId = 3, Team_Chief = "Franz Tost" };
            Team TeamAstonMartin = new Team() { Id = 7, Name = "Aston Martin", MotorId = 2, Team_Chief = "Andrew Green" };
            Team TeamWilliams = new Team() { Id = 8, Name = "Williams", MotorId = 2, Team_Chief = "Jost Capito" };
            Team TeamAlfaRomeo = new Team() { Id = 9, Name = "Alfa Romeo Racing", MotorId = 1, Team_Chief = "Frédéric Vasseur" };
            Team TeamHass = new Team() { Id = 10, Name = "Haas", MotorId = 1, Team_Chief = "Guenther Steiner" };


            Driver VER = new Driver() { Id = 1, Name = "Max Verstappen", DateofBirth = "30/09/1997", Wins = 17, TeamId = TeamRedBull.Id, MotorId = Honda.Id };
            Driver HAM = new Driver() { Id = 2, Name = "Lewis Hamilton", DateofBirth = "07/01/1985", Wins = 100, TeamId = 4, MotorId = Mercedes.Id };
            Driver BOT = new Driver() { Id = 3, Name = "Valtteri Bottas", DateofBirth = "28/08/1989", Wins = 10, TeamId = 4, MotorId = Mercedes.Id };
            Driver NOR = new Driver() { Id = 4, Name = "Lando Norris", DateofBirth = "13/11/1999", Wins = 0, TeamId = 2, MotorId = Mercedes.Id };
            Driver PER = new Driver() { Id = 5, Name = "Sergio Perez", DateofBirth = "26/01/1990", Wins = 2, TeamId = 3, MotorId = Honda.Id };
            Driver SAI = new Driver() { Id = 6, Name = "Carlos Sainz", DateofBirth = "01/09/1994", Wins = 0, TeamId = 1, MotorId = Ferrari.Id };
            Driver LEC = new Driver() { Id = 7, Name = "Charles Leclerc", DateofBirth = "16/10/1997", Wins = 2, TeamId = 1, MotorId = Ferrari.Id };
            Driver RIC = new Driver() { Id = 8, Name = "Daniel Ricciardo", DateofBirth = "01/07/1989", Wins = 8, TeamId = 2, MotorId = Mercedes.Id };
            Driver GAS = new Driver() { Id = 9, Name = "Pierre Gasly", DateofBirth = "07/02/1996", Wins = 1, TeamId = 6, MotorId = Honda.Id };
            Driver ALO = new Driver() { Id = 10, Name = "Fernando Alonso", DateofBirth = "29/07/1981", Wins = 32, TeamId = 5, MotorId = Mercedes.Id };
            Driver OCO = new Driver() { Id = 11, Name = "Esteban Ocon", DateofBirth = "17/09/1996", Wins = 1, TeamId = 5, MotorId = Mercedes.Id };
            Driver VET = new Driver() { Id = 12, Name = "Sebastian Vetel", DateofBirth = "03/07/1987", Wins = 53, TeamId = 7, MotorId = Mercedes.Id };
            Driver STR = new Driver() { Id = 13, Name = "Lance Stroll", DateofBirth = "03/07/1987", Wins = 0, TeamId = 7, MotorId = Mercedes.Id };
            Driver TSU = new Driver() { Id = 14, Name = "Yuki Tsunoda", DateofBirth = "11/05/2000", Wins = 0, TeamId = 6, MotorId = Honda.Id };
            Driver RUS = new Driver() { Id = 15, Name = "George Russel", DateofBirth = "15/02/1998", Wins = 0, TeamId = 8, MotorId = Mercedes.Id };
            Driver LAT = new Driver() { Id = 16, Name = "Nicholas Latifi", DateofBirth = "29/06/1995", Wins = 0, TeamId = 8, MotorId = Mercedes.Id };
            Driver RAI = new Driver() { Id = 17, Name = "Kimi Raikonnen", DateofBirth = "17/10/1979", Wins = 21, TeamId = 9, MotorId = Ferrari.Id };
            Driver GIO = new Driver() { Id = 18, Name = "Antonio Giovinazzi", DateofBirth = "14/12/1993", Wins = 0, TeamId = 9, MotorId = Ferrari.Id };
            Driver MSC = new Driver() { Id = 19, Name = "Mick Schumacher", DateofBirth = "22/03/1999", Wins = 0, TeamId = 10, MotorId = Ferrari.Id };
            Driver MAZ = new Driver() { Id = 20, Name = "Nikita Mazepin", DateofBirth = "02/03/1999", Wins = 0, TeamId = 10, MotorId = Ferrari.Id };

            modelBuilder.Entity<Motor>().HasData(Ferrari, Mercedes, Honda, Renault);
            modelBuilder.Entity<Team>().HasData(TeamFerrari, TeamMclaren, TeamAlfaRomeo, TeamAlphatauri, TeamAlpine, TeamAstonMartin, TeamHass, TeamMercedes, TeamRedBull, TeamWilliams);
            modelBuilder.Entity<Driver>().HasData(VER, HAM, BOT, NOR, PER, SAI, LEC, RIC, GAS, ALO, OCO, VET, STR, TSU, RUS, LAT, RAI, GIO, MSC, MAZ);
        }
    }
}
