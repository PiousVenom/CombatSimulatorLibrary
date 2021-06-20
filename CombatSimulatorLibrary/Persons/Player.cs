using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Persons
{
    public class Player : Person,
                          ICommon
    {
        public Player(
                string name,
                int    level,
                int    maxHitPoints
            )
            : base(name, level, maxHitPoints)
        {
            CurrentExperiencePoints = 0;
            CurrentHitPoints        = maxHitPoints;
            CoinsInCopper           = 0;
        }

        #region Properties

        /// <summary>
        /// Current experience points for the player.
        /// </summary>
        public int CurrentExperiencePoints { get; private set; }

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
        /// <returns type="bool">Returns a true/false. A false return means there wasn't enough coin to remove.</returns>
        public bool RemoveCoins(int amountToRemove)
        {
            var temp = CoinsInCopper;

            CoinsInCopper -= amountToRemove;

            if(CoinsInCopper >= 0)
            {
                return true;
            }

            CoinsInCopper = temp;

            return false;
        }

        #endregion Methods
    }
}