using System.Linq;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public class UserRepository : RepositoryBase<YUser>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public YUser GetById(int id)
        {
            return this.Get(u => u.Id == id, null, 0, 1).Single();
        }
    }
}
