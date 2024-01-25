using Game.BL.DTO;

namespace Game.BL.Interface
{
    public interface IDeviceService
    {
        Task<IQueryable<DeviceDTO?>?> GetDevicesAsQueryable();
        Task<DeviceDTO?> GetDeviceById(int id);
        Task AddOrEditDevice(DeviceDTO deviceDTO);
        Task DeleteDevice(int id);

    }
}
