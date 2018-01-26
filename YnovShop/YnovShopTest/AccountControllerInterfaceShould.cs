using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YnovShop.Data;
using YnovShop.Data.Entities;

namespace YnovShopTest
{
    [TestClass]
    public class AccountControllerInterfaceShould
    {
        private static IWebDriver _webDriver;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _webDriver = new ChromeDriver(@"C:\chromedriver");
        }

        [TestInitialize]
        public void SetUp()
        {
            CleanUserTest();
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
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();

            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");

            _webDriver.FindElement(By.Id("submit-login")).Submit();
        }

        [TestCleanup]
        public void CleanUserTest()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IUserRepository repository = new UserRepository(unitOfWork);
            YUser yuser = repository.GetByEmail("test.Selenium@gmail.com");
            if (yuser != null)
                repository.Delete(yuser);
        }


    }
}
