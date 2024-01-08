using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>
            {
                new("Produto 01", 10, true),
                new("Produto 02", 10, true),
                new("Produto 03", 10, true),
                new("Produto 04", 10, false),
                new("Produto 05", 10, false)
            };

            return products;
        }
    }
}
