using CulinaryVault.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CulinaryVault.Tests.Unit.Controllers;

public class UploadControllerTests : IDisposable
{
    private readonly Mock<IWebHostEnvironment> _mockEnvironment;
    private readonly UploadController _controller;
    private readonly string _testWebRootPath;

    public UploadControllerTests()
    {
        _testWebRootPath = Path.Combine(Path.GetTempPath(), $"test_wwwroot_{Guid.NewGuid()}");
        Directory.CreateDirectory(_testWebRootPath);

        _mockEnvironment = new Mock<IWebHostEnvironment>();
        _mockEnvironment.Setup(e => e.WebRootPath).Returns(_testWebRootPath);

        _controller = new UploadController(_mockEnvironment.Object);
    }

    public void Dispose()
    {
        if (Directory.Exists(_testWebRootPath))
        {
            Directory.Delete(_testWebRootPath, true);
        }
    }

    #region UploadImage Tests

    [Fact]
    public async Task UploadImage_NullFile_ReturnsBadRequest()
    {
        // Act
        var result = await _controller.UploadImage(null!);

        // Assert
        var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().Be("No file uploaded");
    }

    [Fact]
    public async Task UploadImage_EmptyFile_ReturnsBadRequest()
    {
        // Arrange
        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.Length).Returns(0);

        // Act
        var result = await _controller.UploadImage(mockFile.Object);

        // Assert
        var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().Be("No file uploaded");
    }

    [Theory]
    [InlineData(".txt")]
    [InlineData(".pdf")]
    [InlineData(".exe")]
    [InlineData(".doc")]
    [InlineData(".html")]
    public async Task UploadImage_InvalidFileExtension_ReturnsBadRequest(string extension)
    {
        // Arrange
        var mockFile = CreateMockFile($"test{extension}", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().Be("Invalid file type. Allowed: jpg, jpeg, png, gif, webp");
    }

    [Theory]
    [InlineData(".jpg")]
    [InlineData(".jpeg")]
    [InlineData(".png")]
    [InlineData(".gif")]
    [InlineData(".webp")]
    public async Task UploadImage_ValidFileExtension_ReturnsOk(string extension)
    {
        // Arrange
        var mockFile = CreateMockFile($"test{extension}", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task UploadImage_ValidFile_ReturnsUrlWithGuidFilename()
    {
        // Arrange
        var mockFile = CreateMockFile("test.png", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var response = okResult.Value;

        var urlProperty = response!.GetType().GetProperty("url");
        var url = urlProperty!.GetValue(response) as string;

        url.Should().StartWith("/uploads/");
        url.Should().EndWith(".png");

        // Extract GUID from filename
        var filename = Path.GetFileNameWithoutExtension(url!.Replace("/uploads/", ""));
        Guid.TryParse(filename, out _).Should().BeTrue();
    }

    [Fact]
    public async Task UploadImage_ValidFile_CreatesUploadsDirectory()
    {
        // Arrange
        var mockFile = CreateMockFile("test.jpg", 100);
        var uploadsPath = Path.Combine(_testWebRootPath, "uploads");

        // Act
        await _controller.UploadImage(mockFile);

        // Assert
        Directory.Exists(uploadsPath).Should().BeTrue();
    }

    [Fact]
    public async Task UploadImage_ValidFile_SavesFileToUploadsDirectory()
    {
        // Arrange
        var mockFile = CreateMockFile("test.png", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        var uploadsPath = Path.Combine(_testWebRootPath, "uploads");
        var files = Directory.GetFiles(uploadsPath);
        files.Should().HaveCount(1);
    }

    [Fact]
    public async Task UploadImage_CaseInsensitiveExtension_AcceptsUppercase()
    {
        // Arrange
        var mockFile = CreateMockFile("test.PNG", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task UploadImage_MixedCaseExtension_AcceptsFile()
    {
        // Arrange
        var mockFile = CreateMockFile("test.JpEg", 100);

        // Act
        var result = await _controller.UploadImage(mockFile);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task UploadImage_MultipleUploads_GeneratesUniqueFilenames()
    {
        // Arrange
        var mockFile1 = CreateMockFile("test1.png", 100);
        var mockFile2 = CreateMockFile("test2.png", 100);

        // Act
        var result1 = await _controller.UploadImage(mockFile1);
        var result2 = await _controller.UploadImage(mockFile2);

        // Assert
        var url1 = GetUrlFromResult(result1);
        var url2 = GetUrlFromResult(result2);

        url1.Should().NotBe(url2);
    }

    private static IFormFile CreateMockFile(string fileName, int length)
    {
        var content = new byte[length];
        var stream = new MemoryStream(content);

        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.FileName).Returns(fileName);
        mockFile.Setup(f => f.Length).Returns(length);
        mockFile.Setup(f => f.OpenReadStream()).Returns(stream);
        mockFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .Returns<Stream, CancellationToken>((target, _) =>
            {
                stream.Position = 0;
                return stream.CopyToAsync(target);
            });

        return mockFile.Object;
    }

    private static string GetUrlFromResult(ActionResult<string> result)
    {
        var okResult = (OkObjectResult)result.Result!;
        var urlProperty = okResult.Value!.GetType().GetProperty("url");
        return urlProperty!.GetValue(okResult.Value) as string ?? "";
    }

    #endregion
}
