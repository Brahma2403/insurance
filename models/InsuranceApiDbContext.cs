using insuranceWebApi.models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;

namespace insuranceWebApi.models
{
    public class InsuranceApiDbContext : DbContext
    {
        public InsuranceApiDbContext(DbContextOptions<InsuranceApiDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PremiumCalculation> Calculations { get; set; }
    }
}
