using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Context;
using TestTask.Domain;
using TestTask.Repository;

namespace TestTask.Model
{
    internal class SupplierModel : ISupplierRepository
    {
        private DeliveriesContext _db;
        public SupplierModel()
        {
            _db = new DeliveriesContext();
        }

        public void Create(string name)
        {
            _db.Suppliers.Add(new Supplier() { SupplierName = name });
            _db.SaveChanges();
        }
    }
}
