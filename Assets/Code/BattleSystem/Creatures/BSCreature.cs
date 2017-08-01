using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem.CreatureSystem
{
    class BSCreature:BSCombatant
    {
        #region variables
        private string _name;
        private BaseStats[] _stats;
        #endregion
        #region setters and getters
        public override string name
        {
            get
            {
                return _name; 
            }

            set
            {
                base.name = value;
            }
        }
        public override BaseStats GetBaseStats(int index)
        {
            return _stats[index];
        }
        #endregion
        #region Constructors

        #endregion
        #region Fuctions
        #endregion
    }
}
