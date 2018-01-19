using System;
using System.Threading.Tasks;

namespace YnovShop.Business
{
    public enum SignInResult
    {
        Succeed,
        Disable,
        Failed
    }

    public interface ISignManager
    {
        Task<SignInResult> SignInAsync(string email, string password);
        Task SignOutAsync();
    }
}
