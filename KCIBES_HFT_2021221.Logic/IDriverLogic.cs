﻿using KCIBES_HFT_2021221.Models;
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
        void CreateOne(Driver driver);
        void UpdateDriver(int id, Driver driver);
        IEnumerable<string> GetDriversOfaTeam(string teamname);

        IEnumerable<KeyValuePair<string, string>> GetTeamChiefByDriver(); 



    }
}
