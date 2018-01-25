using System.Threading.Tasks;

namespace YnovShop.Business
{
    public enum LoginResult
    {
        Success,
        Failed,
        Disable,
        NotExists
    }

    public interface IUserService
    {
        void CreateUser(string name, string surname, string email, string password);
        LoginResult LoginUser(string email, string password);
    }
}
