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
        public bool IsAvailable { get; private set; }

        // Public properties (controlled access)
        public string Title
        {
            get { return title; }
            set
            {
                // Data Validation
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
        // GLOBAL LISTS (accessible by all functions)
        static List<Book> library = new List<Book>();


        static void Main(string[] args)
        {
            // Add some sample books so list isn't empty
            AddSampleBooks();

            // Welcome
            Console.WriteLine("║    SMARTLIBRARY MANAGEMENT SYSTEM     ║");

            Console.WriteLine();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Statistics");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice (1-6): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddBook();
                }
                else if (choice == "2")
                {
                    ViewAllBooks();
                }
                else if (choice == "3")
                {
                    SearchBooks();
                }
                else if (choice == "4")
                {
                    DeleteBook();
                }
                else if (choice == "5")
                {
                    ShowStatistics();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("\nThank you for using SmartLibrary!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("\n Invalid choice!");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
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

        // Add sample books for demonstration
        static void AddSampleBooks()
        {
            Book book1 = new Book("Clean Code", "Robert Martin",
                                  "978-0132350884", 2008);

            library.Add(book1);

            Book book2 = new Book("The Hobbit", "J.R.R. Tolkien",
                                   "978-0547928227", 1937);
            library.Add(book2);

            library.Add(new Book("1984", "George Orwell",
                            "978-0451524935", 1949));
        }

        // Function to add a new book
        static void AddBook()
        {
            Console.WriteLine("\n=== ADD NEW BOOK ===");

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            // Check if ISBN already exists  
            if (library.Any(b => b.ISBN == isbn))
            {
                Console.WriteLine("Book with this ISBN already exists!");
                return;
            }

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Publication Year: ");
            int year = int.Parse(Console.ReadLine());

            // Create and add book  
            Book newBook = new Book(title, author, isbn, year);
            library.Add(newBook);

            Console.WriteLine($"\nBook '{title}' added successfully!");
        }

        // Function to view all books
        static void ViewAllBooks()
        {
            Console.WriteLine("\n=== ALL BOOKS ===");

            if (library.Count == 0)
            {
                Console.WriteLine("No books in library.");
                return;
            }

            Console.WriteLine($"Total books: {library.Count}\n");

            int count = 1;
            foreach (Book book in library)
            {
                Console.WriteLine($"\n--- Book #{count++} ---");
                book.DisplayInfo();
            }


        }

        // Function to search for books
        static void SearchBooks()
        {
            Console.WriteLine("\n=== SEARCH BOOKS ===");
            Console.Write("Enter search term (title or author): ");
            string searchTerm = Console.ReadLine().ToLower();


            Console.WriteLine($"\nBooks by {searchTerm}:");
            foreach (Book book in library)
            {
                if (book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    book.DisplayInfo();
                }
            }

            Console.ReadLine();

        }

        // Function to delete a book
        static void DeleteBook()
        {
            Console.WriteLine("\n=== DELETE BOOK ===");
            Console.Write("Enter ISBN to delete: ");
            string isbn = Console.ReadLine();

            Book book = library.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }


            library.Remove(book);
            Console.WriteLine($"Book '{book.Title}' deleted successfully!");

        }
        // Function to show statistics
        static void ShowStatistics()
        {
            Console.WriteLine("\n=== LIBRARY STATISTICS ===");
            Console.WriteLine($"Total Books: {library.Count}");
            Console.WriteLine($"Available Books: {library.Count(b => b.IsAvailable)}");
            Console.WriteLine($"Borrowed Books: {library.Count(b => !b.IsAvailable)}");
            Console.WriteLine();


            // Find oldest and newest books
            if (library.Count > 0)
            {
                int oldest = library[0].PublicationYear;
                int newest = library[0].PublicationYear;

                for (int i = 1; i < library.Count; i++)
                {
                    if (library[i].PublicationYear < oldest) oldest = library[i].PublicationYear;
                    if (library[i].PublicationYear > newest) newest = library[i].PublicationYear;
                }

                Console.WriteLine($"Oldest book: {oldest}");
                Console.WriteLine($"Newest book: {newest}");
            }
        }
    }
}
