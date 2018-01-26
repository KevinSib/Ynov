using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YnovShop.Business;
using YnovShop.Data;
using YnovShop.Data.Entities;
using YnovShop.Provider;

namespace YnovShopTest
{
    [TestClass]
    public class AccountControllerInterfaceShould
    {
        private static IWebDriver _webDriver;

        private static IUnitOfWork _unitOfWork;
        private static IUserRepository _repository;
        private static ISaltProvider _saltProvider;
        private static IPasswordProvider _passwordProvider;
        private static IUserService _userService;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _webDriver = new ChromeDriver(@"C:\chromedriver");

            _unitOfWork = new UnitOfWork();
            _repository = new UserRepository(_unitOfWork);
            _saltProvider = new SaltProvider();
            _passwordProvider = new PasswordProvider();
            _userService = new UserService(_repository, _saltProvider, _passwordProvider);

        }

        [TestInitialize]
        public void SetUp()
        {

            YUser yuser = _repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser != null)
                _repository.Delete(yuser);
        }

        [TestMethod]
        public void AddUser()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-create-account")).Click();

            _webDriver.FindElement(By.Id("register-firstname")).SendKeys("SeleniumFirstname");
            _webDriver.FindElement(By.Id("register-lastname")).SendKeys("SeleniumLastname");
            _webDriver.FindElement(By.Id("register-email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("register-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("register-confirm-password")).SendKeys("Selenium");

            _webDriver.FindElement(By.Id("register-submit")).Submit();

        }


        [TestMethod]
        public void LogIn()
        {
            YUser yuser = _repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser == null)
                _userService.CreateUser("SeleniumFirstname", "SeleniumLastname", "test.Selenium@gmail.com", "Selenium");


            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();

            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");

            _webDriver.FindElement(By.Id("submit-login")).Submit();
        }

        [TestMethod]
        public void LogOut()
        {

            YUser yuser = _repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser == null)
                _userService.CreateUser("SeleniumFirstname", "SeleniumLastname", "test.Selenium@gmail.com", "Selenium");

            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();

            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");

            _webDriver.FindElement(By.Id("submit-login")).Submit();

            _webDriver.FindElement(By.Id("nav-bar-logout")).Click();
        }
    }
}
