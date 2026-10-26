namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the three layers
            LibraryRepository repository = new LibraryRepository();
            LibraryManager manager = new LibraryManager(repository);
            LibraryUI ui = new LibraryUI(manager);

            // Add sample data
            manager.AddSampleItems();

            // Run the application
            ui.Run();
        }
    }
}
