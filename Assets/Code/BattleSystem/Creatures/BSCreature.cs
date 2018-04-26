using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem.CreatureSystem
{
    [Serializable]
    class BSCreature : BSCombatant
    {
        #region variables
        [SerializeField]
        private string _name;
        [SerializeField]
        private BaseStats[] _stats;
        [SerializeField]
        private Vital[] _vitals;
        //Combat related
        [SerializeField]
        private bool _isCasting;
        [SerializeField]
        private int _actBar;
        [SerializeField]
        private int _castBar;
        [SerializeField]
        private int _exp;
        //loot table
        #endregion
        #region setters and getters
        public override string name
        {
            get{return _name;}
            set{_name = value;}
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
            get { return _castBar; }
            set { _castBar = value; }
        }
        public override int standardBar
        {
            get { return _actBar; }
            set { _actBar = value; }
        }
        public override bool isCasting
        {
            get{return _isCasting;}
            set{_isCasting = value;}
        }
        public int exp
        {
            get { return _exp; }
            set { _exp = value; }
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
            _isCasting = false;
            _exp = 10;
        }
        #endregion
        #region Fuctions
        public void ModifyBaseStats(int Index, int ChangeVal)
        {
            _stats[Index].baseValue += ChangeVal;
        }
        #endregion
    }
}
