# customerapp-entityframework
 Customer app with entity framework in .net framework 4.7.2

Step by step tutorials creating Entity framework 6

## Table of Contents

- [Sending Feedback](#sending-feedback)
- [About Entity Framework Core](#about-entity-framework-core)
- [Sample application with each labs](#sample-application-with-each-steps)
    - Creating Entity Framework Core
        - [Step 1 - Create Application](#step-1---create-application)
    - Controlling database creation and Schema changes
        - [Step 2 - Adding EntityFramework via Nuget ](#step-2---adding-entityframework-via-nuget)
        - [Step 3 - Create Console App](#step-3---adding-migration)
        - [Step 4 - Adding migration](#step-4---adding-migration)
        - [Step 5 - Script migration for production DB](#step-5---script-migration-for-production-db)
        - [Step 6 - Reverse engineering from existing database](#step-6---reverse-engineering-from-existing-database)
    - Mapping many to mmany and one to one relationship
        - [Step 7 - Many to many relationship](#step-7---many-to-many-relationship)
        - [Step 8 - One to one relationship](#step-8---one-to-one-relationship)
        - [Step 9 - Visualising how EF Core model looks](#step-9---visualising-how-ef-core-model-looks)
        - [Step 10 - Running Migration for Model changes](#step-10---running-migration-for-model-changes)
    - Interacting with EF Core data model
        - [Step 11 - Adding logging to EF Core's](#step-11---adding-logging-to-ef-cores)
        - [Step 12 - For bulk operations](#step-12---for-bulk-operations)
        - [Step 13 - Understading queries](#step-13---understading-queries)
        - [Step 14 - Aggregating in Queries](#step-14---aggregating-in-queries)
        - [Step 15 - Updating object](#step-15---updating-object)
        - [Step 16 - Deleting object](#step-16---deleting-object)
     

## Sending Feedback

For feedback can drop mail to my email address amit.naik8103@gmail.com or you can create [issue](https://github.com/Amitpnk/angular-application/issues/new)

## About Entity Framework 

* EF Core is an ORM (Object Relation Mapper)
* Microsoft's official data access technology for .NET development

### Benefits of EF Core
 * Developer productivity
 * Coding consistency

## Sample application with each steps

### Step 1 - Create Application

* Create Blank solution EFCoreCustomer
* Class library .NET Standard
    * EFCoreCustomer.Domain
    * EFCoreCustomer.Data 

### Step 2 - Adding Nuget package manager

* Install EntityFrameworko <b>EFCoreCustomer.Data</b> Class library <br/>
and Add class in <b>EFCoreCustomer.Domain</b>

```C#
public class Customer
{
    public Customer()
    {
        Address = new List<Address>();
    }
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<Address> Address { get; set; }

}

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string PinCode { get; set; }

}
```

### Step 3 - Adding migration
 
* In Package Manager console run below command, under <b>EFCoreCustomer.Data</b>
    * enable-migrations (this will create configuration)
    * Add-Migration init
    * Update-Database

### Step 4 - Adding migration
 
Add CustomerContext.cs in <b>EFCoreCustomer.Data</b>

```C#
public class CustomerContext : DbContext
{
    public CustomerContext() : base("Data Source=(local)\\SQLexpress;Initial Catalog=CustomerEFCORE;Integrated Security=True")
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerContext, Configuration>());
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
```

Use EF Core Power Tool Extension for VS 2019

### Step 5 - Create Console App 

Create console app and make it as default project

```C#
class Program
{
    static CustomerContext context = new CustomerContext();

    static void Main(string[] args)
    {
        GetCustomer("Before Add: ");
        AddCustomer();
        GetCustomer("After Add: ");
        Console.ReadKey();
    }

    private static void GetCustomer(string text)
    {
        // Get all data from Customer table
        var customers = context.Customers.ToList();

        Console.WriteLine($"{text}: Customer Count is {customers.Count}");

        foreach (var customer in customers)
        {
            Console.WriteLine(customer.CustomerName);
        }
    }

    private static void AddCustomer()
    {
        // For inserting to Customer table
        var customer = new Customer { CustomerName = "Swetha" };
        var address = new Address { Street = "Bangalore", PinCode = "560091" };
        context.Customers.Add(customer);
        customer.Address.Add(address);
        context.SaveChanges();
    }

}

```
   
### Step 6 - Visualising how EF Core model looks

* Install DGML editor in VS 2019 setup file (available in individual components)
* Install EF Core Power Tools via Extension
* Make multi target to netcoreapp3.1,netstandard2.0
* Add Microsoft.EntityFrameworkCore.Design lib via nuget package manager
* Create *.dgml file by right click on EFCoreCustomer.Data > EF Core Power Tools > Add DbContext Model diagram
 
