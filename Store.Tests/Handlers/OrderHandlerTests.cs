using Store.Domain.Commands.Interfaces;
using Store.Domain.Handlers;
using Store.Domain.Repository;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers;

[TestClass]
public class OrderHandlerTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeRepository _deliveryFeeRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderHandlerTests()
    {
        _customerRepository = new FakeCustomerRepository();
        _deliveryFeeRepository = new FakeDeliveryFeeRepository();
        _discountRepository = new FakeDiscountRepository();
        _productRepository = new FakeProductRepository();
        _orderRepository = new FakeOrderRepository();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenANonExistentCustomer_OrderCannotBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "454545444";
        command.ZipCode = "60510123";
        command.PromoCode = "2151848";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryFeeRepository,
            _discountRepository,
            _productRepository,
            _orderRepository
        );

        handler.Handle(command);
        Assert.AreEqual(handler.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenAInvalidZipCode_OrderCanBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678910";
        command.ZipCode = "11255451";
        command.PromoCode = "2151848";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryFeeRepository,
            _discountRepository,
            _productRepository,
            _orderRepository
        );

        handler.Handle(command);
        Assert.AreEqual(handler.IsValid, true);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenANonExistentPromoCode_OrderCanBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678910";
        command.ZipCode = "60510123";
        command.PromoCode = "2151848";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryFeeRepository,
            _discountRepository,
            _productRepository,
            _orderRepository
        );

        handler.Handle(command);
        Assert.AreEqual(handler.IsValid, true);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenAOrderWithoutItems_OrderCannotBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678910";
        command.ZipCode = "60510123";
        command.PromoCode = "2151848";
        command.Validate();

        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenAInvalidCommand_OrderCannotBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "13411080";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Validate();

        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenAValidCommand_OrderCanBeGenerated()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678910";
        command.ZipCode = "60510123";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            _customerRepository,
            _deliveryFeeRepository,
            _discountRepository,
            _productRepository,
            _orderRepository
        );

        handler.Handle(command);
        Assert.AreEqual(handler.IsValid, true);
    }
}