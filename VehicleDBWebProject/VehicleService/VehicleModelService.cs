using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleService
{
    class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleDBContext _VehicleDB;
        public VehicleModelService(VehicleDBContext VehicleDb)
        {
            _VehicleDB = VehicleDb;
            //PopulateDB();
        }

        private void PopulateDB()
        {
            using (var db = _VehicleDB)
            {
                if (db.VehicleModels.Any())
                {
                    return;
                }

                var models = new List<VehicleModel>()
                {
                new VehicleModel{Name = "Touareg2", VehicleMakeId = 5, Abrv = "TO2"},
                new VehicleModel{Name = "340 Gran Turismo", VehicleMakeId = 1, Abrv = "340"},
                new VehicleModel{Name = "F-150", VehicleMakeId = 3, Abrv = "F15"},
                new VehicleModel{Name = "XE", VehicleMakeId = 2, Abrv = "XE"},
                new VehicleModel{Name = "GT-R", VehicleMakeId = 4, Abrv = "GTR"},
                new VehicleModel{Name = "Focus", VehicleMakeId = 3, Abrv = "FCS"},
                new VehicleModel{Name = "M550", VehicleMakeId = 1, Abrv = "550"},
                new VehicleModel{Name = "Jetta GLI", VehicleMakeId = 5, Abrv = "GLI"},
                new VehicleModel{Name = "350Z", VehicleMakeId = 4, Abrv = "350"},
                new VehicleModel{Name = "I-Pace", VehicleMakeId = 2, Abrv = "IPC"},
                new VehicleModel{Name = "Frontier", VehicleMakeId = 4, Abrv = "FRN"},
                new VehicleModel{Name = "F-Type Coupe", VehicleMakeId = 2, Abrv = "FTP"},
                new VehicleModel{Name = "Mustang", VehicleMakeId = 3, Abrv = "MST"},
                new VehicleModel{Name = "Arteon", VehicleMakeId = 5, Abrv = "ART"},
                new VehicleModel{Name = "228 Gran Coupe", VehicleMakeId = 1, Abrv = "228"},
                };
                models.ForEach(s => db.VehicleModels.Add(s));
                db.SaveChanges();
            }
        }

        public void AddVehicleModel(int MakeId, string Name, string Abrv)
        {
            using (var db = _VehicleDB)
            {
                db.Add(new VehicleModel { VehicleMakeId = MakeId, Name = Name, Abrv = Abrv });
                db.SaveChanges();
            }

        }

        public DbSet<VehicleModel> GetVehicleModels()
        {
            return _VehicleDB.VehicleModels;
        }

        public void DeleteVehicleModel(int Id)
        {
            using (var db = _VehicleDB)
            {
                db.VehicleModels.Remove(db.VehicleModels.First<VehicleModel>(i => i.VehicleModelId == Id));
                db.SaveChanges();
            }
        }
    }
}
