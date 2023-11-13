using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;
using TestTask.IService;

namespace TestTask.Model
{
    /// <summary>
    ///     Модель класса Delivery. Этот класс нужен для создания какой либо логики. В данном случае здесь осуществляется
    ///     добавление данных в таблицу "поставки" в БД. С использованием паттерна "стратегия"
    /// </summary>
    internal class DeliveryModel
    {
        private DateTime DeliveryDateCreate = DateTime.UtcNow;
        private int SupplierId;

        private IDelivery ServiceDelivery;
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
