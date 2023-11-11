using System;
using System.Collections.Generic;

namespace TestTask.Domain
{
    public partial class Delivery
    {
        public Delivery()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public DateTime? DeliveryDateCreate { get; set; }
        public int? SuppllierId { get; set; }
        public int? TypeDeliveryId { get; set; }

        public virtual Supplier? Suppllier { get; set; }
        public virtual TypeDelivery? TypeDelivery { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
