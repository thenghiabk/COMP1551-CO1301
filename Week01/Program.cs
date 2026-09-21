using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP1551_CO1301
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /************** 
             * Example 1
             **************/
            /*Console.WriteLine("Hello World!");
            Console.WriteLine("Enter a number: ");
            string userInputString = Console.ReadLine();
            int userInputInt = int.Parse(userInputString);
            Console.WriteLine(SquareRoot(userInputInt));*/

            /************** 
             * Example 2 
             **************/

            Console.WriteLine("What's your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine("How old are you? ");
            int userAge = int.Parse(Console.ReadLine()); // convert a string to int

            int currentYear = DateTime.Now.Year; // get the current year

            int birthYear = currentYear - userAge;

            Console.WriteLine("Hello " + userName + ". I guess you were born in " + birthYear + ".");

            Console.WriteLine($"Hello {userName}. I guess you were born in {birthYear}.");

        }

        static double SquareRoot(double r)
        {
            double result = Math.Sqrt(r);

            return result;
        }
    }
}
