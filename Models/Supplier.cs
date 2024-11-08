using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactInformation { get; set; }

        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }


        public override string ToString()
        {
            return $"Supplier Name: {SupplierName}\n" +
                $"Contact Info: {ContactInformation}";
        }
    }
}
