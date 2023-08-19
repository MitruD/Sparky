using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int Discount = 15;

        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            //eturn firstName + " " + lastName;
            return GreetMessage;
        }

        public CustomerType GetCustomerdetails() 
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            else
            {
                return new PremiumCustomer();
            }
        }
    }

    public class CustomerType{ }
    public class BasicCustomer:CustomerType { }
    public class PremiumCustomer:CustomerType { }
}
