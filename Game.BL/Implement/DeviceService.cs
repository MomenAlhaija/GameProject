using Game.BL.DTO;
using Game.BL.Interface;

namespace Game.BL.Implement
{
    public class DeviceService : IDeviceService
    {
        public Task<DeviceDTO?> AddOrEditDevice(DeviceDTO deviceDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDevice(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceDTO?> GetDeviceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DeviceDTO?>?> GetDevicesAsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
