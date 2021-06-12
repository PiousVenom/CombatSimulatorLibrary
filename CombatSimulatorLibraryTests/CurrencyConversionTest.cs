using CombatSimulatorLibrary.Items.Currency;
using CombatSimulatorLibrary.Persons;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests
{
    public class CurrencyConversionTest
    {
        [Test]
        public void ConversionTest()
        {
            var player = new Player
            {
                Copper = new Copper(){ Amount = 23}, 
                Silver = new Silver(){ Amount = 73 }, 
                Gold = new Gold(){ Amount = 43 }, 
                Platinum = new Platinum(){ Amount = 14 }
            };

            player.ConvertCurrency();

            Assert.AreEqual(3, player.Copper.Amount);
            Assert.AreEqual(5, player.Silver.Amount);
            Assert.AreEqual(0, player.Gold.Amount);
            Assert.AreEqual(19, player.Platinum.Amount);
        }
    }
}
