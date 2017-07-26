using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    public class BSCombatant
    {
#region variables
        public int standardBar;      //based on this, how close are you to attacking?
        public int casingBar;         //
        public bool iscasting;        //ability being cast
        #endregion
#region properties
        public virtual string name{get;set;}
        public virtual BaseStats GetBaseStats(int index)
        {
            return new BaseStats();
        }
        public virtual Vital GetVitals(int index)
        {
            return new Vital();
        }
        #endregion
        public BSCombatant()
        {
            standardBar = 0;
            casingBar = 0;
            iscasting = false;

        }
    }
}
