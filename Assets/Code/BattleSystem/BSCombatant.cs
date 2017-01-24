using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    class BSCombatant
    {
        private int _currentGuage;
        private int _speed;
        
        public int currentGuage
        {
            get { return _currentGuage; }
            set { _currentGuage = value; }
        }
        public int speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public BSCombatant()
        {
            _currentGuage = 0;
            _speed = 0;
        }
    }
}
