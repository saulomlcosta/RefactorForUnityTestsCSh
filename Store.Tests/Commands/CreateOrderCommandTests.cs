using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;

namespace Store.Tests;

[TestClass]
public class CreateOrderCommandTests
{
    [TestMethod]
    [TestCategory("Handlers")]
    public void GivenAInvalidCommand_OrderCannotBeProcessed()
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
}