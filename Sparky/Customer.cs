using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            //eturn firstName + " " + lastName;
            return $"Hello, {firstName} {lastName}";
        }
    }
}
