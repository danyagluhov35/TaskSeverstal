using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.IService
{
    /// <summary>
    ///     Интерфейс для расчета стоимости за один киллограм продукта
    /// </summary>
    internal interface ISimpleCostCalculation
    {
        decimal CalculateCost(int? weight, decimal? price);
    }
}
