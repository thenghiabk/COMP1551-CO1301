namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Layer 1
            ILibraryRepository repo = new InMemoryRepository();

            // Layer 2
            LibraryManager manager = new LibraryManager(repo);
            manager.AddSampleItems();

            // Layer 3
            ILibraryView view = new ConsoleView(manager);
            view.Run();


            // Add sample data
            manager.AddSampleItems();

            // Run the application
            view.Run();
        }
    }
}
