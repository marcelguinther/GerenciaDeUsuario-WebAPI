using MacroControleFinanceiro.Domain.Models;
using MacroControleFinanceiro.Infra.Data.Map;
using System.Data.Entity;

namespace MacroControleFinanceiro.Infra.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("AppConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
