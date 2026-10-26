using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class LibraryItem
    {
        public string ItemID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? BorrowedDate { get; set; }

        // Constructor  
        public LibraryItem(string itemId, string title, string author, int year)
        {
            ItemID = itemId;
            Title = title;
            Author = author;
            PublicationYear = year;
            IsAvailable = true;
        }

        // Virtual method (can be overridden)  
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {ItemID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {PublicationYear}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
        }

        /// <summary>
        /// Gets the standard borrowing period in days
        /// </summary>
        public abstract int GetBorrowDuration();
        /// <summary>
        /// Calculates the late fee based on days overdue
        /// </summary>
        public abstract decimal CalculateLateFee(int daysOverdue);

        /// <summary>
        /// Gets the category/type of the library item
        /// </summary>
        public abstract string GetCategory();

        /// <summary>
        /// Determines if the item can be renewed
        /// </summary>
        public abstract bool CanBeRenewed();

        /// <summary>
        /// Gets the maximum number of times item can be renewed
        /// </summary>
        public abstract int GetMaxRenewals();

        /// <summary>
        /// Gets the media type (Physical/Digital)
        /// </summary>
        public abstract string GetMediaType();

        public DateTime GetDueDate()
        {
            if (BorrowedDate.HasValue)
            {
                return BorrowedDate.Value.AddDays(GetBorrowDuration());
            }
            return DateTime.Now.AddDays(GetBorrowDuration());
        }

        public int GetDaysOverdue()
        {
            if (!BorrowedDate.HasValue || IsAvailable)
                return 0;

            DateTime dueDate = GetDueDate();
            if (DateTime.Now > dueDate)
            {
                return (DateTime.Now - dueDate).Days;
            }
            return 0;
        }

        public decimal GetCurrentLateFee()
        {
            int daysOverdue = GetDaysOverdue();
            return CalculateLateFee(daysOverdue);
        }

        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                BorrowedDate = DateTime.Now;
                Console.WriteLine($"{GetCategory()} '{Title}' borrowed successfully!");
                Console.WriteLine($"Due date: {GetDueDate():yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine($"{GetCategory()} '{Title}' is not available.");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                int daysOverdue = GetDaysOverdue();
                decimal lateFee = CalculateLateFee(daysOverdue);

                Console.WriteLine($"{GetCategory()} '{Title}' returned.");

                if (daysOverdue > 0)
                {
                    Console.WriteLine($"Item was {daysOverdue} days overdue.");
                    Console.WriteLine($"Late fee: ${lateFee:0.00}");
                }

                BorrowedDate = null;
            }
        }
    }
}
