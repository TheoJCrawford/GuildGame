using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem.CharacterSystem
{
    class BSPartymember
    {
        private BaseCharacter _char;

        public BaseCharacter Character
        {
            get { return _char; }
            set { _char = value; }
        }

        public BSPartymember()
        {
            _char = new BaseCharacter();
        }
    }
}
