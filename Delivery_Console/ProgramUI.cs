namespace Delivery_Class;
class ProgramUI {
    RepositoryConsoleApp _repo = new RepositoryConsoleApp();
    public void Run()
    {
        Seed();
        Menu();
    }
    private void Menu()
    {
        bool keepRunning = true;
        while(keepRunning){
            Console.Clear();
        System.Console.WriteLine("Please select from the following options:\n"
        + "Select a menu option:\n"
        + "1. Add a new delivery.\n"
        + "2. List all deliveries.\n"
        + "3. Update a delivery item.\n"
        + "4. Cancel a delivery.\n"
        + "5. Exit.");
        string? userResponse = Console.ReadLine();
        switch(userResponse) {
            case "1":
            AddDeliveryItem();
            break;
            case "2":
            ViewAllDeliveryItems();
            break;
            case "3":
            UpdateDeliveryItem();
            break;
            case "4":
            RemoveDeliveryItem();
            break;
            case "5":
            System.Console.WriteLine("See you later!");
            keepRunning = false;
            break;
            default:
            System.Console.WriteLine("Please review your options and try again.");
            break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    private void AddDeliveryItem() {
        Console.Clear();

        DeliveryItem newItem = new DeliveryItem();

        System.Console.WriteLine("Please enter a name for your new delivery item..");
        newItem.ItemName = Console.ReadLine();
        System.Console.WriteLine("Please enter an order number...");
        newItem.OrderNumber = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please enter the date you ordered your item");
        newItem.OrderDate = DateTime.Parse(Console.ReadLine());
        System.Console.WriteLine("Please enter your unique customer ID!");
        newItem.CustomerID = int.Parse(Console.ReadLine());
        bool itemCreated = _repo.AddDeliveryItem(newItem);
    if(itemCreated) {
        Console.Clear();
        System.Console.WriteLine("Item succdessfully created.\n");
    }
    else
    {
        Console.Clear();
        System.Console.WriteLine("New item was not successfully created. Please try again.\n");
    }
    }
    private void ViewAllDeliveryItems() {
        Console.Clear();
        foreach (DeliveryItem item in _repo.GetAllDeliveries())
        {
            DisplayItem(item);
        }
    }
    private void UpdateDeliveryItem() {
        Console.Clear();

        DeliveryItem newItem = new DeliveryItem();

        System.Console.WriteLine("Please enter the name of the item you would like to update.");
        string itemName = newItem.ItemName;
        newItem.ItemName = Console.ReadLine();

    System.Console.WriteLine("Please enter a new quantity for the item. If you don't wish to change it please press enter.");
    newItem.ItemQuantity = int.Parse(Console.ReadLine());

    System.Console.WriteLine("Please enter the updated status for the item. If no changes are needed please press enter.");
//System.Console.WriteLine("Please enter the updated status for the item. If no changes are needed please press enter.");
    //string status = newItem.Status;
    newItem.Status = Console.ReadLine();

    bool updateSuccess = _repo.UpdateDeliveryItem(itemName, newItem);

    if(updateSuccess) {
        Console.Clear();
        System.Console.WriteLine("Update was successful!");
    }
    else
    {
        Console.Clear();
        System.Console.WriteLine("Update unsuccessful please try again...");
    }
    }
    private void RemoveDeliveryItem() {
        Console.Clear();
        System.Console.WriteLine("Please enter the item name for the item you would like to delete...");
        string itemName = Console.ReadLine();
        bool deleteSuccessful = _repo.RemoveDeliveryItem(itemName);
        if(deleteSuccessful)
        {
            Console.Clear();
            System.Console.WriteLine("Delete successful!");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Delete unsuccessful please try again!");
        }
        }
    private void DisplayItem(DeliveryItem item) {
        System.Console.WriteLine($"{item.ItemName}.\n"
        + "------------\n"
        + $"Order #: {item.OrderNumber} for {item.ItemName} was ordered on {item.OrderDate}.\n"
        + $"You ordered {item.ItemQuantity} of {item.ItemName}.\n"
        + $"It's {item.Status} and will be delivered on {item.DeliveryDate}\n"
        + $"Please feel free to check back on you order at any time using your Customer ID #: {item.CustomerID}\n");
    }
    private void Seed(){
        DeliveryItem laptop = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 15), new DateTime(2022, 08, 21), "Complete", "HP Laptop", 5, 001);
        _repo.AddDeliveryItem(laptop);
        DeliveryItem vacuum = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 21), new DateTime(2022, 08, 24), "Scheduled", "Dyson Vacuum", 1, 005);
        _repo.AddDeliveryItem(vacuum);
        DeliveryItem couch = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 12), new DateTime(2022, 08, 21), "EnRoute", "Big Comfy Couch", 2, 007);
        _repo.AddDeliveryItem(couch);
        DeliveryItem bookcase = new DeliveryItem(_repo.GetAllDeliveries().Count +1, new DateTime(2022, 08, 16), new DateTime(2022, 08, 16), "Canceled", "Gray Bookcase", 7, 009);
        _repo.AddDeliveryItem(bookcase);
    }
    // int orderNumber, DateTime orderDate, DateTime deliveryDate, Status status, string itemName, , int itemQuantity, int customerID
}