using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Queries;

namespace Store.Tests;

[TestClass]
public class ProductQueriesTests
{
    private IList<Product> _products;

    public ProductQueriesTests()
    {
        _products = new List<Product>
        {
            new Product("Produto 01", 10, true),
            new Product("Produto 02", 20, true),
            new Product("Produto 03", 30, true),
            new Product("Produto 04", 40, false),
            new Product("Produto 05", 50, false)
        };
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenAProductActiveQuery_ItShouldReturn3()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
        Assert.AreEqual(result.Count(), 3);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void GivenAProductInactiveQuery_ItShouldReturn2()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
        Assert.AreEqual(result.Count(), 2);
    }
}