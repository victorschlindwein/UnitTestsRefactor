using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount? Get(string code)
        {
            return code switch
            {
                "12345678" => new Discount(10, DateTime.Now.AddDays(5)),
                "11111111" => new Discount(10, DateTime.Now.AddDays(-5)),
                _ => null
            };
        }
    }
}
