﻿using System;
using YnovShop.Business.Exceptions;
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
                throw new NoUserProvidedException();

            if (product == null)
                throw new NoProductProvidedException();

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
                throw new NoUserProvidedException();

            var products = this._basketRepository.GetActiveBasketForUser(user);
            foreach (var product in products) 
            {
                product.PurchaseDate = DateTime.Now;

                this._basketRepository.Update(product);
            }
        }
    }
}
