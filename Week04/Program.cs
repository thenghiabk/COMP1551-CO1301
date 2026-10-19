namespace Week04
{
    abstract class LibraryItem
    {
        // Fields
        private string _title;

        // Properties
        public int ItemId { get; set; }
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

        // Helpers
        // 1. Abstract Contract (No body)
        // MUST be implemented by all child classes!
        public abstract void Checkout();

        // 2. Concrete Shared Logic
        // Available to all derived types
        public void DisplayInfo()
        {
            Console.WriteLine($"Item: {Title}");
        }
    }

    class Book : LibraryItem
    {
        // Fields
        
        private string _author;
        private int _pages;
        private string _borrower;

        // Properties
        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                // validation
                if (value < 10)
                {
                    throw new ArgumentOutOfRangeException("Pages must be positive");
                }

                this._pages = value;
            }
        }

        

        public string Author { get => _author; set => _author = value; }
        public string Borrower { get => _borrower; set => _borrower = value; }



        // Constructors
        public Book()
        {
            this.Author = "";
            this.Title = "";
            this.Pages = 0;
            this.Borrower = "";
        }

        public Book(string title, string author, int pages)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Borrower = "None";
        }

        // Helpers

        public void GetSummary()
        {
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Author: {this.Author}");
            Console.WriteLine($"Pages: {this.Pages}");
            Console.WriteLine($"Borrower: {this.Borrower}");
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
