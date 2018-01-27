using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;
using YnovShop.Business.Exceptions;
using YnovShop.Data;
using YnovShop.Data.Entities;
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
            _saltProvider.Setup(sp => sp.GetSalt()).Returns(Convert.FromBase64String("aaaazzzzaaaazzzz"));
            _passwordProvider.Setup(pp => pp.PasswordHash(It.IsAny<string>(), It.IsAny<Byte[]>()))
                .Returns(Convert.FromBase64String("aaaazzzzaaaazzzz"));
            userService = new UserService(_userRepository.Object, _saltProvider.Object, _passwordProvider.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPasswordProvidedException))]
        public void returnExceptionIfPasswordIsEmpty()
        {
            userService.CreateUser("", "", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(NoPasswordProvidedException))]
        public void returnExceptionIfPasswordIsNull()
        {
            userService.CreateUser("", "", "", null);
        }

        [TestMethod]
        [ExpectedException(typeof(NoEmailProvidedException))]
        public void returnExceptionIfEmailsNull()
        {
            userService.CreateUser("", "", null, "erer");
        }

        [TestMethod]
        [ExpectedException(typeof(NoEmailProvidedException))]
        public void returnExceptionIfEmailIsEmpty()
        {
            userService.CreateUser("", "", "", "rer");
        }

        [TestMethod]
        public void VerifyIfCerrateUSerIsSuccess()
        {
            _userRepository.Setup(us => us.Insert(It.IsAny<YUser>()));
           userService.CreateUser("ezrzer","rezr","azer","rzerz");
            _userRepository.Verify(s => s.Insert(It.IsAny<YUser>()));
        }
    }
}
