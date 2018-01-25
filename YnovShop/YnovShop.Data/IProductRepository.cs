using System;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public interface IProductRepository : IRepositoryBase<YProduct>
    {
        YProduct GetById(int id);
        YProduct GetBySearch(string searchString);
        bool Exists(int id);
    }
}
