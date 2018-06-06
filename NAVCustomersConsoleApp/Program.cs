using Microsoft.OData;
using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVCustomersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NAV nav = new NAV(new Uri("http://localhost:7048/DynamicsNAV100/ODataV4/Company('CRONUS%20CZ%20s.r.o.')"));
            nav.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;            

            var customers = nav.Customer.Select(c => new { c.Name, c.No});
            var customersCount = nav.Customer.Count();

            foreach (var cust in customers)
            {
                Console.WriteLine("\tCustomer ID: {0}, Name: {1}", cust.No, cust.Name);
            }
            Console.WriteLine("There are a total of {0} customers.", customersCount);        

            Console.ReadKey();
        }

    }
}
