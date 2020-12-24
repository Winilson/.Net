using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if(document == "00000000000")
                 return true;

            return false;

        }

        public bool EmailExists(string email)
        {
            if(email == "winilson@winilson.com")
            return true;

            return false;
        }   
    }
}