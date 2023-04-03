using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using net_kata.Models;

namespace net_kata.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HuespedHabitacion>().HasKey(x => new { x.HabitacionId, x.HuespedId });
            base.OnModelCreating(modelBuilder);

            ModelConfiguration(modelBuilder);
        }

        private void ModelConfiguration(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Huesped> Huesped { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<HuespedHabitacion> HuespedHabitacion { get; set; }
    }
}