using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {

           
            string line = string.Empty;
            
            while (!line.Equals("exit".ToLower()))
            {
                if (line.Equals("exit".ToLower()))
                    break;
                Console.Write("Enter Line: ");
                line = Console.ReadLine();

            }
            
        }

    }
}
