using BeloPrato.Core.DomainObjects;
using BeloPrato.Delivery.Domain.Enums;
using System;

namespace BeloPrato.Delivery.Domain.Models
{
    public class Delivery : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public Guid DeliverymanId { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public TimeSpan EstimatedDeliveryTime { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public DeliveryStatus DeliveryStatus { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Delivery(Guid orderId, Guid deliverymanId, DeliveryAddress deliveryAddress, TimeSpan estimatedDeliveryTime, 
                        decimal deliveryFee)
        {
            OrderId = orderId;
            DeliverymanId = deliverymanId;
            DeliveryAddress = deliveryAddress;
            EstimatedDeliveryTime = estimatedDeliveryTime;
            DeliveryFee = deliveryFee;

            Validate();
        }

        protected override void Validate()
        {
            Validations.EqualsThrowsException(OrderId, Guid.Empty, "'OrderId' cannot be empty.");
            Validations.EqualsThrowsException(DeliverymanId, Guid.Empty, "'DeliverymanId' cannot be empty.");
            Validations.NullThrowsException(DeliveryAddress, "'DeliveryAddress' cannot be empty.");
            Validations.NullThrowsException(EstimatedDeliveryTime, "'EstimatedDeliveryTime' cannot be empty.");
            Validations.NullThrowsException(DeliveryFee, "'DeliveryFee' cannot be empty.");
        }

        public void StartDelivery()
        {
            DeliveryStatus = DeliveryStatus.InProgress;
        }

        public void CancelDelivery()
        {
            DeliveryStatus = DeliveryStatus.Canceled;
        }

        public void FinishDelivery()
        {
            DeliveryStatus = DeliveryStatus.Delivered;
        }
    }
}
