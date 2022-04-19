using BeloPrato.Core.DomainObjects;

namespace BeloPrato.Delivery.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Customer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;

            Validate();
        }

        protected override void Validate()
        {
            Validations.EmptyThrowsException(Name, "'Name' cannot be empty.");
            Validations.PhoneNumberInvalidThrowsException(PhoneNumber, "'PhoneNumber' is invalid.");
        }

    }
}
