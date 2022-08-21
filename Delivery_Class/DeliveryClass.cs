namespace Delivery_Class;
public class DeliveryItem
{
    public DeliveryItem() {}
//     The order date
// The delivery date
// The status of the order (Scheduled, EnRoute, Complete, or Canceled)
// The Item number
// The item quantity
// The customer ID (you can assume every customer has an account with a unique ID number of some kind)
public DeliveryItem(int orderNumber, DateTime orderDate, DateTime deliveryDate, string status, string itemName, int itemQuantity, int customerID) {
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
    public string Status { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerID { get; set; }
}
// The status of the order (Scheduled, EnRoute, Complete, or Canceled)
//enum
//public enum Status { Scheduled = 1, EnRoute, Complete, Canceled }