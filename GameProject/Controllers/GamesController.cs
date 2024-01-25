using Game.BL.DTO;
using Game.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.Controllers
{
    public class GamesController : Controller
    {
        private readonly  ICategoryService _categoryService;
        private readonly IDeviceService _deviceService;
        private readonly IGameService _gameService;
        public GamesController(ICategoryService categoryService, IDeviceService deviceService, IGameService gameService)
        {
            _categoryService = categoryService;
            _deviceService = deviceService;
            _gameService = gameService;

        }
        public IActionResult Index()
        {
            var game=_gameService.GetAllGames();
            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> AddGame()
        {
            CreateGameDTO model = new()
            {
                Categories =await _categoryService.GetSelectListCategories(),
                Devices =await _deviceService.GetSelectListDevices(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddGame(CreateGameDTO input)
        {
            if (!ModelState.IsValid)
            {
                input.Categories =await _categoryService.GetSelectListCategories();
                input.Devices=await _deviceService.GetSelectListDevices();
                return View(input);
            }
            await _gameService.GreateGame(input);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var game= await _gameService.GetGame(id);
            return View(game);  
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game =await _gameService.GetGame(id);
            if (game is null)
                throw new Exception("The Game Not Found");
            EditGameDTO viewModel = new EditGameDTO()
            {
                Id=id,
                Name=game.Name,
                Description=game.Description,
                CategoryId=game.CategoryId,
                SelectedDevices=game.Devices!.Select(d=>d.Id!.Value).ToList(),
                Categories=await _categoryService.GetSelectListCategories(),
                Devices= await _deviceService.GetSelectListDevices(),
                CurrentCover=game.Cover,
            }; 
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditGameDTO input)
        {
            if (!ModelState.IsValid)
            {
                input.Categories = await _categoryService.GetSelectListCategories();
                input.Devices = await _deviceService.GetSelectListDevices();
                return View(input);
            }
            await _gameService.EditGame(input);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted=await _gameService.DeleteGame(id);
            return isDeleted? Ok():BadRequest();
        }
    }
}
