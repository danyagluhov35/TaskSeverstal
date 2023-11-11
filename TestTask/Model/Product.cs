using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int? ProductWeight { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? DeliveryId { get; set; }

        public virtual Delivery? Delivery { get; set; }
    }
}
