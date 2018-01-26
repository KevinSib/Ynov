using System;
using YnovShop.Data.Entities;

namespace YnovShop.Business
{
    public interface IBasketService
    {
        void AddProductToBasket(YUser user, YProduct product);
        void ValideBasket(YUser user);
    }
}
