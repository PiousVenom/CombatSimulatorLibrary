using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.CommonClasses;

namespace CombatSimulatorLibrary.Persons
{
    public class Player : Person
    {
        public Player(
                string name,
                int level,
                int maxHitPoints
            ): base(name, level, maxHitPoints)
        {
            CurrentExperiencePoints = 0;
            CurrentHitPoints = maxHitPoints;
            CoinsInCopper = 0;
        }

        #region Properties

        /// <summary>
        /// Players coins in copper. Can be converted to other types using the ConvertCurrency().
        /// </summary>
        public int CoinsInCopper { get; set; }
        /// <summary>
        /// Current experience points for the player.
        /// </summary>
        public int CurrentExperiencePoints { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds experience points to the player.
        /// </summary>
        /// <param name="amountToAdd" type="int">Amount of experience points to add.</param>
        public void AddExperiencePoints(int amountToAdd) => CurrentExperiencePoints += amountToAdd;

        /// <summary>
        /// Adds coins to the player
        /// </summary>
        /// <param name="amountToAdd" type="int">Amount of copper coins to add to the player.</param>
        public void AddCoins(int amountToAdd) => CoinsInCopper += amountToAdd;

        /// <summary>
        /// Removes coins from the player
        /// </summary>
        /// <param name="amountToRemove" type="int">Amount of copper coins to remove from the player.</param>
        public void RemoveCoins(int amountToRemove)
        {
            CoinsInCopper -= amountToRemove;

            if (CoinsInCopper < 0)
            {
                CoinsInCopper = 0;
            }
        }

        /// <summary>
        /// Converts all currency automagically.
        /// </summary>
        public void ConvertCurrency()
        {
            var common = new CommonMethods(CoinsInCopper);
            var coins = common.ConvertCurrency();

            Copper = coins.Item1;
            Silver = coins.Item2;
            Gold = coins.Item3;
            Platinum = coins.Item4;
        }

        #endregion Methods
    }
}
