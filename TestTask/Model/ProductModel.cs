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
    ///     Модель класса Product. Этот класс нужен для создания какой либо логики. В данном случае здесь осуществляется
    ///     добавление данных в таблицу "продукты" в БД
    /// </summary>
    internal class ProductModel : IProductRepository
    {
        private DeliveriesContext _db;
        public ProductModel()
        {
            _db = new DeliveriesContext();
        }

        public void Create(string name, int productWeight, decimal productPrice, int deliveryId)
        {
            if (string.IsNullOrEmpty(name) || productWeight <= 0 || deliveryId < 0)
                throw new ArgumentException("Некорректные параметры для создания продукта.");

            _db.Products.Add(new Product() { ProductName = name, ProductWeight = productWeight, ProductPrice = productPrice, DeliveryId = deliveryId });
            _db.SaveChanges();
        }
    }
}
