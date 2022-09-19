using AdminApi.Models;
using Microsoft.EntityFrameworkCore;
namespace AdminApi
{
    public class DbAdminContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<MemberDetails> MemberDetails { get; set; }
        public DbSet<ClaimDetails> ClaimDetails { get; set; }
        public DbSet<StateDetails> stateDetails { get; set; }
        public DbSet<UserTypes> userTypes { get; set; }
        public DbSet<MemberList> MemberList { get; set; }
        public DbSet<PhysicianDetails> PhysicianDetails { get; set; }
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
            modelBuilder.Entity<MemberDetails>().ToTable("tbl_Members");
            modelBuilder.Entity<ClaimDetails>().ToTable("tbl_Claims");
            modelBuilder.Entity<StateDetails>().ToTable("state_list");
            modelBuilder.Entity<UserTypes>().ToTable("tbl_UsersMaster");
            modelBuilder.Entity<PhysicianDetails>().ToTable("tbl_Physicians");
        }
    }
}
