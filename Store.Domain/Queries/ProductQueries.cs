using Store.Domain.Entities;

namespace Store.Domain.Queries;

public static class ProductQueries
{
    public static Func<Product, bool> GetActiveProducts()
    {
        return x => x.Active;
    }

    public static Func<Product, bool> GetInactiveProducts()
    {
        return x => !x.Active;
    }
}