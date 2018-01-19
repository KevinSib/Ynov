using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public interface IUserRepository : IRepositoryBase<YUser>
    {
        YUser GetById(int id);
    }
}
