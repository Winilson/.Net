using System;

namespace paymentcontext.Domain.Entities
{
 public abstract class Payment
 {
        protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string owner, string document, string address, string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpiredDate = expiredDate;
            Total = total;
            TotalPaid = totalPaid;
            Owner = owner;
            Document = document;
            Address = address;
            this.email = email;
        }

  public string Number { get; private set; }
   public DateTime PaidDate { get; private set; }
   public DateTime ExpiredDate { get; private set; }
   public Decimal Total { get; private set; }
   public Decimal TotalPaid { get; private set; }
   public string Owner { get; private set; }
   public string Document { get; private set; }
   public string Address {get; private set;}
   public string email {get; private set;}
   
 }   

}