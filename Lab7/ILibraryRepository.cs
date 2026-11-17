using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal interface ILibraryRepository
    {
        void Add(LibraryItem item);
        List<LibraryItem> GetAll();
        LibraryItem FindByID(string itemId);
        LibraryItem FindByISBN(string isbn);
        List<LibraryItem> Search(string searchTerm);
        List<Book> GetAllBooks();
        List<EBook> GetAllEBooks();
        List<LibraryItem> GetAvailableItems();
        List<LibraryItem> GetBorrowedItems();
        List<LibraryItem> GetOverdueItems();
        bool Delete(string itemId);
        bool ISBNExists(string isbn);
        int GetCount();
        int GetBookCount();
        int GetEBookCount();
        int GetAvailableCount();
        int GetBorrowedCount();
        int GetOldestYear();
        int GetNewestYear();
    }
}
