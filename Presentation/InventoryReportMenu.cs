using InventoryMiniProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Presentation
{
    internal class InventoryReportMenu
    {
        private static InventoryRepository inventoryRepository;

        public InventoryReportMenu()
        {
            inventoryRepository = new InventoryRepository();
        }

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\nGenerate Inventory Report");
                Console.WriteLine("1. View Inventory Details");
                Console.WriteLine("2. List All Products");
                Console.WriteLine("3. List All Suppliers");
                Console.WriteLine("4. List All Transactions");
                Console.WriteLine("5. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventoryDetails();
                        break;
                    case "2":
                        ListProducts();
                        break;
                    case "3":
                        ListSuppliers();
                        break;
                    case "4":
                        ListTransactions();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void ViewInventoryDetails()
        {
            var inventoryDetails = inventoryRepository.GenerateInventoryDetails();
            Console.WriteLine(inventoryDetails);
        }

        private static void ListProducts()
        {
            var products = inventoryRepository.ListProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        private static void ListSuppliers()
        {
            var suppliers = inventoryRepository.ListSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier);
            }
        }

        private static void ListTransactions()
        {
            var transactions = inventoryRepository.ListTransactions();
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
