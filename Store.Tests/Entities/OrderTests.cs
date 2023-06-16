using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests;

[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new Customer("Saulo Costa", "sulomlcosta10gmail.com");
    private readonly Product _product = new Product("Product 1", 10, true);
    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewValidOrder_ItShouldGenerateANumberWith8Characters()
    {
        var order = new Order(_customer, 0, null);
        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewOrder_StatusShouldBeWaitingPayment()
    {
        var order = new Order(_customer, 0, null);
        Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenAOrderPayment_StatusShouldBeWaitingDelivery()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(_product, 1);
        order.Pay(10);
        Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenACancelOrder_StatusShouldBeCanceled()
    {
        var order = new Order(_customer, 0, null);
        order.Cancel();
        Assert.AreEqual(EOrderStatus.Canceled, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewItemWithoutAProduct_ProductCannotBeAdd()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(null, 10);
        Assert.AreEqual(order.Items.Count, 0);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewItemWithQuantityZeroOrMinus_ProductCannotBeAdd()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(_product, 0);
        Assert.AreEqual(order.Items.Count, 0);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenANewValidOrder_OrderTotalHasToBe50()
    {
        var order = new Order(_customer, 20, null);
        order.AddItem(_product, 3);
        Assert.AreEqual(order.Total(), 50);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenExpiredDiscount_OrderTotalHasToBe60()
    {
        var discount = new Discount(10, DateTime.Now.AddDays(-1));
        var order = new Order(_customer, 20, discount);
        order.AddItem(_product, 4);
        Assert.AreEqual(order.Total(), 50);
    }
}