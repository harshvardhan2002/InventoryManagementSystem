using InventoryMiniProject.Models;
using InventoryMiniProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Presentation
{
    internal class ProductMenu
    {
        private static ProductRepository productRepository = new ProductRepository();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\nProduct Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product Details");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        ViewProductDetails();
                        break;
                    case "5":
                        ViewAllProducts();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            var product = new Product
            {
                ProductName = name,
                Description = description,
                Price = price
            };

            productRepository.AddNewProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        private static void UpdateProduct()
        {
            Console.Write("Enter Product ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter New Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            var updatedProduct = new Product
            {
                ProductName = name,
                Description = description,
                Price = price
            };

            productRepository.UpdateProduct(id, updatedProduct);
            Console.WriteLine("Product updated successfully.");

        }

        private static void DeleteProduct()
        {
            Console.Write("Enter Product ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            productRepository.DeleteProduct(id);
            Console.WriteLine("Product deleted successfully.");

        }

        private static void ViewProductDetails()
        {
            Console.Write("Enter Product ID to View: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var product = productRepository.GetProductById(id);
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Description: {product.Description}, Price: {product.Price}");

        }

        private static void ViewAllProducts()
        {
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
            }

        }
    }
}
