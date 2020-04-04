namespace CombatSimulatorLibrary.Interfaces
{
    public interface IItem
    {
        #region Properties

        string Name { get; set; }
        string Purpose { get; set; }
        int Cost { get; set; }
        int SellValue { get; set; }

        #endregion Properties

        #region Methods

        void SetSellValue();

        #endregion Methods
    }
}