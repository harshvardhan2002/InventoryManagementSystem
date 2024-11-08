using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.Repositories;

namespace InventoryApp.Presentation
{
    internal class TransactionMenu
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly ProductRepository _productRepository;

        public TransactionMenu(InventoryContext context)
        {
            _transactionRepository = new TransactionRepository(context);
            _productRepository = new ProductRepository(context);
        }

        public void Display()
        {
            bool exit = false;
            while (!exit)
            {
                exit = MakeChoice();
            }
        }

        public bool MakeChoice()
        {
            Console.WriteLine("\nTransaction Management\n" +
                    "1. Add Stock\n" +
                    "2. Remove Stock\n" +
                    "3. View Transaction History\n" +
                    "4. Go Back to Main Menu\n" +
                    "Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStock();
                    return false;
                case 2:
                    RemoveStock();
                    return false;
                case 3:
                    ViewTransactionHistory();
                    return false;
                case 4:
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private void AddStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter quantity to add: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            product.Quantity += quantity;
            _productRepository.UpdateProduct(product);

            Transaction transaction = new Transaction
            {
                ProductId = productId,
                TransactionType = "Add",
                Quantity = quantity,
                Date = DateTime.Now,
                InventoryId = product.InventoryId
            };
            _transactionRepository.AddTransaction(transaction);
            Console.WriteLine("Stock added and transaction recorded.");
        }

        private void RemoveStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter quantity to remove: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            if (product.Quantity < quantity)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            product.Quantity -= quantity;
            _productRepository.UpdateProduct(product);

            Transaction transaction = new Transaction
            {
                ProductId = productId,
                TransactionType = "Remove",
                Quantity = quantity,
                Date = DateTime.Now,
                InventoryId = product.InventoryId
            };
            _transactionRepository.AddTransaction(transaction);
            Console.WriteLine("Stock removed and transaction recorded.");
        }

        private void ViewTransactionHistory()
        {
            var transactions = _transactionRepository.GetAllTransactions();
            foreach (var transaction in transactions)
                Console.WriteLine(transaction);
        }
    }
}
