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
    /// <summary>
    ///     Модель класса Supplier. Этот класс нужен для создания какой либо логики. В данном случае здесь осуществляется
    ///     добавление данных в таблицу "Supplier" в БД. А так же возвращается идентификатор только что созданного поставщика
    /// </summary>
    internal class SupplierModel : ISupplierRepository
    {
        private DeliveriesContext _db;
        public SupplierModel()
        {
            _db = new DeliveriesContext();
        }

        public int Create(string name)
        {
            if(name == null || name == "")
                throw new ArgumentException("Имя поставщика не указано");

            var newSupplier = new Supplier() { SupplierName = name };
            _db.Suppliers.Add(newSupplier);
            _db.SaveChanges();

            return newSupplier.Id;
        }
    }
}
