﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Exceptions
{
    internal class DuplicateProductException:Exception
    {
        public DuplicateProductException() : base("Duplicate product found.") { }
    }
}
