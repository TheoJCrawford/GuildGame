using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG
{
    class CSSpeed
    {
        #region Variables
        private int _classValue;
        private int _dexValue;
        private int _fullValue;
        #endregion
        #region Constructor
        public CSSpeed()
        {
            _fullValue = 0;
            _dexValue = 0;
            _classValue = 0;
        }
        #endregion
        #region Functions
        public void Setup(int ClassValue, int Dexterity)
        {
            _classValue = ClassValue;
            _dexValue = Dexterity /  2;
            _fullValue = _classValue + _dexValue;
            return;
        }
        #endregion
    }
}
