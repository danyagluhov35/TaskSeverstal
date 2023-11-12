using Microsoft.EntityFrameworkCore;
using TestTask.Domain;
using TestTask.Domain.Context;
using TestTask.IService;
using TestTask.Model;
using TestTask.Service;









public class Report
{
    private DeliveriesContext _db;
    ISimpleCostCalculation CostCalculation;
    public Report()
    {
        _db = new DeliveriesContext();
        CostCalculation = new SimpleCostCalculation();
    }
    public void GenerateReport()
    {
        var productInfo = from product in _db.Products
                          join delivery in _db.Deliveries on product.DeliveryId equals delivery.Id
                          join supplier in _db.Suppliers on delivery.SuppllierId equals supplier.Id
                          join typeDelivery in _db.TypeDeliveries on delivery.TypeDeliveryId equals typeDelivery.Id
                          group product by new { supplier.SupplierName, typeDelivery.TypeDeliveryName } into g
                          select new
                          {
                              SupplierName = g.Key.SupplierName,
                              TypeDeliveryName = g.Key.TypeDeliveryName,
                              DeliveryDateCreate = g.FirstOrDefault()!.Delivery!.DeliveryDateCreate,
                              Products = g.Select(p => new
                              {
                                  ProductName = p.ProductName,
                                  ProductWeight = p.ProductWeight,
                                  ProductPrice = p.ProductPrice,
                                  SimpleCost = CostCalculation.CalculateCost(p.ProductWeight, p.ProductPrice)
                              })
                          };

        foreach(var item in productInfo)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Поставщик: {item.SupplierName} || Способ поставки: {item.TypeDeliveryName} || Дата создания поставки:{item.DeliveryDateCreate}");
            foreach(var products in item.Products)
            {
                Console.WriteLine($"Название продукта:{products.ProductName} || Общий вес:{products.ProductWeight} || Общая цена:{Math.Round(products.ProductPrice)} || Цена за килограмм продукта:{Math.Round(products.SimpleCost)}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        }
    }
}