using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    class BSCombatant
    {
        private int _currentGuage;
        private int _castGuage;
        private CSSpeed _speed;

        public int currentGuage
        {
            get { return _currentGuage; }
            set { _currentGuage = value; }
        }
        public CSSpeed speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public BSCombatant()
        {
            _currentGuage = 0;
            _castGuage = 0;
            _speed = new CSSpeed();
        }

        public void UpdateSpeed(int ClassVal, int dexVal)
        {
            speed.Setup(ClassVal, dexVal);
        }
    }
}
