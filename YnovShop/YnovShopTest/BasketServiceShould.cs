using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;
using YnovShop.Data;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnExceptionIfUserIsNull()
        {
            this._basketService.AddProductToBasket(null, new YnovShop.Data.Entities.YProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnExceptionIfProductIsNull()
        {
            this._basketService.AddProductToBasket(new YnovShop.Data.Entities.YUser(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnExceptionIfValideBasketAsNullParameter()
        {
            this._basketService.ValideBasket(null);
        }
    }
}
