using CombatSimulatorLibrary.Items;
using NUnit.Framework;

namespace CombatSimulatorLibrary.Tests
{
    [TestFixture]
    public class AmorTest
    {
        [SetUp]
        protected void Setup()
        {
            
        }

        [Test]
        public void SetSellValueTest()
        {
            var plate = new Armor
            {
                Cost = 50
            };
            plate.SetSellValue();

            Assert.That(plate.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(17, plate.SellValue);
        }
    }
}