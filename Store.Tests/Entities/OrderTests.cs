using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests;

[TestClass]
public class OrderTests
{
    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewValidOrder_ItShouldGenerateANumberWith8Characters()
    {
        var customer = new Customer("Saulo", "saulomlcosta10@gmail.com");
        var discount = new Discount(0, DateTime.UtcNow);
        var product = new Product("MousePad", 20m, true);

        var order = new Order(customer, 10.50m, discount);
        order.AddItem(product, 2);
        order.Pay(50.50m);

        Assert.IsTrue(order.IsValid);
        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewOrder_StatusShouldBeWaitingPayment()
    {
        var customer = new Customer("Saulo", "saulomlcosta10@gmail.com");
        var discount = new Discount(0, DateTime.UtcNow);
        var product = new Product("MousePad", 20m, true);

        var order = new Order(customer, 10.50m, discount);
        order.AddItem(product, 2);

        Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenAOrderPayment_StatusShouldBeWaitingDelivery()
    {
        var customer = new Customer("Saulo", "saulomlcosta10@gmail.com");
        var discount = new Discount(0, DateTime.UtcNow);
        var product = new Product("MousePad", 20m, true);

        var order = new Order(customer, 10.50m, discount);
        order.AddItem(product, 2);
        order.Pay(50.50m);

        Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenACancelOrder_StatusShouldBeCanceled()
    {
        var customer = new Customer("Saulo", "saulomlcosta10@gmail.com");
        var discount = new Discount(0, DateTime.UtcNow);
        var product = new Product("MousePad", 20m, true);

        var order = new Order(customer, 10.50m, discount);
        order.AddItem(product, 2);
        order.Cancel();

        Assert.AreEqual(EOrderStatus.Canceled, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewItemWithoutAProduct_ProductCanNotBeAdd()
    {
        var customer = new Customer("Saulo", "saulomlcosta10@gmail.com");
        var discount = new Discount(0, DateTime.UtcNow);
        var product = new Product("MousePad", 20m, true);

        var order = new Order(customer, 10.50m, discount);
        order.AddItem(product, 0);

        Assert.IsFalse(order.IsValid);
    }
}