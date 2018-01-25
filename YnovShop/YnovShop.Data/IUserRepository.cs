using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public interface IUserRepository : IRepositoryBase<YUser>
    {
        YUser GetById(int id);
        YUser GetByEmail(string email);
        bool Exists(int id);
    }
}
