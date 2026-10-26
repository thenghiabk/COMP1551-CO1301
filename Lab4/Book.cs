using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Book : LibraryItem
    {
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }

        public Book(string itemId, string isbn, string title, string author,
                int year, string publisher, int pages, string genre)
        : base(itemId, title, author, year)
        {
            ISBN = isbn;
            Publisher = publisher;
            PageCount = pages;
            Genre = genre;
        }

        // Implement abstract methods
        public override int GetBorrowDuration()
        {
            // Books can be borrowed for 21 days
            return 21;
        }
        public override decimal CalculateLateFee(int daysOverdue)
        {
            // Books: $0.50 per day
            return daysOverdue * 0.50m;
        }

        public override string GetCategory()
        {
            return "Book";
        }

        public override bool CanBeRenewed()
        {
            // Books can be renewed
            return true;
        }

        public override int GetMaxRenewals()
        {
            // Books can be renewed up to 3 times
            return 3;
        }

        public override string GetMediaType()
        {
            return "Physical";
        }

        // Override DisplayInfo to add book-specific details
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Pages: {PageCount}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Borrow Duration: {GetBorrowDuration()} days");
            Console.WriteLine($"Late Fee: ${CalculateLateFee(1):0.00}/day");
            Console.WriteLine($"Media Type: {GetMediaType()}");
        }
    }
}
