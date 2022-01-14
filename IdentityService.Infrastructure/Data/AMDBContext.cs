using IdentityService.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Models
{
    public class AMDBContext: DbContext
    {
        public AMDBContext(DbContextOptions<AMDBContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
