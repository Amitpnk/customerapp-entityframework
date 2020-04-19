# customerapp-entityframework
 Customer app with entity framework in .net framework 4.7.2

Step by step tutorials creating Entity framework 6

## Table of Contents

- [Sending Feedback](#sending-feedback)
- [About Entity Framework Core](#about-entity-framework-core)
- [Sample application with each labs](#sample-application-with-each-steps)
    - [Step 1 - Create Application](#step-1---create-application)
    - [Step 2 - Adding EntityFramework via Nuget ](#step-2---adding-nuget-package-manager)
    - [Step 3 - Adding DbContext file](#step-3---adding-dbcontext-file)
    - [Step 4 - Adding migration](#step-4---adding-migration)
    - [Step 5 - Create Console App](#step-5---create-console-app)
    - [Step 6 - Visualising how EF Core model looks](#step-6---visualising-how-ef-core-model-looks)
   
     
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

### Step 3 - Adding DbContext file
 
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

### Step 4 - Adding migration
 
* In Package Manager console run below command, under <b>EFCoreCustomer.Data</b>
    * enable-migrations (this will create configuration)
    * Add-Migration init
    * Update-Database

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
 
