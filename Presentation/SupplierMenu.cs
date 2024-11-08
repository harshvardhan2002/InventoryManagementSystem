using InventoryMiniProject.Models;
using InventoryMiniProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Presentation
{
    internal class SupplierMenu
    {
        private static readonly SupplierRepository supplierRepository = new SupplierRepository();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\nSupplier Management");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Update Supplier");
                Console.WriteLine("3. Delete Supplier");
                Console.WriteLine("4. View Supplier Details");
                Console.WriteLine("5. View All Suppliers");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSupplier();
                        break;
                    case "2":
                        UpdateSupplier();
                        break;
                    case "3":
                        DeleteSupplier();
                        break;
                    case "4":
                        ViewSupplierDetails();
                        break;
                    case "5":
                        ViewAllSuppliers();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddSupplier()
        {
            Console.Write("Enter Supplier Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Contact Information: ");
            string contactInfo = Console.ReadLine();

            var supplier = new Supplier
            {
                SupplierName = name,
                ContactInformation = contactInfo
            };

            supplierRepository.AddSupplier(supplier);
            Console.WriteLine("Supplier added successfully.");

        }

        private static void UpdateSupplier()
        {
            Console.Write("Enter Supplier ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Supplier Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Contact Information: ");
            string contactInfo = Console.ReadLine();

            var updatedSupplier = new Supplier
            {
                SupplierName = name,
                ContactInformation = contactInfo
            };

            supplierRepository.UpdateSupplier(id, updatedSupplier);
            Console.WriteLine("Supplier updated successfully.");

        }

        private static void DeleteSupplier()
        {
            Console.Write("Enter Supplier ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            supplierRepository.DeleteSupplier(id);
            Console.WriteLine("Supplier deleted successfully.");

        }

        private static void ViewSupplierDetails()
        {
            Console.Write("Enter Supplier ID to View: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var supplier = supplierRepository.GetSupplierById(id);
            Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.SupplierName}, Contact: {supplier.ContactInformation}");

        }

        private static void ViewAllSuppliers()
        {
            var suppliers = supplierRepository.GetAllSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.SupplierName}");
            }

        }
    }
}
