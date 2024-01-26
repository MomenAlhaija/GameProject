using Game.Shared.Consts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Game.BL.DTO
{
    public class GameDTO
    {
        [MaxLength(GameConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
        [Display(Name="Category Name")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Support Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [MaxLength(GameConsts.MaxGameDescriptionLength)]
        public string Description { get; set; } = string.Empty;

    }
}
