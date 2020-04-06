using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.Items;

namespace CombatSimulatorLibrary.Persons
{
    public class Player : Person
    {
        #region Properties

        /// <summary>
        /// How many experience points the player has.
        /// </summary>
        public int CurrentExperiencePoints {get;set; }
        /// <summary>
        /// How many gold pieces the player has.
        /// </summary>
        public int GoldPieces {get;set;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds experience points to the player.
        /// </summary>
        /// <param name="amountToAdd" type="int">Amount of experience points to add.</param>
        public void AddExperiencePoints(int amountToAdd) => CurrentExperiencePoints += amountToAdd;

        /// <summary>
        /// Adds gold pieces to the player.
        /// </summary>
        /// <param name="amountToAdd" type="int">Amount of gold pieces to give the player.</param>
        public void AddGoldPieces(int amountToAdd) => GoldPieces += amountToAdd;

        /// <summary>
        /// Removes gold pieces from the player.
        /// </summary>
        /// <param name="amountToRemove" type="int">Amount of gold pieces to remove from the player.</param>
        public void RemoveGoldPieces(int amountToRemove) => GoldPieces -= amountToRemove;

        #endregion Methods
    }
}
