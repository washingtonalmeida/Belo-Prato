using BeloPrato.Core.Communication.Mediator;
using BeloPrato.Core.Messages.CommonMessages.IntegrationEvents;
using BeloPrato.Delivery.Application.Commands.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BeloPrato.Delivery.Application.Events.Handlers
{
    public class PreparedOrderEventHandler : INotificationHandler<PreparedOrderEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PreparedOrderEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(PreparedOrderEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommand(new SendDeliveryRequestToAvailableDeliverymenCommand(message.RestaurantId,
                message.CustomerId, message.OrderId, message.OrderNumber));
        }
    }
}
