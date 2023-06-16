using Store.Domain.Entities;

namespace Store.Domain.Repository;

public interface ICustomerRepository
{
    Customer Get(string document);
}
