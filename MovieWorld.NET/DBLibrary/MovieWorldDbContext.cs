using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Abstracts;
using Model.Models;

namespace DBLibrary
{
    public class MovieWorldDbContext : IdentityDbContext
    {
        private static IConfigurationRoot? _configuration = null;
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<CastType> CastType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<User> User { get; set; }
        public MovieWorldDbContext()
        {

        }
        public MovieWorldDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings2.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("MovieWorld");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {
                    var referenceEntity = entry.Entity as FullAuditModel;
                    switch (entry.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            break;
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            //}
                            break;
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}