using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Provider;
namespace YnovShopTest
{

    [TestClass]
    public class SaltProviderShould
    {
        //private Mock<ISaltProvider> _salt;
        private string aSalt = "aHRsZ+K3NjvGW/3KKpmd47jji76hNHuJ";
        //private byte[] aSaltBytes;
        //private string aPassword = "azerty";
        //private string aPasswordHash = "V3/Odkzqnu1CGjxPDEK3bEsE2nQJuQhP";

        //private ISaltProvider _saltProvider;

        [TestInitialize]
        public void Init()
        {
           
        }

        [TestMethod]
        public void TestSaltProviderShouldReturnSaltBytes()
        {

            // Arrange
            var provider = new SaltProvider();
            var salt = System.Text.Encoding.Unicode.GetBytes(aSalt);

            // Act
            var saltResult = provider.GetSalt();

            // Assert
            Assert.AreEqual(aSalt, saltResult);
            //byte[] salt = _saltProvider.GetSalt();
            //var result = System.Text.Encoding.Unicode.GetBytes(aSalt);
            //_salt.Verify();

        }

        public SaltProviderShould()
        {
            //_salt = new Mock<ISaltProvider>();
            //aSaltBytes = System.Text.Encoding.Unicode.GetBytes(aSalt);
            //this._salt = new Mock<ISaltProvider>(MockBehavior.Strict);
            //this._salt.Setup(s => s.GetSalt()).Returns(aSaltBytes);
        }

    }
}
