using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Multishop.DiscountApi.Entities;
using System.Data;

namespace Multishop.DiscountApi.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DEVELOPER-TOGO\SQLEXPRESS;initial Catalog=MultishopDiscountDb;integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
