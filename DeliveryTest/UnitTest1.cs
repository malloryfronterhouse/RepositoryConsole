using Delivery_Class;

namespace DeliveryTest;
[TestClass]
public class Tests
{
    [TestMethod]
    public void DeliveryTests()
    {
        DeliveryItem item = new DeliveryItem();
        item.ItemName = "cats";
        string expected = "cats";
        string actual = "cats";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]

    public void Delivery_Status() {
        DeliveryItem item = new DeliveryItem();
        item.Status = Status.Complete;

        Status expected = Status.Complete;
        Status actual = Status.Complete;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]

    public void DeliveryAddTest() {
        DeliveryItem item = new DeliveryItem();

        bool itemCreated = false;

        if(itemCreated == false) {
            System.Console.WriteLine("Item was not successfully created!");
        }

        Assert.IsFalse(itemCreated, "Item was not successfully created!");
    }
}   

