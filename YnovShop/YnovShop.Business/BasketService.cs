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

        public void ValideBasket(YUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var products = this._basketRepository.GetActiveBasketForUser(user);
            foreach (var product in products) 
            {
                product.PurchaseDate = DateTime.Now;

                this._basketRepository.Update(product);
            }
        }
    }
}
