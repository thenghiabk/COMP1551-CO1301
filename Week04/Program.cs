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

        // Constructor
        public LibraryItem(int itemId, string Title)
        {
            this.ItemId = itemId;
            this.Title = Title;
        }

        // Helpers
        // 1. Abstract Contract (No body)
        // MUST be implemented by all child classes!
        public abstract void Checkout();

        // 2. Concrete Shared Logic
        // Available to all derived types
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Id: {ItemId}");
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
        public string ISBN { get; set; }



        // Constructors
        public Book() : base(0, "")
        {
            this.Author = "";
            this.Title = "";
            this.Pages = 0;
            this.Borrower = "";
        }

        public Book(int id, string title, string author, int pages) : base(id, title)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Borrower = "None";
        }

        // Helpers

        public override void Checkout()
        {
            Console.WriteLine($"[Book] '{Title}' by {Author}");
            Console.WriteLine("Due back in 14 days.");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
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
            Book myBook = new Book(1, "The Lord of the Rings", "J. R. R. Tolkien", 1178);

            myBook.DisplayInfo();


        }
    }
}
