using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Sloving.Problems
{
    internal class Palindrome
    {
        string name = string.Empty;
        string reverseName = string.Empty;

        public Palindrome()
        {
            Console.WriteLine("Enter the Name : ");
            name = Console.ReadLine();
        }

        public void Palindrom_In_ForLoop()
        { 
            for (int i = name.Length-1; i >= 0; i--)
            {
                reverseName = reverseName+name[i];
            }
            Console.WriteLine("The reversed Name is : " + reverseName);

            if(reverseName == name)
            {
                Console.WriteLine("Given name is a Palindrom...");
            }
            else
            {
                Console.WriteLine("Given name is Not Palindrom...");
            }
        }

        public void Palindrom_In_ForEach()
        {
            foreach (char c in name.Reverse())
            {
                reverseName = reverseName + c;
            }
            Console.WriteLine("The reversed Name is : " + reverseName);
            if (reverseName == name)
            {
                Console.WriteLine("Given name is a Palindrom...");
            }
            else
            {
                Console.WriteLine("Given name is Not Palindrom...");
            }
        }

        public void Palindrom_In_While()
        {
            try
            {
                int i = 0;
                while (name[i] != null)
                {
                    reverseName = name[i] + reverseName;
                    i++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The reversed Name is : " + reverseName);
                if (reverseName == name)
                {
                    Console.WriteLine("Given name is a Palindrom...");
                }
                else
                {
                    Console.WriteLine("Given name is Not Palindrom...");
                }
            }
           
        }

        public void Palindrom_In_DoWhile()
        {
            try
            {
                int i = 0;
                do
                {
                    reverseName = name[i] + reverseName;
                    i++;
                }
                while (name[i] != null);
            }
            catch (Exception)
            {
                Console.WriteLine("The reversed Name is : " + reverseName);
                if (reverseName == name)
                {
                    Console.WriteLine("Given name is a Palindrom...");
                }
                else
                {
                    Console.WriteLine("Given name is Not Palindrom...");
                }
            }

        }
    }
}
