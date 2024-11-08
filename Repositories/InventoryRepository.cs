using InventoryMiniProject.Data;
using InventoryMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Repositories
{
    internal class InventoryRepository
    {
        private readonly InventoryContext _context = new InventoryContext();

        public string GenerateInventoryDetails()
        {
            var products = _context.Products.ToList();
            double totalValue = products.Sum(product => product.Price * product.Quantity);
            return $"Total Inventory Value: {totalValue}";
        }

        public List<Product> ListProducts()
        {
            return _context.Products.ToList();
        }

        public List<Supplier> ListSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public List<Transaction> ListTransactions()
        {
            return _context.Transactions.ToList();
        }
    }
}
