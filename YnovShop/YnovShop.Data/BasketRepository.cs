using System;
using System.Collections.Generic;
using System.Linq;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public class BasketRepository: RepositoryBase<YProductPurchase>, IBasketRepository
    {
        public BasketRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public YProductPurchase GetBasketForUserAndProduct(YUser user, YProduct product)
        {
            return this.Get(u => u.IdYuser == user.Id && u.IdYproduct == product.Id, null, 0, 1).Single();
        }

        public IList<YProductPurchase> GetBasketForUser(YUser user)
        {
            return this.Get(u => u.IdYuser == user.Id, null, 0, null).ToList();
        }

        public IList<YProductPurchase> GetActiveBasketForUser(YUser user)
        {
            return this.Get(b => b.IdYuser == user.Id && b.PurchaseDate == null, null, 0, null).ToList();
        }

        public IList<YProductPurchase> GetInactiveForUser(YUser user)
        {
            return this.Get(b => b.IdYuser == user.Id && b.PurchaseDate != null, null, 0, null).ToList();
        }
    }
}
