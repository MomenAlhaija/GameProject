using Game.Domain.Entity;

namespace Game.DL.Interface
{
    public interface IDeviceRepositry
    {
        Task<IQueryable<Device?>?> GetAllDevicesAsQueryable();
        Task<Device?> GetDeviceById(int id);
        Task UpdateDevice(Device device);
        Task AddDevice(Device device);
        Task DeleteDevice(int id);
    }
}
