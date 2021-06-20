namespace CombatSimulatorLibrary.Interfaces
{
    public enum Purpose
    {
        Undefined,
        Shield,
        Weapon,
        Armor,
    }
    
    public interface IGear
    {
        #region Methods

        /// <summary>
        /// Sets the default sell value for an item.
        /// Formula: (10 * Cost) / 100
        /// </summary>
        public void SetSellValue()
        {
            SellValue = 10 * CostInCopper / 100;
        }
        
        #endregion Methods

        #region Properties

        int     CostInCopper { get; }
        string  Name         { get; }
        int     SellValue    { get; set; }
        bool    IsEquipped   { get; set; }
        int     Gold         { get; set; }
        int     Platinum     { get; set; }
        int     Silver       { get; set; }
        int     Copper       { get; set; }
        int?    Defense      { get; }
        Purpose Purpose      { get; }

        int SwingWeapon();

        string Display();

        #endregion Properties
    }
}