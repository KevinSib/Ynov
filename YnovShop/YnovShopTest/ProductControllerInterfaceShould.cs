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
            //Access to the page
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
            _webDriver.FindElement(By.Id("nav-bar-connexion-account")).Click();
            _webDriver.FindElement(By.Id("login-Email")).SendKeys("test.Selenium@gmail.com");
            _webDriver.FindElement(By.Id("login-password")).SendKeys("Selenium");
            _webDriver.FindElement(By.Id("submit-login")).Submit();

            //Add product
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
            _webDriver.FindElement(By.Id("btn-seeDetails-3"));
        }
    }
}
