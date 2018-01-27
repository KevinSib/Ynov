using Microsoft.VisualStudio.TestTools.UnitTesting;
using YnovShop.Provider;

namespace YnovShopTest
{
    [TestClass]
    public class PasswordProviderShould
    {      
        private IPasswordProvider passwordProvider;
        private ISaltProvider saltProvider;

        [TestInitialize]
        public void Init()
        {
            passwordProvider = new PasswordProvider();
            saltProvider = new SaltProvider();
            
        }

        [TestMethod]
        public void returnNotTheSameStringInEnter()
        {
            var salt = saltProvider.GetSalt();
            var password = "PasswordOk";
            var passwordHash = passwordProvider.PasswordHash(password, salt);

            Assert.AreNotEqual(password,passwordHash);
           
        }

        [TestMethod]
        public void returnTrueIfTheInitialPasswordEqualTheHashedPassword()
        {
            var salt = saltProvider.GetSalt();
            var password = "PasswordOk";
            var passwordHash = passwordProvider.PasswordHash(password, salt);

            Assert.AreEqual(true, passwordProvider.Validate(password,salt,passwordHash));
        }

        [TestMethod]
        public void returnFalseIfTheInitialPasswordNotEqualTheHashedPassword()
        {
            var salt = saltProvider.GetSalt();
            var password = "PasswordOk";
            var passwordHash = passwordProvider.PasswordHash(password, salt);

            Assert.AreEqual(false, passwordProvider.Validate("randomPassword", salt, passwordHash));
        }
    }
}
