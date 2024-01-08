using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    internal class FakeOrderRespotiroy : IOrderRepository
    {
        public void Save(Order order)
        {
            
        }
    }
}
