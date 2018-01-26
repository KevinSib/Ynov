using System;
using System.Collections.Generic;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public interface IProductRepository : IRepositoryBase<YProduct>
    {
        IList<YProduct> GetAvailableProducts();
        YProduct GetById(int id);
        YProduct GetBySearch(string searchString);
        bool Exists(int id);
    }
}
