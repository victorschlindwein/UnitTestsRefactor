﻿using Store.Domain.Commands;
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

        public void CreateOrderItemsCommand(CreateOrderCommand command)
        {
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoClienteInexistentePedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = null,
                ZipCode = "18423568",
                PromoCode = "12345678"
            };

            CreateOrderItemsCommand(command);
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoCepInvalidoPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = "18423568",
                ZipCode = null,
                PromoCode = "12345678"
            };
            CreateOrderItemsCommand(command);
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoPromocodeInexistentePedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand
            {
                Customer = "18423568",
                ZipCode = "18423568",
                PromoCode = null
            };
            CreateOrderItemsCommand(command);
            command.Validate();
            
            Assert.AreEqual(true, command.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoQuePedidoEstaSemItensNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = "18423568",
                ZipCode = "18423568",
                PromoCode = "12345678",
            };

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );
            handler.Handle(command);
            
            Assert.AreEqual(false, command.Valid);
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
            CreateOrderItemsCommand(command);
            command.Validate();
            
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoComandoValidoPedidoDeveSerGerado()
        {
            var command = new CreateOrderCommand
            {
                Customer = "18423568",
                ZipCode = "13411080",
                PromoCode = "12345678"
            };
            CreateOrderItemsCommand(command);

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );
            handler.Handle(command);
            
            Assert.AreEqual(true, command.Valid);
        }
    }
}
