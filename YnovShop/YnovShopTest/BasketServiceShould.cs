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
    }
}
