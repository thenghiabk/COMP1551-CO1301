using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class MySQLReposity : ILibraryRepository

    {
        void ILibraryRepository.Add(LibraryItem item)
        {
            throw new NotImplementedException();
        }

        bool ILibraryRepository.Delete(string itemId)
        {
            throw new NotImplementedException();
        }

        LibraryItem ILibraryRepository.FindByID(string itemId)
        {
            throw new NotImplementedException();
        }

        LibraryItem ILibraryRepository.FindByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        List<LibraryItem> ILibraryRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        List<Book> ILibraryRepository.GetAllBooks()
        {
            throw new NotImplementedException();
        }

        List<EBook> ILibraryRepository.GetAllEBooks()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetAvailableCount()
        {
            throw new NotImplementedException();
        }

        List<LibraryItem> ILibraryRepository.GetAvailableItems()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetBookCount()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetBorrowedCount()
        {
            throw new NotImplementedException();
        }

        List<LibraryItem> ILibraryRepository.GetBorrowedItems()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetCount()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetEBookCount()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetNewestYear()
        {
            throw new NotImplementedException();
        }

        int ILibraryRepository.GetOldestYear()
        {
            throw new NotImplementedException();
        }

        List<LibraryItem> ILibraryRepository.GetOverdueItems()
        {
            throw new NotImplementedException();
        }

        bool ILibraryRepository.ISBNExists(string isbn)
        {
            throw new NotImplementedException();
        }

        List<LibraryItem> ILibraryRepository.Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
