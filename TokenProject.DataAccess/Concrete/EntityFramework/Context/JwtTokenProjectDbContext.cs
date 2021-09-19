using Microsoft.EntityFrameworkCore;
using TokenProject.Core.Entities.Concrete;

namespace TokenProject.DataAccess.Concrete.EntityFramework.Context
{
    public class JwtTokenProjectDbContext : DbContext
    {
        public JwtTokenProjectDbContext()
        {
        }

        public JwtTokenProjectDbContext(DbContextOptions<JwtTokenProjectDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
