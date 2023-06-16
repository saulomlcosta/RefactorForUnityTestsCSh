using Store.Domain.Entities;

namespace Store.Domain.Repository;

public interface IOrderRepository
{
    void Save(Order order);
}
