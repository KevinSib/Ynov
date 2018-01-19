using System;
using System.Threading.Tasks;

namespace YnovShop.Business
{
    public class SignManager : ISignManager
    {
        public async Task<SignInResult> SignInAsync(string email, string password)
        {
            return await Task.Run(() => 
            {
                return SignInResult.Failed;
            });
        }

        public async Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
