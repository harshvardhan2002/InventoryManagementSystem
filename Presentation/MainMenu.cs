using InventoryApp.Data;

namespace InventoryApp.Presentation
{
    internal class MainMenu
    {
        private ProductMenu _productMenu;
        private SupplierMenu _supplierMenu;
        private TransactionMenu _transactionMenu;
        private InventoryReportMenu _reportMenu;

        public MainMenu(InventoryContext context)
        {
            _productMenu = new ProductMenu(context);
            _supplierMenu = new SupplierMenu(context);
            _transactionMenu = new TransactionMenu(context);
            _reportMenu = new InventoryReportMenu(context);
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
            Console.WriteLine("\nWelcome to the Inventory Management System\n" +
                    "1. Product Management\n" +
                    "2. Supplier Management\n" +
                    "3. Transaction Management\n" +
                    "4. Generate Report\n" +
                    "5. Exit\n" +
                    "Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    _productMenu.Display();
                    return false;
                case 2:
                    _supplierMenu.Display();
                    return false;
                case 3:
                    _transactionMenu.Display();
                    return false;
                case 4:
                    _reportMenu.Display();
                    return false;
                case 5:
                    Console.WriteLine("Exiting...");
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }
    }
}
