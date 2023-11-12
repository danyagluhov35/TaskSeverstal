using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Context;
using TestTask.Domain;
using TestTask.IService;

namespace TestTask.Service
{
    /// <summary>
    ///     Класс для добавления типа поставки. Является паттерном под названием "стратегия". В данном случае используется стратегия 
    ///     поставки через "почту"
    /// </summary>
    internal class PostDelivery : IDelivery
    {
        public void AddDelivery(Delivery delivery)
        {
            using (DeliveriesContext db = new())
            {
                delivery.TypeDeliveryId = 1;
                db.Deliveries.Add(delivery);
                db.SaveChanges();
            }
        }
    }
}
