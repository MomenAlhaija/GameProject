using Game.Domain.Entities;
using GameZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
