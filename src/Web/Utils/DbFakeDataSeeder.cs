using System.Security.Claims;
using Bogus;
using Microsoft.AspNetCore.Identity;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Interfaces.Repositories;
using MovieCatalog.Infrastructure.Identity;

namespace MovieCatalog.Web.Utils;

public class DbFakeDataSeeder
{
    private readonly UserManager<UserIdentity> _userManager;
    private readonly IMovieCatalogRepository<User> _userRepository;
    private readonly IMovieCatalogRepository<Movie> _movieRepository;
    private readonly IImageRepository _imageRepository;
    private readonly string _fakeImagesPath;
    private readonly List<User> _fakeUsers = new()
    {
        new(Guid.NewGuid().ToString()),
        new(Guid.NewGuid().ToString())
    };

    public DbFakeDataSeeder(UserManager<UserIdentity> userManager,
        IMovieCatalogRepository<User> userRepository,
        IMovieCatalogRepository<Movie> movieRepository,
        IWebHostEnvironment environment, 
        IImageRepository imageRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _movieRepository = movieRepository;
        _imageRepository = imageRepository;
        
        _fakeImagesPath = environment.WebRootPath + "/fakeImages/";
    }

    public void Seed()
    {
        Console.WriteLine("Seed fake users...");
        SeedUsers();
        Console.WriteLine("Seed fake movies...");
        SeedMovies();
    }

    private void SeedUsers()
    {
        if (!_userRepository.AnyAsync().Result)
        {
            List<UserIdentity> fakeUserIdentities = new()
            {
                new()
                {
                    UserName = "admin",
                },
                new()
                {
                    UserName = "user"
                }
            };

            for (int i = 0; i < fakeUserIdentities.Count; i++)
            {
                fakeUserIdentities[i].Id = _fakeUsers[i].Id;
            }

            for (int i = 0; i < fakeUserIdentities.Count; i++)
            {
                _userRepository.AddAsync(_fakeUsers[i]).Wait();
                _userManager.CreateAsync(fakeUserIdentities[i], "P@ssword123").Wait();
                _userManager.AddClaimAsync(fakeUserIdentities[i], 
                    new Claim(ClaimTypes.NameIdentifier, fakeUserIdentities[i].Id)).Wait();
            }
        }
    }

    private void SeedMovies()
    {
        if (!_movieRepository.AnyAsync().Result)
        {
            var fakeFileNames = Directory.GetFiles(_fakeImagesPath);
            var faker = new Faker();
        
            for (int i = 0; i < 500; i++)
            {
                var user = _fakeUsers[Random.Shared.Next(0, _fakeUsers.Count - 1)];
                string fileName = fakeFileNames[Random.Shared.Next(0, fakeFileNames.Length)];
                
                var generatedFileName = 
                    Guid.NewGuid() + $"{Path.GetExtension(fileName)}";
                _imageRepository.SaveAsync(File.OpenRead(fileName), generatedFileName);
                
                Movie movie = new()
                {
                    Title = faker.Lorem.Sentence(2),
                    Description = faker.Lorem.Lines(5),
                    Director = faker.Lorem.Sentence(2),
                    ReleaseYear = faker.Random.Number(2000, 2022),
                    ImageName = generatedFileName,
                    User = user
                };

                _movieRepository.AddAsync(movie).Wait();
            }
        }
    }
}