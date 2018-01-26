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

        public void CreateProduct(string name, string description, int stock, double? price)
        {
            YProduct yproduct = new YProduct();
            yproduct.Name = name;
            yproduct.Descritption = description;
            yproduct.Stock = stock;
            yproduct.Price = price;
            _productRepository.Insert(yproduct);
        }
       
    }
}
