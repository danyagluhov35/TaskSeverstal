using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class TypeDelivery
    {
        public TypeDelivery()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        public string? TypeDeliveryName { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
