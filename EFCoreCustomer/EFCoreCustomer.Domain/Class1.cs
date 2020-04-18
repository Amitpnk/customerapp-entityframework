using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCustomer.Domain
{
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


}
