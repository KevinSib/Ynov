using System.Threading.Tasks;
using YnovShop.Data.Entities;

namespace YnovShop.Business
{
    public enum LoginResult
    {
        Success,
        Failed,
        Disable,
        NotExists
    }

    public class LoginViewModel
    {
        public YUser User { get; set; }
        public LoginResult Result { get; set; }
    }

    public interface IUserService
    {
        void CreateUser(string name, string surname, string email, string password);
        LoginViewModel LoginUser(string email, string password);
    }
}
