namespace MovieCatalog.Application.Interfaces;

public interface IImageRepository
{
    public Task SaveAsync(Stream file, string fileName);
    public string GetRelativePath(string fileName);
    public void Delete(string fileName);
}