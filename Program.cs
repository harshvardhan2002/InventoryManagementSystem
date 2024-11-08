using InventoryApp.Data;
using InventoryApp.Presentation;

namespace InventoryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryContext context = new InventoryContext();
            MainMenu menu = new MainMenu(context);
            menu.Display();
        }
    }
}
