using Game.DL.Interface;
using Game.Domain.Data;
using Game.Domain.Entities;
using Game.Shared.EFRepositry;
using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DL.Implement
{
    public class DeviceRepositry : IDeviceRepositry
    {
        private readonly IEFRepositry _EFRepositry;
        private readonly AppDbContext _context;
        public DeviceRepositry(IEFRepositry EFRepositry, AppDbContext context)
        {
            _EFRepositry = EFRepositry;
            _context = context;

        }
        public async Task AddDevice(Device device)
        {
            await _EFRepositry.Insert(device);
        }

    
        public async Task DeleteDevice(int id)
        {
            var device = await GetDeviceById(id);
            await _EFRepositry.Delete(device);
        }

        public async Task<IQueryable<Device?>?> GetAllDevicesAsQueryable()
        {
            return _context.Devices.AsQueryable().AsNoTracking();
        }

        public async Task<Device?> GetDeviceById(int id)
        {
            return await _context.Devices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateDevice(Device device)
        {
          await _EFRepositry.Update(device);
        }
    }
}
