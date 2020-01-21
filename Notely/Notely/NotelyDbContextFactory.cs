using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Notely.Infrastructure;

namespace Notely
{
    public class NotelyDbContextFactory : IDesignTimeDbContextFactory<NotelyDbContext>
    {
        public NotelyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotelyDbContext>();
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            return new NotelyDbContext(optionsBuilder.Options);
        }
    }
}