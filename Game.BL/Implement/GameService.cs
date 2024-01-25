using Game.BL.DTO;
using Game.DL.Implement;
using Game.DL.Interface;
using GameZone.Models;
using GameZone.Settings;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        public readonly IGameRepositry _gameRepositry; 
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;
        public GameService(IGameRepositry gameRepositry, IWebHostEnvironment webHostEnvironment)
        {
            _gameRepositry = gameRepositry;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.FilePath}";
        }

        public async Task<GetGameDTO?> GetGame(int id)
        {
            var game=await _gameRepositry.GetGameById(id);
            return new GetGameDTO
            {
                Name = game.Name,
                CategoryName = game.Category.Name,
                CategoryId = game.Category.Id,
                Cover = game.Cover,
                Devices=game.Devices.Select(p=>new DeviceDTO
                {
                    Id=p.Device.Id,
                    Name=p.Device.Name,
                    DeviceIcon=p.Device.Icon,
                }).ToList(),
            };
        }

        public IEnumerable<GetGameDTO> GetAllGames()
        {
           
            var games = await _gameRepositry.GetGamesAsQueryable();

            List<GetGameDTO> getGameDTOs = games.Select(p => new GetGameDTO
            {
                CategoryId = p.CategoryId,
                Name = p.Name,
                Description = p.Description,
                Cover = p.Cover,
                Devices = p.Devices.Select(d => new DeviceDTO
                {
                    Id = d.Device.Id,
                    Name = d.Device.Name,
                    DeviceIcon = d.Device.Icon
                }).ToList()
            }).ToList();

            return getGameDTOs;
            

        }

        public async Task GreateGame(CreateGameDTO input)
        {
            var coverName =await SaveCover(input.Cover);
            Game game = new()
            {
                Name=input.Name,
                Description=input.Description,
                CategoryId=input.CategoryId,
                Cover=coverName,
                Devices=input.SelectedDevices.Select(d=>new GameDevice { DeviceId=d}).ToList()
            };
            _context.Add(game);
            _context.SaveChanges();
        }

        public async Task EditGame(EditGameFormViewModel input)
        {
            var game = await _context.Games.Include(g=>g.Devices).ThenInclude(c=>c.Device).FirstOrDefaultAsync(x=>x.Id==input.Id);
            if (game is null ) 
                throw new Exception("Not Found The Game");
            game.Name = input.Name;
            game.Description=input.Description;
            game.Devices = input.SelectedDevices.Select(d=>new GameDevice() { DeviceId=d }).ToList();
            game.CategoryId = input.CategoryId;
            var oldGameName=game.Cover;  
            if(input.Cover is not null)
                game.Cover=await SaveCover(input.Cover);
            _context.Update(game);
            var rowsAffected= _context.SaveChanges();
            if(rowsAffected>0 && input.Cover is not null)
                File.Delete(Path.Combine(_imagePath, oldGameName));
            else
                File.Delete(Path.Combine(_imagePath, game.Cover));
        }


        public async Task<bool> DeleteGame(int id)
        {
            bool isDeleted = false;
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return isDeleted;
            _context.Games.Remove(game);
            var affectedRows=_context.SaveChanges();
            if (affectedRows > 0) {

                isDeleted = true;
                File.Delete(Path.Combine(_imagePath,game.Name));
            };
            return isDeleted;
        }


        #region Private Method
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coverName;
        }
        #endregion

    }
}
