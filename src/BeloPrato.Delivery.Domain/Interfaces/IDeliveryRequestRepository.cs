using BeloPrato.Core.Data;
using BeloPrato.Delivery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeloPrato.Delivery.Domain.Interfaces
{
    public interface IDeliveryRequestRepository : IRepository<DeliveryRequest>
    {
        void Add(DeliveryRequest deliveryRequest);
        void Update(DeliveryRequest deliveryRequest);
        Task<DeliveryRequest> GetById(Guid id);
        Task<IEnumerable<DeliveryRequest>> GetByOrderId(Guid orderId);
        Task<IEnumerable<DeliveryRequest>> GetByDeliverymanId(Guid deliverymanId);
    }
}
