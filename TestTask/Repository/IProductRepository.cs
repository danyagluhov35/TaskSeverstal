using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository
{
    /// <summary>
    ///     Интерфейс IProductRepository является паттерном под названием "Repository". Который содержит в основном CRUD операции.
    ///     Т.е удаление,добавление,редактирование, чтение
    /// </summary>
    internal interface IProductRepository
    {
        void Create(string name, int productWeight, decimal productPrice, int deliveryId);
    }
}
