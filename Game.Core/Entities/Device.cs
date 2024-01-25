using Game.Shared.Consts;
using System.ComponentModel.DataAnnotations;

namespace Game.Domain.Entity
{
    public class Device:BaseEntity
    {
        [MaxLength(GameConsts.MaxDeviceIconLength)]
        public string Icon { get; set; }=string.Empty;
    }
}
