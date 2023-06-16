using Store.Domain.Entities;
using Store.Domain.Repository;

namespace Store.Tests.Repositories;

public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
{
    public decimal Get(string zipCode)
    {
        return 10;
    }
}