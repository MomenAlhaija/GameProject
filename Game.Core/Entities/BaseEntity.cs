using Game.Shared.Consts;
using System.ComponentModel.DataAnnotations;

namespace Game.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(GameConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
    }
}
