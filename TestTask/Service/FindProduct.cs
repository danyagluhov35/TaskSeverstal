using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Context;
using TestTask.Domain;
using TestTask.IService;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Service
{
    /// <summary>
    ///     Класс для поиска в таблице Product по Id
    /// </summary>
    internal class FindProduct : IFindProduct
    {
        private DeliveriesContext _db;
        public FindProduct()
        {
            _db = new DeliveriesContext();
        }

        public async Task<Product> Find(int id)
        {
            using (_db)
            {
                var data = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (data == null)
                    throw new ArgumentException("Данные о продукте не были найдены");
                return data;
            }
        }
    }
}
