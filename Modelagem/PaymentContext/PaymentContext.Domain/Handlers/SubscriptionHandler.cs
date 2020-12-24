using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
    Notifiable,
    IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repo;
        private readonly IEmailService _emailservice;

        public SubscriptionHandler(IStudentRepository repo, IEmailService emailService)
        {
            _repo = repo;
            _emailservice = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {

            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar a sua assinatura");
            }

            if (_repo.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF está em uso");

            if (_repo.EmailExists(command.Email))
                AddNotification("Document", "Este Email está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.Barcode, command.BoletoNumber, command.PaidDate, 
            command.ExpiredDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument,command.PayerDocumentType),
            address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if(Invalid)
            return new CommandResult(false, "Assinatura nao realizada");

            return new CommandResult(true, "Assinatura realizada com sucesso");

            _repo.CreateSubscription(student);
            _emailservice.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!", "Criada!");
        }
    }
}