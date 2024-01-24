using Microsoft.AspNetCore.Mvc;

namespace GameProject.Controllers
{
    public class DevicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(char c)
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(char c)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
