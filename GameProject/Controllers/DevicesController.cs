using Game.BL.DTO;
using Game.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceService _deviceService;
        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _deviceService.GetDevicesAsQueryable();
            return View(model);
        }
        public IActionResult Add()
        {
            var model = new DeviceDTO();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DeviceDTO device)
        {
            await _deviceService.AddOrEditDevice(device);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model=await _deviceService.GetDeviceById(id);   
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DeviceDTO device)
        {
            await _deviceService.AddOrEditDevice(device);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _deviceService.DeleteDevice(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
