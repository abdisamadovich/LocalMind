using LocalMind.Server.Models.UserAdditionalDetails;
using LocalMind.Server.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocalMind.Server.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAdditionalDetail> userAdditionalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}