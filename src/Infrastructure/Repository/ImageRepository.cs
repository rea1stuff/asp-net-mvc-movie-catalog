using Microsoft.AspNetCore.Hosting;
using MovieCatalog.Application.Interfaces;

namespace MovieCatalog.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    private static string? _directory;
    private const string ImagesFolderName = "movieImages/";

    public ImageRepository(IWebHostEnvironment environment)
    {
        _directory ??= Path.Combine(environment.WebRootPath, ImagesFolderName);
        
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory!);
        }
    }
    
    public async Task SaveAsync(Stream file, string fileName)
    {
        await using var fileStream = 
            File.Create(_directory + fileName);
        
        await file.CopyToAsync(fileStream);
        await file.DisposeAsync();
    }

    public string GetRelativePath(string fileName)
    {
        return "~/" + ImagesFolderName + fileName;
    }

    public void Delete(string fileName)
    {
        File.Delete(_directory + fileName);
    }
}