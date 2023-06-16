using Store.Domain.Entities;
using Store.Domain.Repository;

namespace Store.Tests.Repositories;

public class FakeOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
    }
}