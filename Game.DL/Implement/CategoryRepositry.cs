using Game.DL.Interface;
using Game.Domain.Data;
using Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DL.Implement
{
    public class CategoryRepositry : ICategoryRepositry
    {
        private readonly AppDbContext _Context;
        public CategoryRepositry(AppDbContext context)
        {
           _Context = context;
        }
        public async Task<IQueryable<Category?>?> GetCategoriesAsQueryable()
        {
            return  _Context.Categories!.AsQueryable()??null;
        }
    }
}
