using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Enums;

namespace InventoryMiniProject.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
       

        public override string ToString()
        {
            return $"Transaction Id: {TransactionId}\n" +
                $"Product Id: {ProductId}\n" +
                $"Type: {Type}\n" +
                $"Quantity: {Quantity}\n" +
                $"Date: {Date}";
        }
    }
}
