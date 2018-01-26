namespace YnovShop.Business
{
    public interface IProductService
    {
        void CreateProduct(string name, string description, int stock, double price);

    }
}