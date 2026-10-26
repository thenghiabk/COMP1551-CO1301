using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class LibraryUI
    {
        private LibraryManager manager;

        public LibraryUI(LibraryManager manager)
        {
            this.manager = manager;
        }

        // Main menu loop
        public void Run()
        {
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║    SMARTLIBRARY MANAGEMENT SYSTEM     ║");
            Console.WriteLine("║      (Using 3 Tier Architecutre)      ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.WriteLine();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Add New E-Book");
                Console.WriteLine("3. View All Items");
                Console.WriteLine("4. Search Items");
                Console.WriteLine("5. Borrow Item");
                Console.WriteLine("6. Return Item");
                Console.WriteLine("7. Renew Item");
                Console.WriteLine("8. Delete Item");
                Console.WriteLine("9. Statistics");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice (0-9): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddBook();
                }
                else if (choice == "2")
                {
                    AddEBook();
                }
                else if (choice == "3")
                {
                    ViewAllItems();
                }
                else if (choice == "4")
                {
                    SearchItems();
                }
                else if (choice == "5")
                {
                    BorrowItem();
                }
                else if (choice == "6")
                {
                    ReturnItem();
                }
                else if (choice == "7")
                {
                    RenewItem();
                }
                else if (choice == "8")
                {
                    DeleteItem();
                }
                else if (choice == "9")
                {
                    ShowStatistics();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("\nThank you for using SmartLibrary!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("\n Invalid choice!");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Add book menu
        private void AddBook()
        {
            Console.WriteLine("\n=== ADD NEW BOOK ===");

            // Prompt and read ISBN
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            // TODO: Prompt and read Title

            // TODO: Prompt and read Author

            // TODO: Prompt and read Publication Year
            // HINT: Use int.TryParse() to validate

            // TODO: Prompt and read Publisher

            // TODO: Prompt and read Pages
            // HINT: Use int.TryParse() to validate

            // TODO: Prompt and read Genre

            // Call manager.AddBook() with all parameters
            //string result = manager.AddBook(isbn, title, author, year, publisher, pages, genre);

            // Display result
            // If starts with "SUCCESS", show success message
            // If starts with "ERROR", show with error message
        }

        // Add ebook menu
        private void AddEBook()
        {
            Console.WriteLine("\n=== ADD NEW E-BOOK ===");

            // Prompt and read ISBN
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            // TODO: Prompt and read Title

            // TODO: Prompt and read Author

            // TODO: Prompt and read Pages
            // HINT: Use int.TryParse() to validate

            // TODO: Prompt and read Download URL

            // TODO: Prompt and read Format (PDF/EPUB/MOBI)

            // TODO: Prompt and read File Size (MB)

            // Call manager.AddEBook() with all parameters
            //string result = manager.AddEBook(isbn, title, author, year, url, format, fileSize);

            // Display result
            // If starts with "SUCCESS", show success message
            // If starts with "ERROR", show with error message
        }

        // View all items menu
        private void ViewAllItems()
        {
            Console.WriteLine("\n=== ALL LIBRARY ITEMS ===");

            // Get all items from manager
            List<LibraryItem> items = manager.GetAllItems();

            // If count is 0, display "No items in library"

            // Display total count

            // Use for loop to iterate through items
            // For each item, display item number
            // Call item.DisplayInfo() - notice polymorphism!
            // Display blank line between items

        }

        // Search items menu
        private void SearchItems()
        {
            Console.WriteLine("\n=== SEARCH ITEMS ===");
            Console.Write("Enter search term (title or author): ");
            string searchTerm = Console.ReadLine();

            List<LibraryItem> results = manager.SearchItems(searchTerm);

            if (results.Count == 0)
            {
                Console.WriteLine("\nNo items found.");
                return;
            }

            Console.WriteLine("\nFound " + results.Count + " item(s):");
            Console.WriteLine();

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine("--- Result #" + (i + 1) + " ---");
                results[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        // Borrow item menu
        private void BorrowItem()
        {
            Console.WriteLine("\n=== BORROW ITEM ===");
            Console.Write("Enter Item ID: ");
            string itemId = Console.ReadLine();

            string result = manager.BorrowItem(itemId);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine(" " + result.Substring(9));
            }
            else
            {
                Console.WriteLine(" " + result.Substring(7));
            }
        }

        // Return item menu
        private void ReturnItem()
        {
            Console.WriteLine("\n=== RETURN ITEM ===");
            Console.Write("Enter Item ID: ");
            string itemId = Console.ReadLine();

            string result = manager.ReturnItem(itemId);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine(" " + result.Substring(9));
            }
            else
            {
                Console.WriteLine(" " + result.Substring(7));
            }
        }

        // Renew item menu
        private void RenewItem()
        {
            Console.WriteLine("\n=== RENEW ITEM ===");
            Console.Write("Enter Item ID: ");
            string itemId = Console.ReadLine();

            string result = manager.RenewItem(itemId);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine(" " + result.Substring(9));
            }
            else
            {
                Console.WriteLine(" " + result.Substring(7));
            }
        }

        // Delete item menu
        private void DeleteItem()
        {
            Console.WriteLine("\n=== DELETE ITEM ===");
            Console.Write("Enter Item ID to delete: ");
            string itemId = Console.ReadLine();

            string result = manager.DeleteItem(itemId);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine(" " + result.Substring(9));
            }
            else
            {
                Console.WriteLine(" " + result.Substring(7));
            }
        }

        // Show statistics menu
        private void ShowStatistics()
        {
            Console.WriteLine("\n=== LIBRARY STATISTICS ===");

            int total, books, ebooks, available, borrowed, overdue, oldest, newest;
            manager.GetStatistics(out total, out books, out ebooks, out available,
                                 out borrowed, out overdue, out oldest, out newest);

            Console.WriteLine("Total Items: " + total);
            Console.WriteLine("Books: " + books);
            Console.WriteLine("E-Books: " + ebooks);
            Console.WriteLine("Available: " + available);
            Console.WriteLine("Borrowed: " + borrowed);
            Console.WriteLine("Overdue: " + overdue);

            if (total > 0)
            {
                Console.WriteLine("Oldest: " + oldest);
                Console.WriteLine("Newest: " + newest);
            }
        }
    }
}
