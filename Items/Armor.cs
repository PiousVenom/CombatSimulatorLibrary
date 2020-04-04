using System;
using System.Collections.Generic;
using System.Text;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items
{
    internal class Armor : IItem
    {
        #region Properties

        public string Name { get; set; }
        public string Purpose { get; set; }
        public int Cost { get; set; }
        public int SellValue { get; set; }

        #endregion Properties

        #region Methods

        public void SetSellValue()
        {
            var tempNumber = 35 * Cost;
            SellValue = tempNumber / 100;
        }

        #endregion Methods
    }
}
