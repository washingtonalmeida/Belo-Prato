using System;
using BeloPrato.Core.DomainObjects;

namespace BeloPrato.Delivery.Domain.Models
{
    public class DeliveryRequest : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public Guid DeliverymanId { get; private set; }
        public bool IsAccepted { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime? ResponseDate { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public DeliveryRequest(Guid orderId, Guid deliverymanId, bool isAccepted)
        {
            OrderId = orderId;
            DeliverymanId = deliverymanId;
            IsAccepted = isAccepted;
            RequestDate = DateTime.Now;
        }

        public void AcceptDelivery()
        {
            IsAccepted = true;
            ResponseDate = DateTime.Now;
        }

        public void DeclineDelivery()
        {
            IsAccepted = true;
            ResponseDate = DateTime.Now;
        }

        protected override void Validate()
        {
            Validations.EqualsThrowsException(OrderId, Guid.Empty, "'OrderId' cannot be empty.");
            Validations.EqualsThrowsException(DeliverymanId, Guid.Empty, "'DeliverymanId' cannot be empty.");
            Validations.NullThrowsException(IsAccepted, "'IsAccepted' cannot be empty.");
            Validations.NullThrowsException(RequestDate, "'RequestDate' cannot be empty.");
        }

    }
}
