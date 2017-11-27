using CustomerInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInformation.Infrastructure
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>();
             //.Map(m =>
             // {
             //     m.MapInheritedProperties();
             //     m.ToTable("Profile");
             // });

            modelBuilder.Entity<Individual>();
            modelBuilder.Entity<ProfileKey>();
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileKey> ProfileKeys { get; set; }
    }
}
