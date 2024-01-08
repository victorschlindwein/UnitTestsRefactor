using Store.Domain.Commands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
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
    }
}
