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

        public int Create(string name)
        {
            var newSupplier = new Supplier() { SupplierName = name };
            _db.Suppliers.Add(newSupplier);
            _db.SaveChanges();

            return newSupplier.Id;
        }
    }
}
