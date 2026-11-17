using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Layer 1
            //ILibraryRepository repo = new InMemoryRepository();
            ILibraryRepository repo = new MySqlRepository(DbConfig.ConnectionString);

            // Layer 2
            LibraryManager manager = new LibraryManager(repo);
            // Add sample data
            //manager.AddSampleItems();

            // Layer 3
            ILibraryView view = new ConsoleView(manager);


            // Run the application
            view.Run();
        }
    }
}
