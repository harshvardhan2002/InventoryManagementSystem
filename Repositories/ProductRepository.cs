using InventoryApp.Data;
using InventoryApp.Exceptions;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            var existingProduct = _context.Products.Where(p => p.ProductName == product.ProductName).FirstOrDefault();
            if (existingProduct != null)
            {
                throw new DuplicateProductException();
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
