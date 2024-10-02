using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Sloving.Problems
{
    internal class StarPatten
    {
        private char _char = '*';
        public void PrintSqure()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= 4; j++)
                {
                    Console.Write(" " + _char);
                }
            }
        }

        public void PrintTriange()
        {
            int len = 9;
            for(int i = 1;i <= 5;i++)
            {
                Console.WriteLine();
                for(int j = 1; j <= len; j++)
                {                     
                    if (j%2 == 1)
                    {
                        Console.Write(_char);
                    }
                }
            }
        }
    }
}

//    *   
//   ***
//  *****
// *******
//*********

