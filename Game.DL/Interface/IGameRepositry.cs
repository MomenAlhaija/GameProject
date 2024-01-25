using Game.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
