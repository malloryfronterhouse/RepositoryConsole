namespace Delivery_Class;
public class DeliveryItem
{
    public DeliveryItem() {}

public DeliveryItem(int orderNumber, DateTime orderDate, DateTime deliveryDate, Status status, string itemName, int itemQuantity, int customerID) {
    OrderNumber = orderNumber;
    OrderDate = orderDate;
    DeliveryDate= deliveryDate;
    Status = status;
    ItemName = itemName;
    ItemQuantity = itemQuantity;
    CustomerID = customerID;
}
public int OrderNumber { get; set; }
    public string ItemName { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public Status Status { get; set; }

    public int ItemQuantity { get; set; }
    public int CustomerID { get; set; }
}
//enum
public enum Status { Scheduled = 1, EnRoute, Complete, Canceled }