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
        DeliveryItem? oldItem = _delivery.Find(item => item.ItemName == itemName);

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