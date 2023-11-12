using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.IService
{
    /// <summary>
    ///     Интерфейс для поиска продукта по идентификатору
    /// </summary>
    internal interface IFindProduct
    {
        Task<Product> Find(int id);
    }
}
