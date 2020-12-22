using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enuns;

namespace PaymentContext.Tests
{
    [TestClass]

    public class DocumentTests
    {
        [TestMethod]

        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]

        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("12345678945635", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]

        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]

        public void ShouldReturnSuccessWhenCPFIsInvalid()
        {
            var doc = new Document("12345678900", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }
    }
}