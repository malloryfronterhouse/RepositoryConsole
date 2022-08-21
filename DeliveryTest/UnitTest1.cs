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
}
