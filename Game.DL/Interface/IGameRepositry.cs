using Game.Domain.Entity;

namespace Game.DL.Interface
{
    public interface IGameRepositry
    {
        Task<GameEntity?> GetGameById(int id);
        IQueryable<GameEntity> GetAllGames();
        Task AddGame(GameEntity game);
        Task<bool> UpdateGame(GameEntity game);
        Task<bool?> DeleteGame(int id); 

    }
}
