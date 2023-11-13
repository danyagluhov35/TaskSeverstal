using Microsoft.EntityFrameworkCore;
using TestTask.Domain;
using TestTask.Domain.Context;
using TestTask.IService;
using TestTask.Model;
using TestTask.Service;


try
{
    SupplierModel alex = new SupplierModel();
    var alexId = alex.Create("Alex");
    SupplierModel bob = new SupplierModel();
    var bobId = bob.Create("Bob");
    SupplierModel bart = new SupplierModel();
    var bartId = bart.Create("Bart");


    DeliveryModel delivery1 = new(alexId, new PostDelivery());
    var delivery1Id = delivery1.AddDelivery();

    DeliveryModel delivery2 = new(bobId, new AirDelivery());
    var delivery2Id = delivery2.AddDelivery();

    DeliveryModel delivery3 = new(bartId, new PostDelivery());
    var delivery3Id = delivery3.AddDelivery();


    ProductModel apple1 = new();
    apple1.Create("Яблоко-1", 50, 500, delivery1Id);
    apple1.Create("Яблоко-1", 70, 700, delivery2Id);
    apple1.Create("Яблоко-1", 10, 300, delivery3Id);
    ProductModel apple2 = new();
    apple2.Create("Яблоко-2", 5, 300, delivery1Id);
    apple2.Create("Яблоко-2", 10, 400, delivery2Id);
    apple2.Create("Яблоко-2", 20, 350, delivery3Id);

    ProductModel pear1 = new();
    pear1.Create("Груша-1", 7, 150, delivery1Id);
    pear1.Create("Груша-1", 8, 200, delivery2Id);
    pear1.Create("Груша-1", 10, 230, delivery3Id);
    ProductModel pear2 = new();
    pear2.Create("Груша-2", 11, 375, delivery1Id);
    pear2.Create("Груша-2", 15, 190, delivery2Id);
    pear2.Create("Груша-2", 18, 555, delivery3Id);

    Report report = new Report();
    report.GenerateReport();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}





/// <summary>
///     Класс который генерирует отчет по поставкам, поставщикам, и продуктам
/// </summary>
public class Report
{
    private DeliveriesContext _db;
    private ISimpleCostCalculation CostCalculation;
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