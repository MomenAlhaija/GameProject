using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Http;

namespace Game.BL.DTO
{
    public class CreateGameDTO:GameDTO
    {
        [AllowedExtension(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
