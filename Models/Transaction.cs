using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string TransactionType { get; set; } // E.g., "Add Stock" or "Remove Stock"
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Product? Product { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Inventory? Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public override string ToString()
        {
            return $"Transaction Id: {TransactionId}" +
                   $"\nTransaction Type: {TransactionType}" +
                   $"\nProduct Id: {ProductId}" +
                   $"\nQuantity: {Quantity}" +
                   $"\nDate: {Date}" +
                   $"\nInventory ID: {InventoryId}";
        }
    }
}
