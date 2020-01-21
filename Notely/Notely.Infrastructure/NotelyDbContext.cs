using Microsoft.EntityFrameworkCore;
using Notely.Infrastructure.Users;

namespace Notely.Infrastructure
{
    public class NotelyDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public NotelyDbContext(DbContextOptions<NotelyDbContext> options) : base(options)
        {
        }
        //
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite($"Filename=Notely.db");
        //     base.OnConfiguring(optionsBuilder);
        // }
        
    }
}
