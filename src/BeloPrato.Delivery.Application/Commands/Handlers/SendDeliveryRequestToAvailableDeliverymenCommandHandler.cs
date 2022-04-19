using BeloPrato.Core.Communication.Mediator;
using BeloPrato.Core.Messages.CommonMessages.Notifications;
using BeloPrato.Delivery.Application.Commands.Models;
using BeloPrato.Delivery.Domain.Interfaces;
using BeloPrato.Delivery.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BeloPrato.Delivery.Application.Commands.Handlers
{
    public class SendDeliveryRequestToAvailableDeliverymenCommandHandler : IRequestHandler<SendDeliveryRequestToAvailableDeliverymenCommand, bool>
    {
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public SendDeliveryRequestToAvailableDeliverymenCommandHandler(IDeliveryRequestRepository deliveryRequestRepository, IMediatorHandler mediatorHandler)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(SendDeliveryRequestToAvailableDeliverymenCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                await PublishInvalidCommandNotifications(message);
                return false;
            }

            var order = await _orderRepository.GetById(message.OrderId);
            if (order == null)
            {
                await PublishOrderNotFoundNotification();
            }

            order.FinishOrder();
            order.AddEvent(new OrderFinishedEvent(order.Id));

            PersistFinishedOrder(order);

            return await CommitChanges();
        }

        private async Task PublishInvalidCommandNotifications(SendDeliveryRequestToAvailableDeliverymenCommand message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        private async Task PublishOrderNotFoundNotification()
        {
            await _mediatorHandler.PublishNotification(new DomainNotification("order", "Order not found!"));
        }

        private void PersistFinishedOrder(DeliveryRequest deliveryRequest)
        {
            de.Update(order);
        }

        private async Task<bool> CommitChanges()
        {
            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
