using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        public class Customer
        {
            public string FN, LN;
            public int A;
        }
        static void Main(string[] args)
        {
            IEnumerable<Customer> customers = new[]
            {
                new Customer{FN = "SDF", LN = "FXDSD", A = 34},
                new Customer{FN = "GHH", LN = "VHTR", A = 54}
            };
            var customerLN = customers.Select(cust => cust.LN);
            foreach(string name in customerLN)
            {
                Console.WriteLine(name);
            }
            var customerNames = customers.Select(cust => new { FN = cust.FN, LN = cust.LN });
            foreach(var customer in customerNames)
            {
                Console.WriteLine("{0} {1}", customer.FN, customer.LN);
            }
            var customersGBAge = customers.GroupBy(cust =>
            {
                if (cust.A < 20) return "Age < 20";
                if (cust.A >= 20 && cust.A < 40) return "Age < 40 and >= 20";
                if (cust.A >= 40 && cust.A < 60) return "Age < 60 and >= 40";
                if (cust.A >= 60) return "Age >= 60";
                return "Error";
            });
            foreach(var cust in customersGBAge.OrderBy(cust => cust.Key))
            {
                Console.WriteLine("{0}\t\t{1}", cust.Key, cust.Count());
            }
            Console.ReadKey();
        }
    }
}
