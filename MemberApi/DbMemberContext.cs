using MemberApi.Models;
using Microsoft.EntityFrameworkCore;
namespace MemberApi
{
    public class DbMemberContext :DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<MemberDetails> MemberDetails { get; set; }
        public DbSet<ClaimDetails> ClaimDetails { get; set; }
        public DbMemberContext(IConfiguration configuration)
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
            modelBuilder.Entity<MemberDetails>().ToTable("tbl_Members");
            modelBuilder.Entity<ClaimDetails>().ToTable("tbl_Claims");
        }
    }
}
