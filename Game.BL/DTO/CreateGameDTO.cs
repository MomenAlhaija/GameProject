using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Http;

namespace GameZone.ViewModel
{
    public class CreateGameDTO:GameDTO
    {
        [AllowedExtension(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
