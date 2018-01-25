using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YnovShop.Provider;
namespace YnovShopTest
{


    [TestClass]
    public class SaltProviderShould
    {
        private Mock<ISaltProvider> _salt;
        private string aSalt = "aHRsZ+K3NjvGW/3KKpmd47jji76hNHuJ";
        private string aPassword = "azerty";
        private string aPasswordHash = "V3/Odkzqnu1CGjxPDEK3bEsE2nQJuQhP";

        private ISaltProvider _saltProvider;


        public SaltProviderShould()
        {
            //_salt = new Mock<ISaltProvider>();
            this._salt = new Mock<ISaltProvider>(MockBehavior.Strict);
            //this._salt.Setup(s => s.GetSalt());
        }

        [TestInitialize]
        public void Init()
        {
           
        }

        [TestMethod]
        public void TestSaltProviderShouldReturnSaltBytes()
        {
            byte[] salt = _saltProvider.GetSalt();
            var result = System.Text.Encoding.Unicode.GetBytes(aSalt);
            Assert.AreEqual(result,salt);
            //_salt.Verify();

        }


    }
}
