using Store.Domain.Entities;

namespace Store.Domain.Repository;

public interface IProductRepository
{
    IEnumerable<Product> Get(IEnumerable<Guid> ids);
}
