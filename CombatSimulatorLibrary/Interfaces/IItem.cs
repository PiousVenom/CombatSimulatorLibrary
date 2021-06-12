namespace CombatSimulatorLibrary.Interfaces
{
    public interface IItem
    {
        #region Properties 

        string Name { get; set; }
        int Cost { get; set; }
        int SellValue { get; set; }
        bool IsEquipped { get; set; }

        #endregion Properties 

        #region Methods

        void SetSellValue();

        #endregion Methods
    }
}