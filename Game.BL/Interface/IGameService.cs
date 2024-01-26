using Game.BL.DTO;

namespace Game.BL.Interface
{
    public interface IGameService
    {
        public string FilePath { get; set; }
        Task GreateGame(CreateGameDTO input);
        Task<IEnumerable<GetGameDTO>> GetAllGames();
        Task<GetGameDTO?> GetGame(int  id);    
        Task EditGame(EditGameDTO input);
        Task<bool> DeleteGame(int id);
    }
}
