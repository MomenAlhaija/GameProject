using Game.BL.DTO;
using Game.BL.Interface;
using Game.DL.Interface;
using Game.Domain.Entity;
using GameZone.Settings;
using Microsoft.AspNetCore.Http;

namespace Game.BL.Implement
{
    public class GameService : IGameService
    {
        public readonly IGameRepositry _gameRepositry;
        private string _imagePath;

        public GameService(IGameRepositry gameRepositry)
        {
            _gameRepositry = gameRepositry;
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
                Description = game.Description,
                Devices=game.Devices.Select(p=>new DeviceDTO
                {
                    Id=p.Device.Id,
                    Name=p.Device.Name,
                    DeviceIcon=p.Device.Icon,
                }).ToList(),
            };
        }

        public async Task<IEnumerable<GetGameDTO>> GetAllGames()
        {
           
            var games =_gameRepositry.GetAllGames();

            List<GetGameDTO> getGameDTOs = games.Select(p => new GetGameDTO
            {
                Id = p.Id,
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
            await _gameRepositry.AddGame(new Game.Domain.Entity.GameEntity
            {
                Name = input.Name,
                Description = input.Description,
                CategoryId = input.CategoryId,
                Cover = coverName,
                Devices = input.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            });
        }

        public async Task EditGame(EditGameDTO input)
        {
            var game = await _gameRepositry.GetGameById(input.Id);
            if (game is null) 
                throw new Exception($"Not Found The Game With Id {input.Id}");
            game.Name = input.Name;
            game.Description=input.Description;
            game.Devices = input.SelectedDevices.Select(d=>new GameDevice() { DeviceId=d }).ToList();
            game.CategoryId = input.CategoryId;
            var oldGameName=game.Cover;  
            if(input.Cover is not null)
                game.Cover=await SaveCover(input.Cover);
            bool isUpdate=await _gameRepositry.UpdateGame(game);
            if(isUpdate && input.Cover is not null)
                File.Delete(Path.Combine(_imagePath, oldGameName));
            
        }


        public async Task<bool> DeleteGame(int id)
        {
            bool isDeleted = false;
            var game = await _gameRepositry.GetGameById(id);
            isDeleted = _gameRepositry.DeleteGame(id).Result!.Value;
            if (isDeleted) {
                File.Delete(Path.Combine(_imagePath,game.Name));
            };
            return isDeleted;
        }
        public void Initialize(string imagePath)
        {
            _imagePath = imagePath;
        }

        #region Private Method

        public async Task<string?> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);           
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                cover.CopyTo(fileStream);
            }
            return coverName;
        }
        #endregion

    }
}
