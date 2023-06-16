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
    public void GivenANonExistsCustomer_OrderCannotBeGenerated()
    {
    }
}