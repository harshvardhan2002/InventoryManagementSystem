using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.Repositories;

namespace InventoryApp.Presentation
{
    internal class SupplierMenu
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierMenu(InventoryContext context)
        {
            _supplierRepository = new SupplierRepository(context);
        }

        public void Display()
        {
            bool exit = false;
            while (!exit)
            {
                exit = MakeChoice();
            }
        }

        public bool MakeChoice()
        {
            Console.WriteLine("\nSupplier Management\n" +
                    "1. Add Supplier\n" +
                    "2. Update Supplier\n" +
                    "3. Delete Supplier\n" +
                    "4. View Supplier Details\n" +
                    "5. View All Suppliers\n" +
                    "6. Go Back to Main Menu\n" +
                    "Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddSupplier();
                    return false;
                case 2:
                    UpdateSupplier();
                    return false;
                case 3:
                    DeleteSupplier();
                    return false;
                case 4:
                    ViewSupplierDetails();
                    return false;
                case 5:
                    ViewAllSuppliers();
                    return false;
                case 6:
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private void AddSupplier()
        {
            Console.Write("Enter supplier name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact information: ");
            string contactInfo = Console.ReadLine();
            Console.Write("Enter inventory ID: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            Supplier supplier = new Supplier { SupplierName = name, ContactInfo = contactInfo, InventoryId = inventoryId };
            _supplierRepository.AddSupplier(supplier);
            Console.WriteLine("Supplier added successfully.");
        }

        private void UpdateSupplier()
        {
            Console.Write("Enter supplier ID to update: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            Supplier supplier = _supplierRepository.GetSupplierById(supplierId);
            if (supplier == null)
            {
                Console.WriteLine("Supplier not found.");
                return;
            }

            Console.Write("Enter new name: ");
            supplier.SupplierName = Console.ReadLine();
            Console.Write("Enter new contact information: ");
            supplier.ContactInfo = Console.ReadLine();

            _supplierRepository.UpdateSupplier(supplier);
            Console.WriteLine("Supplier updated successfully.");
        }

        private void DeleteSupplier()
        {
            Console.Write("Enter supplier ID to delete: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());
            _supplierRepository.DeleteSupplier(supplierId);
            Console.WriteLine("Supplier deleted successfully.");
        }

        private void ViewSupplierDetails()
        {
            Console.Write("Enter supplier ID to view: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            Supplier supplier = _supplierRepository.GetSupplierById(supplierId);
            if (supplier != null)
                Console.WriteLine(supplier);
            else
                Console.WriteLine("Supplier not found.");
        }

        private void ViewAllSuppliers()
        {
            var suppliers = _supplierRepository.GetAllSuppliers();
            foreach (var supplier in suppliers)
                Console.WriteLine(supplier);
        }
    }
}
