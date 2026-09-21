using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Name
             * Age
             * Phone Number
             */

            //string name = "John Doe";
            //int age = 20;
            //string phoneNumber = "0935353535";
            //const string STUDENT_ID = "GCD123456";

            /* Example 2 */

            //Console.WriteLine("Enter a value");
            //string userInput = Console.ReadLine(); // userInput <- "5" 

            //int userInputInt = int.Parse(userInput); // "5" -> 5

            // Option 1
            //if (userInputInt > 0) // check condition
            //{
            //    Console.WriteLine("It's a positive number.");
            //} 
            //else
            //{
            //    Console.WriteLine("It's a negative number.");
            //}

            // Option 2
            //bool flag = userInputInt > 0; // prepare condition

            //if (flag == true) // check condition
            //{
            //    Console.WriteLine("It's a positive number.");
            //}
            //else
            //{
            //    Console.WriteLine("It's a negative number.");
            //}

            /* Example 3 - FOR loop */

            //Console.WriteLine("Counting from 1 to 10");

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"i = {i+1}");
            //}

            //Console.WriteLine(i); // < error


            /* Example 4 - ARRAY */

            // Option 1 
            //string[] fruits = { "apple", "banana", "mango" };

            ////fruits[1] = "lychee";

            ////Console.WriteLine($"My favorite fruit is {fruits[1]}");

            //// TODO: Please print out all items in the fruits

            //for (int i = 0; i < fruits.Length; i++)
            //{
            //    Console.WriteLine(fruits[i]);
            //}

            // Option 2
            //string[] fruits = new string[5];
            ////Console.WriteLine(fruits.Length); // 5

            //fruits[0] = "apple";
            //fruits[1] = "banana";
            //fruits[2] = "mango";

            //for (int i = 0; i < fruits.Length; i++)
            //{
            //    Console.WriteLine(fruits[i]);
            //}

            /* Example 5 - LIST */

            List<string> fruits = new List<string>();

            fruits.Add("apple");
            fruits.Add("banana");
            fruits.Add("mango");

            Console.WriteLine("The current list of favorite fruits: ");

            showAllFruits(fruits);

            // TODO: Ask user for their favorite fruits and add to fruits
            // When user stops adding a new fruit, print out all fruits 

            Console.WriteLine("Please add more favorite fruits to the list (or blank to exit): ");

            string userInput = "";

            while (true)
            {
                userInput = Console.ReadLine();
                
                if (userInput == "")
                {
                    break;
                }

                fruits.Add(userInput);
            }

            Console.WriteLine("Here is your udpated list of favorite fruits: ");

            showAllFruits(fruits);

        }

        public static void showAllFruits(List<string> fruits)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine($"{i}. {fruits[i]}");
            }
        }
    }
}
