using KpatelsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KpatelsBooks.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category Category);
    }
}