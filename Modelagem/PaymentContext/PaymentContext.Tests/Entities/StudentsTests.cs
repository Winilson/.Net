using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.Domain.Entities;

namespace paymentcontext.tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("André", "Baltiere", "12345678912", "hello@balta.io");
            student.AddSubscription(subscription);
            
        }

    }

}