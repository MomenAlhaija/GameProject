using Game.BL.DTO;
using GameZone.ViewModel;

namespace GameZone.Services
{
    public interface IGameService
    {
        Task GreateGame(CreateGameDTO input);
        Task<IEnumerable<GetGameDTO>> GetAllGames();
        Task<GetGameDTO?> GetGame(int  id);    
        Task EditGame(EditGameDTO input);
        Task<bool> DeleteGame(int id);
    }
}
