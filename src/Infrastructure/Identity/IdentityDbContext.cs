using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieCatalog.Infrastructure.Identity;

public class IdentityDbContext : IdentityDbContext<UserIdentity>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
        
    }
}