﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleService
{
    class VehicleMakeService
    {
        private readonly VehicleDBContext _VehicleDB;
        public VehicleMakeService(VehicleDBContext VehicleDB)
        {
            _VehicleDB = VehicleDB;
            //PopulateDB();
        }

        private void PopulateDB()
        {
            using (var db = _VehicleDB)
            {
                if (db.VehicleMakes.Any())
                {
                    return;
                }

                var makes = new List<VehicleMake>()
                {
                new VehicleMake{Name = "Bmw", Abrv = "BMW"},
                new VehicleMake{Name = "Jaguar", Abrv = "JAG"},
                new VehicleMake{Name = "Ford", Abrv = "FRD"},
                new VehicleMake{Name = "Nissan", Abrv = "NIS"},
                new VehicleMake{Name = "VolksWagen", Abrv = "VW"},
                };
                makes.ForEach(s => db.VehicleMakes.Add(s));
                db.SaveChanges();
            }
            
        }

        public void AddVehicleMaker(string Name, string Abrv)
        {
            using(var db = _VehicleDB)
            {
                db.Add(new VehicleMake { Name = Name, Abrv = Abrv });
                db.SaveChanges();
            }
            
        }

        public DbSet<VehicleMake> GetVehicleMakes()
        {
            return _VehicleDB.VehicleMakes;
        }

        public void DeleteVehicleMaker(int Id)
        {
            using (var db = _VehicleDB)
            {
                db.VehicleMakes.Remove(db.VehicleMakes.First<VehicleMake>(i => i.VehicleMakeId == Id));
                db.SaveChanges();
            }
        }

    }
}
