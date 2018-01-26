using System;
using YnovShop.Data;
using YnovShop.Data.Entities;

namespace YnovShop.Business
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        public void AddProductToBasket(YUser user, YProduct product)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            YProductPurchase productPurchase = new YProductPurchase()
            {
                IdYuser = user.Id,
                IdYproduct = product.Id
            };

            this._basketRepository.Insert(productPurchase);
        }

        public void ValideBasket(YUser user, YProduct product)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var basket = this._basketRepository.GetBasketForUserAndProduct(user, product);

            if (basket != null)
            {
                basket.PurchaseDate = DateTime.Now;

                this._basketRepository.Update(basket);
            }

            throw new ArgumentNullException(nameof(basket));
        }
    }
}
