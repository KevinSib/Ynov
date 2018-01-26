using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;
using YnovShop.Data;
using YnovShop.Provider;

namespace YnovShopTest
{
    [TestClass]
    public class UserServiceShould
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<ISaltProvider> _saltProvider;
        private Mock<IPasswordProvider> _passwordProvider;
        private IUserService userService;

        [TestInitialize]
        public void Init()
        {

            _userRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            _saltProvider = new Mock<ISaltProvider>(MockBehavior.Strict);
            _passwordProvider = new Mock<IPasswordProvider>(MockBehavior.Strict);
            userService = new UserService(_userRepository.Object, _saltProvider.Object, _passwordProvider.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void returnExceptionIfPasswordIsEmpty()
        {
            userService.CreateUser("", "", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void returnExceptionIfPasswordIsNull()
        {
            userService.CreateUser("", "", "", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void returnExceptionIfEmailsNull()
        {
            userService.CreateUser("", "", null, "erer");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void returnExceptionIfEmailIsEmpty()
        {
            userService.CreateUser("", "", "", "rer");
        }
    }
}
