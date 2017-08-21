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
            get{ return _castBar; }
            set{_castBar = value;}
        }
        public override int standardBar
        {
            get{return _actBar;}
            set{_actBar = value;}
        }
        #endregion
        #region Constructors
        public BSCreature()
        {
            _name = "Meps";
            _stats = new BaseStats[Enum.GetNames(typeof(StatNames)).Length];
            for(int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
            {
                _stats[i] = new BaseStats();
                _stats[i].name = Enum.GetName(typeof(StatNames), i);
            }
            for(int i =0; i < Enum.GetNames(typeof(VitalNames)).Length; i++)
            {
                _vitals[i].name = Enum.GetName(typeof(VitalNames), i);
            }
        }
        #endregion
        #region Fuctions
        #endregion
    }
}
