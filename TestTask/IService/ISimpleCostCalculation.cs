using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.IService
{
    internal interface ISimpleCostCalculation
    {
        decimal CalculateCost(int? weight, decimal? price);
    }
}
