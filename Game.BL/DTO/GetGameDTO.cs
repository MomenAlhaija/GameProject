using Game.Shared.Consts;
using System.ComponentModel.DataAnnotations;

namespace Game.BL.DTO
{
    public class GetGameDTO
    {
        public int? Id { get; set; } 
        [MaxLength(GameConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(GameConsts.MaxGameDescriptionLength)]
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(GameConsts.MaxNameLength)]
        public string CategoryName { get; set; }
        public List<DeviceDTO>? Devices { get; set; }
    }
}
