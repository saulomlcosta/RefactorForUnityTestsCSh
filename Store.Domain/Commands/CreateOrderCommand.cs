using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands.Interfaces;

public class CreateOrderCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderCommand()
    {
        Items = new List<CreateOrderItemCommand>();
    }

    public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        Items = items;
    }

    public string Customer { get; set; }
    public string ZipCode { get; set; }
    public string PromoCode { get; set; }
    public IList<CreateOrderItemCommand> Items { get; set; }


    public void Validate()
    {
        AddNotifications(new Contract<CreateOrderCommand>()
            .Requires()
            .IsNotNullOrEmpty(Customer, "Customer", "Cliente inválido")
            .IsGreaterOrEqualsThan(Items, 1, "Items", "O número de itens não pode ser 0")
            .IsGreaterOrEqualsThan(ZipCode, 8, "ZipCode", "Cep inválida")
        );
    }
}
