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
        private Vital[] _vitals;
        //Combat related
        private bool _isCasting;
        private int _actBar;
        private int _castBar;
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
        public override Vital GetVitals(int index)
        {
            return _vitals[index];
        }
        public override int castingBar
        {
            get{return _castBar}
            set{_castBar = value;}
        }
        #endregion
        #region Constructors

        #endregion
        #region Fuctions
        #endregion
    }
}
