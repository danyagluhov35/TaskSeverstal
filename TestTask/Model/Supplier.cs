using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int Id { get; set; }
        public string? SupplierName { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
