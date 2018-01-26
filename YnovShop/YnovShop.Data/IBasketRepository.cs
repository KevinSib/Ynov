using System;
using System.Collections.Generic;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public interface IBasketRepository : IRepositoryBase<YProductPurchase>
    {
        YProductPurchase GetBasketForUserAndProduct(YUser user, YProduct product);
        IList<YProductPurchase> GetBasketForUser(YUser user);
        IList<YProductPurchase> GetActiveBasketForUser(YUser user);
        IList<YProductPurchase> GetInactiveForUser(YUser user);
    }
}
