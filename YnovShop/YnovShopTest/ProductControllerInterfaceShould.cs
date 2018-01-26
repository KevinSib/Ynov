using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YnovShopTest
{
    [TestClass]
   public class ProductControllerInterfaceShould
    {
        private static IWebDriver _webDriver;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _webDriver = new ChromeDriver(@"C:\chromedriver");
        }

        [TestMethod]
        public void AddProduct()
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
    }
}
