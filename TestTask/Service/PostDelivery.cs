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
    internal class PostDelivery : IDelivery
    {
        public void AddDelivery(Delivery delivery)
        {
            using (DeliveriesContext db = new())
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
            }
        }
    }
}
