using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.Models;

namespace VMS.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> DeleteVehicleAsync(int id);
    }
}
