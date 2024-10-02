using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_Sloving.Problems
{
    internal class RegexValidation
    {
        public void EMail_Validation()
        {
            Console.WriteLine("Enter the E-Mail id : ");
            string email = Console.ReadLine();

            //string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                Console.WriteLine(email + " E-Mail id is invaild... ");
                return;
            }
            Console.WriteLine(email + " E-Mail id is vaild... ");
            Console.ReadLine();
        }
    }
}
