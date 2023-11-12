using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.IService;

namespace TestTask.Service
{
    /// <summary>
    ///     Класс для расчета стоимости одного киллограмма продукта
    /// </summary>
    internal class SimpleCostCalculation : ISimpleCostCalculation
    {
        public decimal CalculateCost(int? weight, decimal? price)
        {
            if (weight == 0 || weight < 0)
                throw new ArgumentException($"Вес не может быть равным 0 или отрицательным");
            if (price == null)
                throw new ArgumentException("Цена не определена");

            return (decimal)(price / weight)!;
        }
    }
}
