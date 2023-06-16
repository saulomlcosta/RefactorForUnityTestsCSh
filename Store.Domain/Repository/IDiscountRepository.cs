using Store.Domain.Entities;

namespace Store.Domain.Repository;

public interface IDiscountRepository
{
    Discount Get(string code);
}
