using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.IService
{
    public interface IDelivery
    {
        int AddDelivery(Delivery delivery);
    }
}
