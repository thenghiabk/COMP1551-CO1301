namespace Lab3
{
    class Book
    {
        // Fields

        private string title;
        private string author;
        private string isbn;
        private int publicationYear;
        private bool isAvailable;
        private string category;

        // Constructors
        public Book(string title, string author, string isbn, int publicationYear, string category)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.publicationYear = publicationYear;
            this.category = category;
            this.isAvailable = true;
        }

        // Helpers
        public void CheckOut()
        {
            this.isAvailable = false;
        }

        public void Return()
        {
            this.isAvailable = true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"ISBN: {this.isbn}");
            Console.WriteLine($"Publication Year: {this.publicationYear}");
            Console.WriteLine($"Category: {this.category}");
            Console.WriteLine($"Is Available: {this.isAvailable}");
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
            Book book1 = new Book("The Lord of the Rings", "J. R. R. Tolkien", "ISBNXXXXXX", 1954, "Epic Fantasy");
            Book book2 = new Book("The Hobbit", "J. R. R. Tolkien", "ISBNXXXXXX", 1937, "Children's Fantasy Novel");

            book1.DisplayInfo();
            book2.DisplayInfo();
        }
    }
}
