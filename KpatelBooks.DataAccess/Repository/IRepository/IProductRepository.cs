using KpatelsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KpatelsBooks.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
