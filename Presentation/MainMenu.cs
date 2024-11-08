using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Presentation
{
    internal class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Inventory Management System");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProductMenu.Show();
                        break;
                    case "2":
                        SupplierMenu.Show();
                        break;
                    case "3":
                        TransactionMenu.Show();
                        break;
                    case "4":
                        InventoryReportMenu.Show();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
