using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;
using TestTask.IService;

namespace TestTask.Model
{
    internal class DeliveryModel
    {
        private DateTime DeliveryDateCreate = DateTime.UtcNow;
        private int SupplierId;

        IDelivery ServiceDelivery;
        public DeliveryModel(int SupplierId, IDelivery ServiceDelivery)
        {
            this.SupplierId = SupplierId;
            this.ServiceDelivery = ServiceDelivery;
        }
        public int AddDelivery()
        {
            var delivery = new Delivery
            {
                DeliveryDateCreate = DeliveryDateCreate,
                SuppllierId = SupplierId
            };
            ServiceDelivery.AddDelivery(delivery);

            return delivery.Id;
        }
    }
}
