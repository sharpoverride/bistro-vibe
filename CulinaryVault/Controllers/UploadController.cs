using Microsoft.AspNetCore.Mvc;

namespace CulinaryVault.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("image")]
    public async Task<ActionResult<string>> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        
        if (!allowedExtensions.Contains(extension))
            return BadRequest("Invalid file type. Allowed: jpg, jpeg, png, gif, webp");

        var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads");
        
        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var imageUrl = $"/uploads/{fileName}";
        return Ok(new { url = imageUrl });
    }
}
