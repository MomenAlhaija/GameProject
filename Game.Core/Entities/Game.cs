using Game.Shared.Consts;
using System.ComponentModel.DataAnnotations;

namespace Game.Domain.Entity
{
    public class GameEntity:BaseEntity
    {
        [MaxLength(GameConsts.MaxGameDescriptionLength)]
        public string Description { get; set; }= string.Empty;
        public string Cover { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<GameDevice> Devices { get; set; } =new List<GameDevice>();      
    }
}
