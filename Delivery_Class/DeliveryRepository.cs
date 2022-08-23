namespace Delivery_Class;
public class RepositoryConsoleApp {
    protected readonly List<DeliveryItem> _delivery = new List<DeliveryItem>();
    //create
    public bool AddDeliveryItem(DeliveryItem item) {
        int prevCount = _delivery.Count;

        _delivery.Add(item);

        return prevCount < _delivery.Count ? true : false;

    }
    //read
    public List<DeliveryItem> GetAllDeliveries() {
        return _delivery;
    }
    //update
    public bool UpdateDeliveryItem(string itemName, DeliveryItem newItem) {
        //DeliveryItem newItem = new DeliveryItem();


        DeliveryItem? oldItem = _delivery.Find(item => item.ItemName == itemName);
        // if(oldItem != null)
        // {
        //     oldItem.ItemName = newItem.ItemName != "" ? newItem.ItemName : oldItem.ItemName;
        //     oldItem.OrderNumber = newItem.OrderNumber != 0 ? newItem.OrderNumber : oldItem.OrderNumber;
        //     oldItem.OrderDate = newItem.OrderDate != null ? newItem.OrderDate : oldItem.OrderDate;
        //     oldItem.DeliveryDate = newItem.DeliveryDate != null ? newItem.DeliveryDate : oldItem.DeliveryDate;
        //     oldItem.Status = newItem.Status != 0 ? newItem.Status : oldItem.Status;
        //     oldItem.ItemQuantity = newItem.ItemQuantity != 0 ? newItem.ItemQuantity : oldItem.ItemQuantity;
        //     oldItem.CustomerID = newItem.CustomerID != 0 ? newItem.CustomerID : oldItem.CustomerID;
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }

        if(oldItem != null) {
            oldItem.Status = newItem.Status != 0? newItem.Status : oldItem.Status;
            return true;
        } else {
            return false;
        }
    }
    //delete
    public bool RemoveDeliveryItem(string itemName) {
        DeliveryItem? itemToDelete = _delivery.Find(item => item.ItemName == itemName);

        bool deleteItem = _delivery.Remove(itemToDelete);

        return deleteItem;
    }
}