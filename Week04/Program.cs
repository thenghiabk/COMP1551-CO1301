namespace Week04
{
    class Book
    {
        // Fields
        private string title;
        private string author;
        private int _pages;
        private string borrower;

        // Properties
        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentOutOfRangeException("Pages must be positive");
                }

                this._pages = value;
            }
        }

        // Constructors
        public Book()
        {
            this.author = "";
            this.title = "";
            this.Pages = 0;
            this.borrower = "";
        }

        public Book(string title, string author, int pages)
        {
            this.title = title;
            this.author = author;
            this.Pages = pages;
            this.borrower = "None";
        }

        // Helpers

        public void SetBorrower(string borrower)
        {
            this.borrower = borrower;
        }

        public void GetSummary()
        {
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Pages: {this.Pages}");
            Console.WriteLine($"Borrower: {this.borrower}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Book objects");

            //  The Lord of the Rings, J. R. R. Tolkien, 1178
            Book myBook = new Book("The Lord of the Rings", "J. R. R. Tolkien", 1178);

            //myBook.pages = -1183;
            //myBook.SetPages(-1183);
            myBook.Pages = 1183;

            myBook.GetSummary();


        }
    }
}
