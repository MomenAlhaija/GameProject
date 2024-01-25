using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shared.EFRepositry
{
    public interface IEFRepositry
    {
        Task Insert(object obj);
        Task Delete(object obj);
        Task Update(object obj);
    }
}
