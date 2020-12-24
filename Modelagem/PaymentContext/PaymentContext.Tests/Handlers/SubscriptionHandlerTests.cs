using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]

    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Andre";
            command.LastName = "Liv";
            command.Document = "99999999999";
            command.Email = "winilson@winilson.com";
            command.Barcode = "123456789";
            command.BoletoNumber = "12346549+87";
            command.PaymentNumber = "123121";
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Corp";
            command.PayerDocument = "1234567891011";
            command.PayerDocumentType = Domain.Enuns.EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "ffdfdfd";
            command.Number = "fdfdf";
            command.Neighborhood = "fdfdfd";
            command.City = "as";
            command.State = "as";
            command.Country = "as";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}