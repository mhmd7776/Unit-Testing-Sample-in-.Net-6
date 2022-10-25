using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_InputPositiveDiscount_OutputPriceWithDiscount()
        {
            var product = new Product
            {
                Price = 1500,
                Id = 1,
                Name = "iPhone 13 Pro Max"
            };

            var result = product.GetProductPrice(new UserManager { UserDiscount = 20 });

            Assert.That(result, Is.EqualTo(1200.ToString("C")));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void GetProductPrice_InputNegativeOrZeroDiscount_OutputPrice(int amount)
        {
            var product = new Product
            {
                Price = 1500,
                Id = 1,
                Name = "iPhone 13 Pro Max"
            };

            var result = product.GetProductPrice(new UserManager { UserDiscount = amount });

            Assert.That(result, Is.EqualTo(1500.ToString("C")));
        }
    }
}
