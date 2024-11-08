using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }
        public Inventory Inventory { get; set; }
        
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public override string ToString()
        {
            return $"Supplier Id: {SupplierId}" +
                   $"\nSupplier Name: {SupplierName}" +
                   $"\nContact Info: {ContactInfo}" +
                   $"\nInventory ID: {InventoryId}";
        }

    }
}
