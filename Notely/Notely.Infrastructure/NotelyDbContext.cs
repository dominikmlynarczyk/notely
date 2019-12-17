using Microsoft.EntityFrameworkCore;
using Notely.Infrastructure.Users;

namespace Notely.Infrastructure
{
    public class NotelyDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Notely.db");
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
