using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.IService
{
    /// <summary>
    ///     Интерфейс для добавления поставок
    /// </summary>
    public interface IDelivery
    {
        void AddDelivery(Delivery delivery);
    }
}
