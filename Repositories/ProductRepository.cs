using InventoryMiniProject.Data;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _context = new InventoryContext();

        public void AddNewProduct(Product product)
        {
            if (_context.Products.Any(p => p.ProductName == product.ProductName))
                throw new DuplicateRecordException("Product with the same name already exists.");
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(int productId, Product updatedProduct)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
                throw new RecordNotFoundException("Product not found.");

            product.ProductName = updatedProduct.ProductName;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
                throw new RecordNotFoundException("Product not found.");
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId) ?? throw new RecordNotFoundException("Product not found.");
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
