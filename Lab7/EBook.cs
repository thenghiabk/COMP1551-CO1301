using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class EBook : LibraryItem
    {
        public string ISBN { get; set; }
        public string DownloadURL { get; set; }
        public string FileFormat { get; set; } // PDF, EPUB, MOBI
        public double FileSizeMB { get; set; }
        public int DownloadLimit { get; set; }

        public EBook(string itemId, string isbn, string title, string author,
                     int year, string downloadUrl, string format, double fileSize)
            : base(itemId, title, author, year)
        {
            ISBN = isbn;
            DownloadURL = downloadUrl;
            FileFormat = format;
            FileSizeMB = fileSize;
            DownloadLimit = 3; // Can download 3 times
        }

        // Implement abstract methods
        public override int GetBorrowDuration()
        {
            // E-books can be "borrowed" for 14 days
            return 14;
        }

        public override decimal CalculateLateFee(int daysOverdue)
        {
            // E-books have no late fee (auto-return)
            return 0m;
        }

        public override string GetCategory()
        {
            return "E-Book";
        }

        public override bool CanBeRenewed()
        {
            // E-books cannot be renewed (automatic return)
            return false;
        }

        public override int GetMaxRenewals()
        {
            return 0;
        }

        public override string GetMediaType()
        {
            return "Digital";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Format: {FileFormat}");
            Console.WriteLine($"File Size: {FileSizeMB:0.00} MB");
            Console.WriteLine($"Borrow Duration: {GetBorrowDuration()} days");
            Console.WriteLine($"Auto-Return: Yes (No late fees)");
            Console.WriteLine($"Media Type: {GetMediaType()}");
        }

        public void Download()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"Downloading {Title} ({FileFormat})...");
                Console.WriteLine($"Download URL: {DownloadURL}");
                Console.WriteLine($"File Size: {FileSizeMB:0.00} MB");
                Console.WriteLine("Download started!");
            }
            else
            {
                Console.WriteLine("Please borrow this e-book first.");
            }
        }
    }
}
