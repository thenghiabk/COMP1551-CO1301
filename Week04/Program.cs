namespace Week04
{
    class Book
    {
        // Fields
        private string _title;
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

        public string Title
        {
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Title must be longer than 5 characters");
                }

                this._title = value;
            }
            get
            {
                return this._title.ToUpper();
            }
        }



        // Constructors
        public Book()
        {
            this.author = "";
            this.Title = "";
            this.Pages = 0;
            this.borrower = "";
        }

        public Book(string title, string author, int pages)
        {
            this.Title = title;
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
            //Console.WriteLine($"Title: {this._title}");
            Console.WriteLine($"Title: {this.Title}");



            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Pages: {this._pages}");
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
