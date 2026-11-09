using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class InMemoryRepository : ILibraryRepository
    {
        private List<LibraryItem> items;
        private int nextId;

        public InMemoryRepository()
        {
            items = new List<LibraryItem>();
            nextId = 1;
        }

        // Add an item
        public void Add(LibraryItem item)
        {
            if (item == null)
            {
                throw new Exception("Item cannot be null");
            }

            if (string.IsNullOrWhiteSpace(item.ItemID))
            {
                item.ItemID = GenerateItemId(item);
            }

            items.Add(item);
        }

        // Get all items
        public List<LibraryItem> GetAll()
        {
            return items;
        }

        // Find item by ID
        public LibraryItem FindByID(string itemId)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemID == itemId)
                {
                    return items[i];
                }
            }
            return null;
        }

        // Find item by ISBN (for Books and EBooks)
        public LibraryItem FindByISBN(string isbn)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is Book book && book.ISBN == isbn)
                {
                    return book;
                }
                if (items[i] is EBook ebook && ebook.ISBN == isbn)
                {
                    return ebook;
                }
            }
            return null;
        }

        // Search items by title or author
        public List<LibraryItem> Search(string searchTerm)
        {
            List<LibraryItem> results = new List<LibraryItem>();

            for (int i = 0; i < items.Count; i++)
            {
                string title = items[i].Title.ToLower();
                string author = items[i].Author.ToLower();
                string search = searchTerm.ToLower();

                if (title.Contains(search) || author.Contains(search))
                {
                    results.Add(items[i]);
                }
            }

            return results;
        }

        // Get all books
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is Book book)
                {
                    books.Add(book);
                }
            }
            return books;
        }

        // Get all ebooks
        public List<EBook> GetAllEBooks()
        {
            List<EBook> ebooks = new List<EBook>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EBook ebook)
                {
                    ebooks.Add(ebook);
                }
            }
            return ebooks;
        }

        // Get available items
        public List<LibraryItem> GetAvailableItems()
        {
            List<LibraryItem> available = new List<LibraryItem>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IsAvailable)
                {
                    available.Add(items[i]);
                }
            }
            return available;
        }

        // Get borrowed items
        public List<LibraryItem> GetBorrowedItems()
        {
            List<LibraryItem> borrowed = new List<LibraryItem>();
            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].IsAvailable)
                {
                    borrowed.Add(items[i]);
                }
            }
            return borrowed;
        }

        // Get overdue items
        public List<LibraryItem> GetOverdueItems()
        {
            List<LibraryItem> overdue = new List<LibraryItem>();
            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].IsAvailable && items[i].GetDaysOverdue() > 0)
                {
                    overdue.Add(items[i]);
                }
            }
            return overdue;
        }

        // Delete an item
        public bool Delete(string itemId)
        {
            LibraryItem item = FindByID(itemId);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        // Check if ISBN exists
        public bool ISBNExists(string isbn)
        {
            return FindByISBN(isbn) != null;
        }

        // Get total count
        public int GetCount()
        {
            return items.Count;
        }

        // Get count of books
        public int GetBookCount()
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is Book)
                {
                    count++;
                }
            }
            return count;
        }

        // Get count of ebooks
        public int GetEBookCount()
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EBook)
                {
                    count++;
                }
            }
            return count;
        }

        // Get available count
        public int GetAvailableCount()
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IsAvailable)
                {
                    count++;
                }
            }
            return count;
        }

        // Get borrowed count
        public int GetBorrowedCount()
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].IsAvailable)
                {
                    count++;
                }
            }
            return count;
        }

        // Get oldest publication year
        public int GetOldestYear()
        {
            if (items.Count == 0)
                return 0;

            int oldest = items[0].PublicationYear;
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].PublicationYear < oldest)
                {
                    oldest = items[i].PublicationYear;
                }
            }
            return oldest;
        }

        // Get newest publication year
        public int GetNewestYear()
        {
            if (items.Count == 0)
                return 0;

            int newest = items[0].PublicationYear;
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].PublicationYear > newest)
                {
                    newest = items[i].PublicationYear;
                }
            }
            return newest;
        }

        // Generate unique item ID
        private string GenerateItemId(LibraryItem item)
        {
            string prefix = "I";

            if (item is Book)
            {
                prefix = "B";
            }
            else if (item is EBook)
            {
                prefix = "E";
            }

            string id = prefix + nextId.ToString("D4");
            nextId++;
            return id;
        }
    }
}
