namespace Lab3
{
    class Book
    {
        // Private fields (hidden from outside)
        private string title;
        private string author;
        // Properties (hold data about the book)
        public string ISBN;
        public int PublicationYear;
        public bool IsAvailable;

        // Constructor: Runs when creating a new book
        public Book(string title, string author, string isbn, int year)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = year;
            IsAvailable = true;  // New books are available
        }

        // Method: Display book information
        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Year: {PublicationYear}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
        }

        // Public properties (controlled access)
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty!");
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author cannot be empty!");
                }
                author = value;
            }
        }

        // Method: Borrow this book
        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"'{Title}' has been borrowed.");
            }
            else
            {
                Console.WriteLine($"'{Title}' is already borrowed.");
            }
        }

        // Method: Return this book
        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Console.WriteLine($"'{Title}' has been returned.");
            }
            else
            {
                Console.WriteLine($"'{Title}' was not borrowed.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book Management App");
            TestBooks();
        }

        static void TestBooks()
        {
            // Create a book object
            Book book1 = new Book("Clean Code", "Robert Martin",
                                  "978-0132350884", 2008);

            // Use the book's methods
            book1.DisplayInfo();
            Console.WriteLine();

            book1.Borrow();  // Borrow the book
            book1.Borrow();  // Try to borrow again (will fail)
            book1.Return();  // Return it

            // Create another book
            Book book2 = new Book("The Hobbit", "J.R.R. Tolkien",
                                    "978-0547928227", 1937);

            book2.DisplayInfo();
        }
    }
}
