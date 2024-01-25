using Game.BL.DTO;
using Game.BL.Interface;
using Game.DL.Interface;
using Game.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Game.BL.Implement
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepositry _deviceRepositry;
        public DeviceService(IDeviceRepositry deviceRepositry)
        {
            _deviceRepositry = deviceRepositry;
        }
        public async Task AddOrEditDevice(DeviceDTO deviceDTO)
        {
            if(deviceDTO.Id is null) {
                   await _deviceRepositry.AddDevice(new Device { 
                   Name=deviceDTO?.Name!,
                   Icon=deviceDTO?.DeviceIcon!
                });
            }
            else
            {
                await _deviceRepositry.UpdateDevice(new Device
                {
                    Id = deviceDTO.Id.Value,
                    Name = deviceDTO?.Name!,
                    Icon = deviceDTO?.DeviceIcon!
                });
            }
        }

        public async Task DeleteDevice(int id)
        {
           await _deviceRepositry.DeleteDevice(id);
        }

        public async Task<DeviceDTO?> GetDeviceById(int id)
        {
            var device=await _deviceRepositry.GetDeviceById(id);
            if (device is Device && device is not null)
                return new DeviceDTO
                {
                    Id = device.Id,
                    Name = device.Name,
                    DeviceIcon = device.Icon,
                };
            else
                throw new Exception($"Not Found Any Device With Id is {id}");
        }

        public async Task<IQueryable<DeviceDTO?>?> GetDevicesAsQueryable()
        {
            var devices=await _deviceRepositry.GetAllDevicesAsQueryable();
            return devices?.Select(c => new DeviceDTO
            {
                Id = c!.Id,
                Name = c!.Name,
                DeviceIcon= c!.Icon,
            }).AsNoTracking().AsQueryable();
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectListDevices()
        {
            var devices =await _deviceRepositry.GetAllDevicesAsQueryable();
            return devices.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).AsNoTracking().OrderBy(c => c.Text).ToList();
        }
    }
}
