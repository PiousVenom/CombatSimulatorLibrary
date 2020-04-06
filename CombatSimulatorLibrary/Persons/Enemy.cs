using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.Items;

namespace CombatSimulatorLibrary.Persons
{
    public class Enemy : Person
    {
        #region Properties

        /// <summary>
        /// How many experience points that the player gets for beating this enemy.
        /// </summary>
        public int ExperiencePointValue { get; set; }
        /// <summary>
        /// How many gold pieces the player gets for beating this enemy.
        /// </summary>
        public int GoldPieceValue { get;set; }

        #endregion Properties

        #region Methods



        #endregion Methods
    }
}
