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
    public class ProductServiceShould
    {
        private Mock<IProductRepository> _productRepository;
        private IProductService _productService;

        [TestInitialize]
        public void Init()
        {
            this._productRepository = new Mock<IProductRepository>(MockBehavior.Strict);
            this._productService = new ProductService(_productRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NoNameProvidedException))]
        public void ReturnExceptionIfNameIsNull()
        {
            this._productService.CreateProduct(null, "", 100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(NoDescriptionProvidedException))]
        public void ReturnExceptionIfDescriptionIsNull()
        {
            this._productService.CreateProduct("Nom", null, 100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(StockIsEqualOrLessThanZeroException))]
        public void ReturnExceptionIfStockIsEqualTo0()
        {
            this._productService.CreateProduct("Nom", "Description", 0, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(StockIsEqualOrLessThanZeroException))]
        public void ReturnExceptionIfStockIsLessThan0()
        {
            this._productService.CreateProduct("Nom", "Description", -3, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(PriceIsEqualOrLessThanZeroException))]
        public void ReturnExceptionIfPriceIsEqualTo0()
        {
            this._productService.CreateProduct("Nom", "Description", 100, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(PriceIsEqualOrLessThanZeroException))]
        public void ReturnExceptionIfPriceIsLessThan0()
        {
            this._productService.CreateProduct("Nom", "Description", 100, -12);
        }

        [TestMethod]
        public void VerifyIfCreateProductIsSuccess()
        {
            this._productRepository.Setup(s => s.Insert(It.IsAny<YProduct>()));
            this._productService.CreateProduct("testname","testdescription",1,10.5);
            this._productRepository.Verify(s => s.Insert(It.IsAny<YProduct>()));
        }
    }
}
