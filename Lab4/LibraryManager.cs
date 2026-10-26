using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class LibraryManager
    {
        private LibraryRepository repository;

        public LibraryManager(LibraryRepository repository)
        {
            this.repository = repository;
        }

        // Add a new book
        public string AddBook(string isbn, string title, string author, int year,
                              string publisher, int pages, string genre)
        {
            // Business validation
            // Validation 1: Check if title is empty
            // If empty, return "ERROR: Title cannot be empty"

            // Validation 2: Check if author is empty
            // If empty, return "ERROR: Author cannot be empty"

            // Validation 3: Check if isbn is empty
            // If empty, return "ERROR: ISBN cannot be empty"

            // Validation 4: Check if year is valid (between 1000 and current year)
            // HINT: Use DateTime.Now.Year for current year
            // If invalid, return "ERROR: Invalid publication year"

            // Validation 5: Check if pages is positive
            // If not, return "ERROR: Page count must be positive"

            // Business Rule: Check for duplicate ISBN using repository.ISBNExists()
            // If exists, return "ERROR: Book with this ISBN already exists!"

            // Create a new Book object with the parameters
            // HINT: Pass empty string "" for itemId (will be auto-generated)

            // Add the book to repository

            return "SUCCESS: Book '" + title + "' added successfully with ID: ??" ;
        }

        // Add a new ebook
        public string AddEBook(string isbn, string title, string author, int year,
                               string downloadUrl, string format, double fileSize)
        {
            // Business validation
            // Similar validation to AddBook:
            // - Check title, author, isbn not empty
            // - Check downloadUrl not empty
            // - Check fileSize is positive

            // Additional validation: Check format is valid (PDF, EPUB, MOBI, AZW3)
            // HINT: Create an array of valid formats and check if format matches

            // Check for duplicate ISBN

            // Create new EBook object

            // Add to repository

            return "SUCCESS: E-Book '" + title + "' added successfully with ID: ??" ;
        }

        // Get all items
        public List<LibraryItem> GetAllItems()
        {
            return repository.GetAll();
        }

        // Get item by ID
        public LibraryItem GetItemByID(string itemId)
        {
            return repository.FindByID(itemId);
        }

        // Search items
        public List<LibraryItem> SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<LibraryItem>();
            }

            return repository.Search(searchTerm);
        }

        // Delete item
        public string DeleteItem(string itemId)
        {
            LibraryItem item = repository.FindByID(itemId);

            if (item == null)
            {
                return "ERROR: Item not found!";
            }

            // Business rule: Cannot delete borrowed items
            if (!item.IsAvailable)
            {
                return "ERROR: Cannot delete borrowed item! Please return it first.";
            }

            repository.Delete(itemId);
            return "SUCCESS: Item '" + item.Title + "' deleted successfully!";
        }

        // Borrow item
        public string BorrowItem(string itemId)
        {
            // Find the item using repository.FindByID()

            // If item is null, return error

            // If item is not available, return error

            // Call item.Borrow() method

            // Return success message with category and title

            return "";
        }

        // Return item
        public string ReturnItem(string itemId)
        {
            // Find the item

            // If item is null, return error

            // If item is available (not borrowed), return error

            // Get days overdue using item.GetDaysOverdue()
            // Get late fee using item.GetCurrentLateFee()

            // Call item.Return() method

            // If overdue, return success message with fee info
            // Otherwise, return simple success message

            return "";
        }

        // Renew item
        public string RenewItem(string itemId)
        {
            LibraryItem item = repository.FindByID(itemId);

            if (item == null)
            {
                return "ERROR: Item not found!";
            }

            if (item.IsAvailable)
            {
                return "ERROR: Item is not currently borrowed!";
            }

            if (!item.CanBeRenewed())
            {
                return "ERROR: " + item.GetCategory() + " items cannot be renewed!";
            }

            if (item.GetDaysOverdue() > 0)
            {
                return "ERROR: Cannot renew overdue items!";
            }

            // Renew by resetting borrow date
            item.BorrowedDate = DateTime.Now;

            return "SUCCESS: Item renewed! New due date: " + item.GetDueDate().ToString("yyyy-MM-dd");
        }

        // Get statistics
        public void GetStatistics(out int total, out int books, out int ebooks,
                                  out int available, out int borrowed, out int overdue,
                                  out int oldest, out int newest)
        {
            total = repository.GetCount();
            books = repository.GetBookCount();
            ebooks = repository.GetEBookCount();
            available = repository.GetAvailableCount();
            borrowed = repository.GetBorrowedCount();
            overdue = repository.GetOverdueItems().Count;
            oldest = repository.GetOldestYear();
            newest = repository.GetNewestYear();
        }

        // Add sample items
        public void AddSampleItems()
        {
            Book book1 = new Book("", "978-0132350884", "Clean Code", "Robert Martin",
                                  2008, "Prentice Hall", 464, "Programming");
            repository.Add(book1);

            Book book2 = new Book("", "978-0547928227", "The Hobbit", "J.R.R. Tolkien",
                                  1937, "Houghton Mifflin", 310, "Fantasy");
            repository.Add(book2);

            Book book3 = new Book("", "978-0451524935", "1984", "George Orwell",
                                  1949, "Signet Classic", 328, "Dystopian");
            repository.Add(book3);

            //EBook ebook1 = new EBook("", "978-1449355739", "Learning Python", "Mark Lutz",
            //                         2013, "https://example.com/python.pdf", "PDF", 3.5);
            //repository.Add(ebook1);
        }
    }
}
