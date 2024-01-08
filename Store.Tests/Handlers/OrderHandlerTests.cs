using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRespotiroy();
            _productRepository = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoClienteInexistentePedidoNaoDeveSerGerado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoCepInvalidoPedidoDeveSerGeradoNormalmente()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoPromocodeInexistentePedidoDeveSerGeradoNormalmente()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoQuePedidoEstaSemItensNaoDeveSerGerado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoComandoInvalidoPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = "",
                ZipCode = "18423568",
                PromoCode = "12345678"
            };
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoComandoValidoPedidoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = "12345678",
                ZipCode = "13411080",
                PromoCode = "12345678"
            };

            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );

            handler.Handle(command);
            Assert.AreEqual(command.Valid, true);
        }
    }
}
