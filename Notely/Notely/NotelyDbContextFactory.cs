using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Notely.Infrastructure;
using ConfigurationBuilder = System.Configuration.ConfigurationBuilder;

namespace Notely
{
    public class NotelyDbContextFactory : IDesignTimeDbContextFactory<NotelyDbContext>
    {
        public NotelyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotelyDbContext>();
            var config = ConfigurationManager.OpenExeConfiguration(Environment.CurrentDirectory + @"\bin\Debug\Notely.exe");
            var conn = config.ConnectionStrings;
            optionsBuilder.UseSqlite(conn.ConnectionStrings["ConnectionString"].ConnectionString);

            return new NotelyDbContext(optionsBuilder.Options);
        }
    }
}