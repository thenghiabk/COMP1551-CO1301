using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal interface ILibraryView
    {
        void Run();

        // UI helper methods (you will map these to Console.WriteLine / ReadLine)
        void DisplayMenu();
        void ShowMessage(string message);
        void ShowError(string message);
        string GetInput(string prompt);

        // optional but useful for reuse/testing
        void DisplayItems(List<LibraryItem> items);
        void DisplayStatistics(int total, int available, int borrowed);
    }
}
