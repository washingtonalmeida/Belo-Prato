using BeloPrato.Core.DomainObjects;
using System;

namespace BeloPrato.Delivery.Domain.Models
{
    public class Deliveryman : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsAvailableToDelivery { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Deliveryman(string name, string phoneNumber, bool isAvailableToDelivery)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            IsAvailableToDelivery = isAvailableToDelivery;
        }

        public void AvailableToDelivery()
        {
            IsAvailableToDelivery = true;
        }

        public void UnavailableToDelivery()
        {
            IsAvailableToDelivery = false;
        }

        protected override void Validate()
        {
            Validations.EmptyThrowsException(Name, "'Name' cannot be empty.");
            Validations.EmptyThrowsException(PhoneNumber, "'PhoneNumber' cannot be empty.");
            Validations.NullThrowsException(IsAvailableToDelivery, "'IsAvailableToDelivery' cannot be empty.");
        }
    }
}
