using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {

                // Display menu
                //Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=============================");
                Console.WriteLine(" SMARTLIBRARY MAIN MENU");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Search Books");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. View My Account");
                Console.WriteLine("5. Exit");
                Console.WriteLine("6. Library Hours");
                Console.WriteLine("7. Contact Us");
                Console.WriteLine("=============================");
                Console.Write("Select an option (1-7): ");

                string choice = Console.ReadLine();               

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n[Search Books - Coming Soon!]");
                        break;

                    case "2":
                        Console.WriteLine("\n[Borrow Book - Coming Soon!]");
                        break;

                    case "3":
                        Console.WriteLine("\n[Return Book - Coming Soon!]");
                        break;

                    case "4":
                        Console.WriteLine("\n[View My Account - Coming Soon!]");
                        break;

                    case "5":
                        Console.WriteLine("\nThank you for using SmartLibrary!");
                        running = false;
                        break;

                    case "6":
                        Console.WriteLine("\n[View Library Hours - Coming Soon!]");
                        break;

                    case "7":
                        Console.WriteLine("\n[View Contact Us - Coming Soon!]");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice! Please enter 1-5.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...\n");
                    Console.ReadKey();
                }
            }

        }

    }

}
