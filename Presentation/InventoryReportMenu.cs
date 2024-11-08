using InventoryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Presentation
{
    internal class InventoryReportMenu
    {
        private readonly InventoryContext _context;

        public InventoryReportMenu(InventoryContext context)
        {
            _context = context;
        }

        public void Display()
        {
            bool backToMainMenu = MakeChoice();
            if (backToMainMenu)
            {
                return;
            }
        }

        public bool MakeChoice()
        {
            Console.WriteLine("\nInventory Report\n" +
                "1. View Inventory Details\n" +
                "2. List All Products\n" +
                "3. List All Suppliers\n" +
                "4. List All Transactions\n" +
                "5. Go Back to Main Menu\n" +
                "Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewInventoryDetails();
                    break;
                case 2:
                    ListAllProducts();
                    break;
                case 3:
                    ListAllSuppliers();
                    break;
                case 4:
                    ListAllTransactions();
                    break;
                case 5:
                    return true; //goes back to main menu
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            return false; // loop keeps on running
        }

        private void ViewInventoryDetails()
        {
            var totalProducts = _context.Products.Count();
            var totalStockValue = _context.Products.Sum(p => p.Quantity * p.Price);
            Console.WriteLine($"Total number of products: {totalProducts}");
            Console.WriteLine($"Total stock value: {totalStockValue}");
        }
        private void ListAllProducts()
        {
            var products = _context.Products.ToList();
            foreach (var product in products)
                Console.WriteLine(product);
        }

        private void ListAllSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            foreach (var supplier in suppliers)
                Console.WriteLine(supplier);
        }

        private void ListAllTransactions()
        {
            var transactions = _context.Transactions.ToList();
            foreach (var transaction in transactions)
                Console.WriteLine(transaction);
        }
    }
}
