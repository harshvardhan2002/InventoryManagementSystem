using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.Repositories;

namespace InventoryApp.Presentation
{
    internal class ProductMenu
    {
        private readonly ProductRepository _productRepository;

        public ProductMenu(InventoryContext context)
        {
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
            Console.WriteLine("\nProduct Management\n" +
                    "1. Add Product\n" +
                    "2. Update Product\n" +
                    "3. Delete Product\n" +
                    "4. View Product Details\n" +
                    "5. View All Products\n" +
                    "6. Go Back to Main Menu\n" +
                    "Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct();
                    return false;
                case 2:
                    UpdateProduct();
                    return false;
                case 3:
                    DeleteProduct();
                    return false;
                case 4:
                    ViewProductDetails();
                    return false;
                case 5:
                    ViewAllProducts();
                    return false;
                case 6:
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }


        private void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter inventory ID: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            Product product = new Product { ProductName = name, Description = description, Price = price, Quantity = quantity, InventoryId = inventoryId };
            _productRepository.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        private void UpdateProduct()
        {
            Console.Write("Enter product ID to update: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new name: ");
            product.ProductName = Console.ReadLine();
            Console.Write("Enter new description: ");
            product.Description = Console.ReadLine();
            Console.Write("Enter new price: ");
            product.Price = Convert.ToDouble(Console.ReadLine());

            _productRepository.UpdateProduct(product);
            Console.WriteLine("Product updated successfully.");
        }

        private void DeleteProduct()
        {
            Console.Write("Enter product ID to delete: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            _productRepository.DeleteProduct(productId);
            Console.WriteLine("Product deleted successfully.");
        }

        private void ViewProductDetails()
        {
            Console.Write("Enter product ID to view: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product product = _productRepository.GetProductById(productId);
            if (product != null)
                Console.WriteLine(product);
            else
                Console.WriteLine("Product not found.");
        }

        private void ViewAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            foreach (var product in products)
                Console.WriteLine(product);
        }
    }
}
