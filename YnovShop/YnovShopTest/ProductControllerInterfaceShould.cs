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
   public class ProductControllerInterfaceShould
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

        [TestMethod]
        public void CreateProduct()
        {
            //Access to the website
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-create-account")).Click();

            //Send data to the form to create an account
            _webDriver.FindElement(By.Id("register-firstname")).SendKeys("SeleniumFirstname");
            _webDriver.FindElement(By.Id("register-lastname")).SendKeys("SeleniumLastname");
            _webDriver.FindElement(By.Id("register-email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("register-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("register-confirm-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("register-submit")).Submit();

            //Login
            YUser yuser = _repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser == null)
                _userService.CreateUser("SeleniumFirstname", "SeleniumLastname", "test.Selenium@gmail.com", "Selenium");
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();
            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("submit-login")).Submit();

            //Create product
            _webDriver.FindElement(By.Id("nav-bar-product")).Click();
            _webDriver.FindElement(By.Id("product-name")).SendKeys("SeleniumProductName");
            _webDriver.FindElement(By.Id("product-description")).SendKeys("SeleniumProductDescription");
            _webDriver.FindElement(By.Id("product-stock")).SendKeys("5");
            _webDriver.FindElement(By.Id("product-price")).SendKeys("12.50");
            _webDriver.FindElement(By.Id("product-submit")).Submit();
        }

        [TestMethod]
        public void SeeDetails()
        {
            _webDriver.FindElement(By.Id("btn-seeDetails-1"));
        }

        [TestMethod]
        public void AddProductInBasket()
        {
            //Access to the website
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-create-account")).Click();

            //Send data to the form to create an account
            _webDriver.FindElement(By.Id("register-firstname")).SendKeys("SeleniumFirstname");
            _webDriver.FindElement(By.Id("register-lastname")).SendKeys("SeleniumLastname");
            _webDriver.FindElement(By.Id("register-email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("register-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("register-confirm-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("register-submit")).Submit();

            //Login
            YUser yuser = _repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser == null)
                _userService.CreateUser("SeleniumFirstname", "SeleniumLastname", "test.Selenium@gmail.com", "Selenium");
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();
            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("submit-login")).Submit();

            //Create product
            _webDriver.FindElement(By.Id("nav-bar-product")).Click();
            _webDriver.FindElement(By.Id("product-name")).SendKeys("SeleniumProductName");
            _webDriver.FindElement(By.Id("product-description")).SendKeys("SeleniumProductDescription");
            _webDriver.FindElement(By.Id("product-stock")).SendKeys("5");
            _webDriver.FindElement(By.Id("product-price")).SendKeys("12.50");
            _webDriver.FindElement(By.Id("product-submit")).Submit();

            //Add product in the basket
            _webDriver.FindElement(By.Id("btn-product-addBasket-1")).Submit();
        }


    }
}
