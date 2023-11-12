using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository
{
    /// <summary>
    ///     Интерфейс ISupplierRepository является паттерном под названием "Repository". Который содержит в основном CRUD операции.
    ///     Т.е удаление,добавление,редактирование, чтение
    /// </summary>
    internal interface ISupplierRepository
    {
        int Create(string name);
    }
}
