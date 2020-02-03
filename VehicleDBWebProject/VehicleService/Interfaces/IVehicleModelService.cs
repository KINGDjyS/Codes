using Microsoft.EntityFrameworkCore;

namespace VehicleService
{
    interface IVehicleModelService
    {
        void AddVehicleModel(int MakeId, string Name, string Abrv);
        void DeleteVehicleModel(int Id);
        DbSet<VehicleModel> GetVehicleModels();
    }
}