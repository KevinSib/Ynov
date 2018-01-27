using System;
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
            this._basketService.AddProductToBasket(null, new YnovShop.Data.Entities.YProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(NoProductProvidedException))]
        public void ReturnExceptionIfProductIsNull()
        {
            this._basketService.AddProductToBasket(new YnovShop.Data.Entities.YUser(), null);
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
            this._basketRepository.Setup(s => s.Update(It.IsAny<YProductPurchase>()));
            this._basketService.ValideBasket(new YnovShop.Data.Entities.YUser());
            this._basketRepository.Verify(s => s.Update(It.IsAny<YProductPurchase>()));
        }
    }
}
