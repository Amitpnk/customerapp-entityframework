using EFCoreCustomer.Data.Migrations;
using EFCoreCustomer.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCustomer.Data
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
