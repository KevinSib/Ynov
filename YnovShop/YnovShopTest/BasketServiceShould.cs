using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;
using YnovShop.Business.Exceptions;
using YnovShop.Data;
using YnovShop.Data.Entities;

namespace YnovShopTest
{
    [TestClass]
    public class BasketServiceShould
    {
        private Mock<IBasketRepository> _basketRepository;
        private IBasketService _basketService;

        [TestInitialize]
        public void Init()
        {
            this._basketRepository = new Mock<IBasketRepository>(MockBehavior.Strict);
            this._basketService = new BasketService(_basketRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserProvidedException))]
        public void ReturnExceptionIfUserIsNull()
        {
            this._basketService.AddProductToBasket(null, new YProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(NoProductProvidedException))]
        public void ReturnExceptionIfProductIsNull()
        {
            this._basketService.AddProductToBasket(new YUser(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(NoUserProvidedException))]
        public void ReturnExceptionIfValideBasketAsNullParameter()
        {
            this._basketService.ValideBasket(null);
        }

        [TestMethod]
        public void VerifyIfValideBasketIsSuccess()
        {
           IList<YProductPurchase> list = new List<YProductPurchase>();
            list.Add(new YProductPurchase() );
            this._basketRepository.Setup(s => s.Update(It.IsAny<YProductPurchase>()));
            this._basketRepository.Setup(s => s.GetActiveBasketForUser(It.IsAny<YUser>())).Returns(list);
            this._basketService.ValideBasket(new YUser());
            this._basketRepository.Verify(s => s.GetActiveBasketForUser(It.IsAny<YUser>()));
            this._basketRepository.Verify(s => s.Update(It.IsAny<YProductPurchase>()));
        }

        [TestMethod]
        public void VerifyIfAddProductToBasketIsSuccess()
        {
            this._basketRepository.Setup(s => s.Insert(It.IsAny<YProductPurchase>()));
            this._basketService.AddProductToBasket(new YUser(), new YProduct());
            this._basketRepository.Verify(s => s.Insert(It.IsAny<YProductPurchase>()));
        }
    }
}
