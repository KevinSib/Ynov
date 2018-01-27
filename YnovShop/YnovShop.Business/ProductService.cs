using System;
using YnovShop.Business.Exceptions;
using YnovShop.Data;
using YnovShop.Data.Entities;

namespace YnovShop.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public void CreateProduct(string name, string description, int stock, double price)
        {
            if (string.IsNullOrEmpty(name))
                throw new NoNameProvidedException();

            if (string.IsNullOrEmpty(description))
                throw new NoDescriptionProvidedException();

            if (stock <= 0)
                throw new StockIsEqualOrLessThanZeroException();

            if (price <= 0)
                throw new PriceIsEqualOrLessThanZeroException();
                
            YProduct yproduct = new YProduct();
            yproduct.Name = name;
            yproduct.Descritption = description;
            yproduct.Stock = stock;
            yproduct.Price = price;

            _productRepository.Insert(yproduct);
        }
       
    }
}
