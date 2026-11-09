using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class LibraryManager
    {
        private ILibraryRepository repository;

        public LibraryManager(ILibraryRepository repository)
        {
            this.repository = repository;
        }

        // Add a new book
        public string AddBook(string isbn, string title, string author, int year,
                              string publisher, int pages, string genre)
        {
            // Business validation
            if (string.IsNullOrWhiteSpace(title))
            {
                return "ERROR: Title cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                return "ERROR: Author cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(isbn))
            {
                return "ERROR: ISBN cannot be empty";
            }

            if (year < 1000 || year > DateTime.Now.Year)
            {
                return "ERROR: Invalid publication year";
            }

            if (pages <= 0)
            {
                return "ERROR: Page count must be positive";
            }

            // Check for duplicate ISBN
            if (repository.ISBNExists(isbn))
            {
                return "ERROR: Book with this ISBN already exists!";
            }

            // Create and add book
            Book newBook = new Book("", isbn, title, author, year, publisher, pages, genre);
            repository.Add(newBook);

            return "SUCCESS: Book '" + title + "' added successfully with ID: " + newBook.ItemID;
        }

        // Add a new ebook
        public string AddEBook(string isbn, string title, string author, int year,
                               string downloadUrl, string format, double fileSize)
        {
            // Business validation
            if (string.IsNullOrWhiteSpace(title))
            {
                return "ERROR: Title cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                return "ERROR: Author cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(isbn))
            {
                return "ERROR: ISBN cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(downloadUrl))
            {
                return "ERROR: Download URL cannot be empty";
            }

            string[] validFormats = { "PDF", "EPUB", "MOBI", "AZW3" };
            bool validFormat = false;
            for (int i = 0; i < validFormats.Length; i++)
            {
                if (format.ToUpper() == validFormats[i])
                {
                    validFormat = true;
                    break;
                }
            }

            if (!validFormat)
            {
                return "ERROR: Format must be PDF, EPUB, MOBI, or AZW3";
            }

            if (fileSize <= 0)
            {
                return "ERROR: File size must be positive";
            }

            // Check for duplicate ISBN
            if (repository.ISBNExists(isbn))
            {
                return "ERROR: E-Book with this ISBN already exists!";
            }

            // Create and add ebook
            EBook newEBook = new EBook("", isbn, title, author, year, downloadUrl, format, fileSize);
            repository.Add(newEBook);

            return "SUCCESS: E-Book '" + title + "' added successfully with ID: " + newEBook.ItemID;
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
            LibraryItem item = repository.FindByID(itemId);

            if (item == null)
            {
                return "ERROR: Item not found!";
            }

            if (!item.IsAvailable)
            {
                return "ERROR: Item is already borrowed!";
            }

            item.Borrow();
            return "SUCCESS: " + item.GetCategory() + " '" + item.Title + "' borrowed successfully!";
        }

        // Return item
        public string ReturnItem(string itemId)
        {
            LibraryItem item = repository.FindByID(itemId);

            if (item == null)
            {
                return "ERROR: Item not found!";
            }

            if (item.IsAvailable)
            {
                return "ERROR: Item was not borrowed!";
            }

            int daysOverdue = item.GetDaysOverdue();
            decimal lateFee = item.GetCurrentLateFee();

            item.Return();

            if (daysOverdue > 0)
            {
                return "SUCCESS: Item returned. " + daysOverdue + " days overdue. Late fee: $" + lateFee.ToString("0.00");
            }
            else
            {
                return "SUCCESS: Item '" + item.Title + "' returned on time!";
            }
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

            EBook ebook1 = new EBook("", "978-1449355739", "Learning Python", "Mark Lutz",
                                     2013, "https://example.com/python.pdf", "PDF", 3.5);
            repository.Add(ebook1);
        }
    }
}
