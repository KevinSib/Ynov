﻿using System;
using System.Collections.Generic;
using System.Linq;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public class ProductRepository : RepositoryBase<YProduct>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<YProduct> GetAvailableProducts()
        {
            return this.Get(p => p.Stock > 0, null, 0, 1).ToList();
        }

        public YProduct GetById(int id)
        {
            return this.Get(u => u.Id == id, null, 0, 1).Single();
        }

        public YProduct GetBySearch(string searchString)
        {
            return this.Get(p => p.Name.Contains(searchString) || p.Descritption.Contains(searchString), null, 0, 1).Single();
        }

        public bool Exists(int id)
        {
            return GetById(id) != null;
        }
    }
}
