namespace Week03
{
    class Book
    {
        // Fields
        private string title;
        private string author;
        private int pages;
        private string borrower;

        // Constructors
        public Book()
        {
            this.author = "";
            this.title = "";
            this.pages = 0;
            this.borrower = "";
        }

        public Book(string title, string author, int pages)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.borrower = "None";
        }

        // Helpers
        public void SetPages(int pages)
        {
            this.pages = pages;
        }

        public void SetBorrower(string borrower)
        {
            this.borrower = borrower;
        }

        public void GetSummary()
        {
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Pages: {this.pages}");
            Console.WriteLine($"Borrower: {this.borrower}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Book objects");

            //Book myBook = new Book();
            //myBook.title = "The Hobbit";
            //myBook.author = "J. R. R. Tolkien";
            //myBook.pages = 312;

            // Harry Potter, Joanne Rowling, 223 pages

            //Book yourBook = new Book();
            //yourBook.title = "Harry Potter";
            //yourBook.author = "Joanne Rowling";
            //yourBook.pages = 223;

            //  The Lord of the Rings, J. R. R. Tolkien, 1178
            Book anotherBook = new Book("The Lord of the Rings", "J. R. R. Tolkien", 1178);

            // Print summary to check
            anotherBook.GetSummary();

            // Update the pages 
            anotherBook.SetPages(1183);

            anotherBook.SetBorrower("John Doe");

            // Print summary to check
            anotherBook.GetSummary();


        }
    }
}
