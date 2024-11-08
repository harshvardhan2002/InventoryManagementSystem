using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    internal class TransactionRepository
    {
        private readonly InventoryContext _context;

        public TransactionRepository(InventoryContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }
    }
}
