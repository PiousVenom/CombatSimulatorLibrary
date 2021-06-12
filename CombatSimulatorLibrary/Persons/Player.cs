using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Persons
{
    public class Player : Person
    {
        #region Properties

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds experience points to the player.
        /// </summary>
        /// <param name="amountToAdd" type="int">Amount of experience points to add.</param>
        public void AddExperiencePoints(int amountToAdd) => CurrentExperiencePoints += amountToAdd;

        /// <summary>
        /// Converts all currency automagically.
        /// </summary>
        public override void ConvertCurrency()
        {
            Convert(Copper, Silver);
            Convert(Silver, Gold);
            Convert(Gold, Platinum);
        }

        private static void Convert(ICoin currentCoin, ICoin nextCoin)
        {
            currentCoin.ConvertCurrency(ref nextCoin);
        }

        #endregion Methods
    }
}
