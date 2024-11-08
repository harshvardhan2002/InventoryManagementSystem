using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Models
{
    internal class Inventory
    {
        public int InventoryId { get; set; }
        public string Location { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}" +
                   $"\nLocation: {Location}" +
                   $"\nNumber of Products: {Products.Count}" +
                   $"\nNumber of Suppliers: {Suppliers.Count}" +
                   $"\nNumber of Transactions: {Transactions.Count}";
        }
    }
}
