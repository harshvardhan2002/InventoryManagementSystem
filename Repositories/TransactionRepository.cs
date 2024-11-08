using InventoryMiniProject.Data;
using InventoryMiniProject.Enums;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Repositories
{
    internal class TransactionRepository
    {
        private readonly InventoryContext _context;

        public TransactionRepository()
        {
            _context = new InventoryContext();
        }

        public void AddTransaction(Transaction transaction)
        {
            var product = _context.Products.Find(transaction.ProductId);
            if (product == null)
                throw new RecordNotFoundException("Product not found.");

            if (transaction.Type == TransactionType.REMOVESTOCK && product.Quantity < transaction.Quantity)
                throw new NotEnoughStockException();

            product.Quantity += transaction.Type == TransactionType.ADDSTOCK ? transaction.Quantity : -transaction.Quantity;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            var transactions = _context.Transactions.ToList();
            if (!transactions.Any())
                throw new RecordNotFoundException("No transactions found.");

            return transactions;
        }

        public List<Transaction> GetTransactionsByProductId(int productId)
        {
            var transactions = _context.Transactions.Where(t => t.ProductId == productId).ToList();
            if (!transactions.Any())
                throw new RecordNotFoundException("No transactions found for the specified product.");

            return transactions;
        }
    }
}
