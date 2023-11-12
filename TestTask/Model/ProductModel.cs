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
    internal class ProductModel : IProductRepository
    {
        private DeliveriesContext _db;
        public ProductModel()
        {
            _db = new DeliveriesContext();
        }

        public void Create(string name, int productWeight, decimal productPrice, int deliveryId)
        {
            _db.Products.Add(new Product() { ProductName = name, ProductWeight = productWeight, ProductPrice = productPrice, DeliveryId = deliveryId });
            _db.SaveChanges();
        }
    }
}
