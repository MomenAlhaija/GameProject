using Game.BL.DTO;
using Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Interface
{
    public interface IDeviceService
    {
        Task<IQueryable<DeviceDTO?>?> GetDevicesAsQueryable();
        Task<DeviceDTO?> GetDeviceById(int id);
        Task<DeviceDTO?> AddOrEditDevice(DeviceDTO deviceDTO);
        Task DeleteDevice(int id);

    }
}
