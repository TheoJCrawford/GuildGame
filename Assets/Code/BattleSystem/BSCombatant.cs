using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    class BSCombatant
    {
#region variables
        private int _standardBar;      //based on this, how close are you to attacking?
        private int _casingBar;         //
        private bool _iscasting;        //
                                        //ability being cast
#endregion
        #region setters and Getters
        public int standardBar
        {
            get { return _standardBar; }
            set { _standardBar = value; }
        }
        public int castingBar
        {
            get { return _casingBar; }
            set { _casingBar = value; }
        }
            public bool isCasting
        {
            get { return _iscasting; }
            set { _iscasting = value; }
        }
#endregion
        public BSCombatant()
        {
            _standardBar = 0;
            _casingBar = 0;
            _iscasting = false;
        }
    }
}
