using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;
using YnovShop.Data;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnExceptionIfNameIsNull()
        {
            this._productService.CreateProduct(null, "", 100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnExceptionIfDescriptionIsNull()
        {
            this._productService.CreateProduct("Nom", null, 100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnExceptionIfStockIsEqualTo0()
        {
            this._productService.CreateProduct("Nom", "Description", 0, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnExceptionIfStockIsLessThan0()
        {
            this._productService.CreateProduct("Nom", "Description", -3, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnExceptionIfPriceIsEqualTo0()
        {
            this._productService.CreateProduct("Nom", "Description", 100, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReturnExceptionIfPriceIsLessThan0()
        {
            this._productService.CreateProduct("Nom", "Description", 100, -12);
        }
    }
}
