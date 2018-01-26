using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YnovShopTest
{
    [TestClass]
    public class BasketControllerInterfaceShould
    {
        private static IWebDriver _webDriver;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _webDriver = new ChromeDriver(@"C:\chromedriver");
        }

        [TestMethod]
        public void SeeBasket()
        {
            
        }
    }
}
