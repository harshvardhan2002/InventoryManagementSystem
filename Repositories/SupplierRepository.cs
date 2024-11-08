using InventoryMiniProject.Data;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Repositories
{
    internal class SupplierRepository
    {
        private readonly InventoryContext _context = new InventoryContext();

        public void AddSupplier(Supplier supplier)
        {
            if (_context.Suppliers.Any(s => s.SupplierName == supplier.SupplierName))
                throw new DuplicateRecordException("Supplier with the same name already exists.");
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(int supplierId, Supplier updatedSupplier)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier == null)
                throw new RecordNotFoundException("Supplier not found.");

            supplier.SupplierName = updatedSupplier.SupplierName;
            supplier.ContactInformation = updatedSupplier.ContactInformation;
            _context.SaveChanges();
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier == null)
                throw new RecordNotFoundException("Supplier not found.");
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return _context.Suppliers.Find(supplierId) ?? throw new RecordNotFoundException("Supplier not found.");
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
