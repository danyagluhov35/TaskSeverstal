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
        private int TypeDeliveryId = 5;

        IDelivery ServiceDelivery;
        public DeliveryModel(int SupplierId, IDelivery ServiceDelivery)
        {
            this.SupplierId = SupplierId;
            this.ServiceDelivery = ServiceDelivery;
        }
        public void AddDelivery()
        {
            var delivery = new Delivery
            {
                DeliveryDateCreate = DeliveryDateCreate,
                SuppllierId = SupplierId,
                TypeDeliveryId = TypeDeliveryId
            };
            ServiceDelivery.AddDelivery(delivery);
        }
    }
}
