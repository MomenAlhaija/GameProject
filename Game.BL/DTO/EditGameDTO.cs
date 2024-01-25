using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Http;

namespace Game.BL.DTO
{
    public class EditGameDTO:GameDTO
    {
        public int Id { get; set; }
        public string? CurrentCover { get; set; }
        [AllowedExtension(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
