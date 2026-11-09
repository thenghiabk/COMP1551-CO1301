using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class ConsoleView : ILibraryView
    {
        private LibraryManager manager;

        public ConsoleView(LibraryManager manager)
        {
            this.manager = manager;
        }

        // Main menu loop
        public void Run()
        {
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║    SMARTLIBRARY MANAGEMENT SYSTEM     ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.WriteLine();

            bool running = true;

            while (running)
            {
                DisplayMenu();

                string choice = GetInput("Enter your choice (0-9): ");


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
                    Console.WriteLine("\n⚠ Invalid choice!");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Add book menu
        private void AddBook()
        {
            Console.WriteLine("\n=== ADD NEW BOOK ===");

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Publication Year: ");
            string yearInput = Console.ReadLine();
            int year;

            if (!int.TryParse(yearInput, out year))
            {
                Console.WriteLine("\n⚠ Invalid year format!");
                return;
            }

            Console.Write("Publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Pages: ");
            string pagesInput = Console.ReadLine();
            int pages;

            if (!int.TryParse(pagesInput, out pages))
            {
                Console.WriteLine("\n⚠ Invalid page count!");
                return;
            }

            Console.Write("Genre: ");
            string genre = Console.ReadLine();

            string result = manager.AddBook(isbn, title, author, year, publisher, pages, genre);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
            }
        }

        // Add ebook menu
        private void AddEBook()
        {
            Console.WriteLine("\n=== ADD NEW E-BOOK ===");

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Publication Year: ");
            string yearInput = Console.ReadLine();
            int year;

            if (!int.TryParse(yearInput, out year))
            {
                Console.WriteLine("\n⚠ Invalid year format!");
                return;
            }

            Console.Write("Download URL: ");
            string url = Console.ReadLine();

            Console.Write("Format (PDF/EPUB/MOBI): ");
            string format = Console.ReadLine();

            Console.Write("File Size (MB): ");
            string sizeInput = Console.ReadLine();
            double fileSize;

            if (!double.TryParse(sizeInput, out fileSize))
            {
                Console.WriteLine("\n⚠ Invalid file size!");
                return;
            }

            string result = manager.AddEBook(isbn, title, author, year, url, format, fileSize);

            Console.WriteLine();
            if (result.StartsWith("SUCCESS"))
            {
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
            }
        }

        // View all items menu
        private void ViewAllItems()
        {
            Console.WriteLine("\n=== ALL LIBRARY ITEMS ===");

            List<LibraryItem> items = manager.GetAllItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No items in library.");
                return;
            }

            Console.WriteLine("Total items: " + items.Count);
            Console.WriteLine();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("--- Item #" + (i + 1) + " ---");
                items[i].DisplayInfo();
                Console.WriteLine();
            }
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
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
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
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
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
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
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
                Console.WriteLine("✓ " + result.Substring(9));
            }
            else
            {
                Console.WriteLine("⚠ " + result.Substring(7));
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

        public void DisplayMenu()
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
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine("\nOK: " + message);
        }

        public void ShowError(string message)
        {
            Console.WriteLine("\nError: " + message);
        }

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        public void DisplayItems(List<LibraryItem> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("\nNo items found.");
                return;
            }

            Console.WriteLine("\nTotal items: " + items.Count);
            Console.WriteLine();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("--- Item #" + (i + 1) + " ---");
                items[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        public void DisplayStatistics(int total, int available, int borrowed)
        {
            Console.WriteLine("\n=== LIBRARY STATISTICS ===");
            Console.WriteLine("Total Items: " + total);
            Console.WriteLine("Available: " + available);
            Console.WriteLine("Borrowed: " + borrowed);
        }
    }
}
