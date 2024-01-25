using Game.DL.Interface;
using Game.Domain.Data;
using Game.Domain.Entity;
using Game.Shared.EFRepositry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DL.Implement
{
    public class GameRepositry : IGameRepositry
    {
        private readonly AppDbContext _context;
        private readonly EFRepositry _EfRepositry;  
        public GameRepositry(AppDbContext context,EFRepositry EFRepositry)
        {
            _context = context;
            _EfRepositry = EFRepositry; 
        }

        public async Task AddGame(GameEntity game)
        {
           await _EfRepositry.Insert(game);  
        }

        public async Task<bool?> DeleteGame(int id)
        {
            var game=await GetGameById(id);
            _context.Remove(game);
            var rowAffected=await _context.SaveChangesAsync();
            return rowAffected > 0;
        }

        public IQueryable<GameEntity> GetAllGames()
        {
            return _context.Games.
                  Include(c => c.Category).
                  Include(c => c.Devices).
                  ThenInclude(c => c.Device)
                  .AsNoTracking().AsQueryable();
        }

        public async Task<GameEntity?> GetGameById(int id)
        {
            return await _context.Games
                   .Include(c => c.Category)
                   .Include(c => c.Devices)
                   .ThenInclude(c => c.Device)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateGame(GameEntity game)
        {
            _context.Update(game);
            var rowsAffected =await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
