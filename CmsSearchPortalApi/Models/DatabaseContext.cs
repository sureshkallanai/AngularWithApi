using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Models
{
    public partial class DatabaseContext : DbContext
    {        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }       
        public DbSet<Login>? Login { get; set; }
    }
}
