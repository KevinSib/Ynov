using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Business;

namespace YnovShopTest
{
    [TestClass]
    public class AccountControllerShould
    {
        private AccountControllerShould _controller;
        private Mock<IUserService> _userServiceMock;

        [TestInitialize]
        public void Init()
        {
            _userServiceMock = new Mock<IUserService>(MockBehavior.Strict);
            // _controller  = new AccountController(_userServiceMock.Object);

        }

        [TestMethod]
        public void Register_ReturnBadRequestIsModelInvalid()
        {

            //Act
            //var result = _controller.Register_ReturnBadRequestIsModelNotValid();
            //var result = _controller.Register(new RegisterModel)

            //Arrange
            // var badRequestResult = Assert. 
            //Assert.IsNotNull(result);
        }
    }
}
