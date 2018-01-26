using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YnovShopTest
{
    [TestClass]
    public class HomeControllerInterfaceShouldcs
    {
        private static IWebDriver _webDriver;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _webDriver = new ChromeDriver(@"C:\chromedriver");
        }

        [TestMethod]
        public void NavBarHome()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-home")).Click();
        }

        [TestMethod]
        public void NevBarAbout()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:50295");
            _webDriver.FindElement(By.Id("nav-bar-about")).Click();
        }
    }
}