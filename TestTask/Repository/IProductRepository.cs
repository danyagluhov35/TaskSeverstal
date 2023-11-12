using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository
{
    internal interface IProductRepository
    {
        void Create(string name, int productWeight, decimal productPrice, int deliveryId);
    }
}
