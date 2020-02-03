using Microsoft.EntityFrameworkCore;

namespace VehicleService
{
    interface IVehicleMakeService
    {
        void AddVehicleMaker(string Name, string Abrv);
        void DeleteVehicleMaker(int Id);
        DbSet<VehicleMake> GetVehicleMakes();
    }
}