using CustomerEF.Data;
using CustomerEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
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

            Console.WriteLine($"{text}: Military Count is {customers.Count}");

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
}
