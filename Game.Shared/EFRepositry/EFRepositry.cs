using Game.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shared.EFRepositry
{
    public class EFRepositry : IEFRepositry
    {
        private readonly AppDbContext _context;
        public EFRepositry(AppDbContext context)
        {
            _context=context;
        }
        public async Task Delete(object obj)
        {
            _context.Remove(obj);
           await _context.SaveChangesAsync();
        }

        public async Task Insert(object obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task Update(object obj)
        {
            _context.Update(obj);
           await _context.SaveChangesAsync();
        }
    }
}
