using InventoryApp.Data;
using InventoryApp.Exceptions;
using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    internal class SupplierRepository
    {
        private readonly InventoryContext _context;

        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplier = GetSupplierById(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

        public Supplier GetSupplierById(int supplierId)
        {
            var supplier = _context.Suppliers.Where(s => s.SupplierId == supplierId).FirstOrDefault();
            if (supplier == null)
            {
                throw new SupplierNotFoundException();
            }
            return supplier;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
