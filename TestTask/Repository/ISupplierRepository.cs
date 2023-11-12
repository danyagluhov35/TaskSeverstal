using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository
{
    internal interface ISupplierRepository
    {
        int Create(string name);
    }
}
