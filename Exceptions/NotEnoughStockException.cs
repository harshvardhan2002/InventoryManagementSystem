using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Exceptions
{
    internal class NotEnoughStockException : Exception
    {
        public NotEnoughStockException() : base("Not enough stock available to complete the transaction.") { }
    }
}
