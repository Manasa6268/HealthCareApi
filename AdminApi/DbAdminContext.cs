using AdminApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdminApi
{
    public class DbAdminContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<MemberDetails> MemberDetails { get; set; }
        public DbSet<ClaimDetails> ClaimDetails { get; set; }

        public DbSet<MemberList> MemberList { get; set; }
        public DbAdminContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>().ToTable("tbl_Users");
            modelBuilder.Entity<MemberDetails>().ToTable("tbl_Members");
            modelBuilder.Entity<ClaimDetails>().ToTable("tbl_Claims");
        }
    }
    
}
