using InventoryMiniProject.Enums;
using InventoryMiniProject.Models;
using InventoryMiniProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Presentation
{
    internal class TransactionMenu
    {
        private static TransactionRepository _transactionRepository;

        public TransactionMenu()
        {
            _transactionRepository = new TransactionRepository();
        }

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\nTransaction Management:");
                Console.WriteLine("1. Add Stock to Product");
                Console.WriteLine("2. Remove Stock from Product");
                Console.WriteLine("3. View Transaction History");
                Console.WriteLine("4. Go Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStock();
                        break;
                    case "2":
                        RemoveStock();
                        break;
                    case "3":
                        ViewTransactionHistory();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Quantity to Add: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            var transaction = new Transaction
            {
                ProductId = productId,
                Type = TransactionType.ADDSTOCK,
                Quantity = quantity
            };

            _transactionRepository.AddTransaction(transaction);
            Console.WriteLine("Stock added successfully.");

        }

        private static void RemoveStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Quantity to Remove: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            var transaction = new Transaction
            {
                ProductId = productId,
                Type = TransactionType.REMOVESTOCK,
                Quantity = quantity
            };

            _transactionRepository.AddTransaction(transaction);
            Console.WriteLine("Stock removed successfully.");

        }

        private static void ViewTransactionHistory()
        {
            Console.Write("Enter Product ID to view transaction history: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            var transactions = _transactionRepository.GetTransactionsByProductId(productId);
            Console.WriteLine("Transaction History:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }

        }
    }
}
