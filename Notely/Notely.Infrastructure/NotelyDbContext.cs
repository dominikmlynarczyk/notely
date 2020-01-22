using Microsoft.EntityFrameworkCore;
using Notely.Infrastructure.Notes;
using Notely.Infrastructure.Users;

namespace Notely.Infrastructure
{
    public class NotelyDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        public NotelyDbContext(DbContextOptions<NotelyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
