using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    class BSCombatant
    {
        private int _currentGuage;
        public int currentGuage
        {
            get { return _currentGuage; }
            set { _currentGuage = value; }
        }
        public BSCombatant()
        {
            _currentGuage = 0;
        }
    }
}
