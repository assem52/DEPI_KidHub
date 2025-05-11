using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace KidHub.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ICloudinary _cloudinaryService;

        public ImagesController(ICloudinary cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (file.Length > 30 * 1024 * 1024) // Example: Limit file size to 2MB
            {
                return BadRequest("File size exceeds the limit.");
            }

            var uploadResult = await _cloudinaryService.UploadAsync(file);
            return Ok(uploadResult);

            if (uploadResult != null && !string.IsNullOrEmpty(uploadResult.Url))
            {
                // Image uploaded successfully
                // You might want to save the URL and other information to your database here

                return Ok(new { Message = "Image uploaded successfully!", Url = uploadResult.Url, PublicId = uploadResult.PublicId });
            }
            else
            {
                // Image upload failed
                return StatusCode(500, new { Message = "Image upload failed." });
            }
        }
    }

}
    

    


    




