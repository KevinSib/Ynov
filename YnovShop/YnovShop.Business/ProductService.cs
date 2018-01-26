using System;
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
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            if (stock <= 0)
                throw new Exception("Stock must be higher than 0");

            if (price <= 0)
                throw new Exception("Price must be higher than 0");
                
            YProduct yproduct = new YProduct();
            yproduct.Name = name;
            yproduct.Descritption = description;
            yproduct.Stock = stock;
            yproduct.Price = price;

            _productRepository.Insert(yproduct);
        }
       
    }
}
