using CustomerEF.Data.Migrations;
using CustomerEF.Domain;
using System.Data.Entity;

namespace CustomerEF.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("Data Source=(local)\\SQLexpress;Initial Catalog=CustomerEFCORE;Integrated Security=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerContext, Configuration>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }




}
