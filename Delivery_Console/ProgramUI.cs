using System.Net.WebSockets;
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
        + "5. View EnRoute or Complete deliveries.\n"
        + "6. Exit");
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
            ViewEnRouteOrComplete();
            break;
            case "6":
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

    private void ViewEnRouteOrComplete() {

        bool deliveryEnrouteOrComplete = true;
        while (deliveryEnrouteOrComplete)
        {
            Console.Clear();

            foreach (DeliveryItem item in _repo.GetAllDeliveries())
            {
                System.Console.WriteLine("Would you like to view Completed Deliveries or EnRoute Deliveries?\n"
                + "2. EnRoute Deliveries\n"
                + "3. Completed Deliveries\n"
                + "4. Main Menu");
                string? deliveryStatusString = Console.ReadLine();

                switch (deliveryStatusString)
                {
                    case "2":
                    case "3":
                    int completeInt = int.Parse(deliveryStatusString);
                    item.Status = (Status)completeInt;
                    DisplayItem(item);
                        break;
                    case "4":
                    System.Console.WriteLine("Not EnRoute or Complete");
                    deliveryEnrouteOrComplete = false;
                        break;
                    default:
                    System.Console.WriteLine("Incorrect Response. Please try again.");
                        break;
                }
            }
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
        System.Console.WriteLine("Item successfully created.\n");
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

        System.Console.WriteLine("Please enter the name of the item you would like to update.");
        
        DeliveryItem newItem = new DeliveryItem();
        
        newItem.ItemName = Console.ReadLine();
        string itemName = newItem.ItemName;
        

    System.Console.WriteLine("Please enter a new quantity for the item. If you don't wish to change it please press enter.");
    newItem.ItemQuantity = int.Parse(Console.ReadLine());

    System.Console.WriteLine($"Please enter the updated status for the item. If no changes are needed please press enter.\n"
    + "1. Scheduled\n"
    + "2. EnRoute\n"
    + "3. Complete\n"
    + "4. Canceled\n");

    try {
        string? statusString = Console.ReadLine();
        int statusInt = int.Parse(statusString);
        newItem.Status = (Status)statusInt;
    } 
    catch (FormatException e) 
    {
        System.Console.WriteLine(e.Message);
    }
    

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
        System.Console.WriteLine($@"Item: {item.ItemName} | Item Quantity: {item.ItemQuantity}
        Order Date: {item.OrderDate} | Delivery Date: {item.DeliveryDate}
        Status: {item.Status} ---------- Order Number: {item.OrderNumber}
        Please feel free to check on your order at any time using your Customer ID: {item.CustomerID}
        Your order is: {item.Status}");
    }
    private void Seed(){
        DeliveryItem laptop = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 15), new DateTime(2022, 08, 21), Status.Complete, "HP Laptop", 5, 184731);
        _repo.AddDeliveryItem(laptop);
        DeliveryItem vacuum = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 21), new DateTime(2022, 08, 24), Status.EnRoute, "Dyson Vacuum", 1, 3329485);
        _repo.AddDeliveryItem(vacuum);
        DeliveryItem couch = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, new DateTime(2022, 08, 12), new DateTime(2022, 08, 21), Status.Scheduled, "Big Comfy Couch", 2, 3492847);
        _repo.AddDeliveryItem(couch);
        DeliveryItem bookcase = new DeliveryItem(_repo.GetAllDeliveries().Count +1, new DateTime(2022, 08, 16), new DateTime(2022, 08, 16), Status.Canceled, "Gray Bookcase", 7, 3482499);
        _repo.AddDeliveryItem(bookcase);
    }
}