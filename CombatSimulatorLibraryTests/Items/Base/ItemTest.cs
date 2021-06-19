using CombatSimulatorLibrary.Interfaces;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Base
{
    public class ItemTest : SetupTestFixture
    {
        private static void CurrencyTesting(IItem item)
        {
            item.ConvertCurrency();
            Assert.AreEqual(0, item.Copper);
            Assert.AreEqual(0, item.Silver);
            Assert.AreEqual(2, item.Gold);
            Assert.AreEqual(0, item.Platinum);
        }

        [Test]
        [Category("Currency Conversion")]
        public void ItemCurrencyConversionTest()
        {
            CurrencyTesting(Weapon);
            CurrencyTesting(Shield);
            CurrencyTesting(Armor);
        }
    }
}