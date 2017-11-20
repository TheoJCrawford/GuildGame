using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    public class BSCombatant
    {
#region variables
        //based on this, how close are you to attacking?
                //ability being cast
        #endregion
#region properties
        public virtual string name{get;set;}
        public virtual int standardBar { set; get; }
        public virtual int castingBar { set; get; }
        public virtual bool isCasting { set; get; }
        public virtual BaseStats GetBaseStats(int index)
        {
            return new BaseStats();
        }
        public virtual Vital GetVitals(int index)
        {
            return new Vital();
        }
        public int deathCount { set; get; }
        #endregion
    }
}
