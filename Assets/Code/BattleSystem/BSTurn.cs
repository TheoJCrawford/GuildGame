using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GG.BattleSystem
{
    public partial class BSCore
    {
        private string order = " ";
        private BSCombatant target;
        public void PlayerTurn()
        {
            switch (order)
            {
                case "attack":
                    if(target != null)
                    {
                        if(Combatants.ElementAt(0).GetBaseStats(0).fullValue - target.GetBaseStats(2).fullValue < 0)
                        {
                            target.GetVitals(0).ModifyCurValue(Combatants.ElementAt(0).GetBaseStats(0).fullValue - target.GetBaseStats(2).fullValue);
                        }
                        Reset();
                        
                    }
                    break;
                case "Ability":
                    break;
                case "Item":
                    break;
                    case " ":
                    break;
            }
        }
        public void CreatureTurn()
        {

        }
        public void SetAttack()
        {
            order = "Attack";
            //prompt the player to select a target
        }
        public void SetAbility()
        {
            order = "Ability";
        }
        public void SetItem()
        {
            order = "Item";
        }

        void SelectTarget()
        {

        }
        void Reset()
        {
            Combatants.ElementAt(0).standardBar = 0;
            order = " ";
            target = null;

        }
    }
}
