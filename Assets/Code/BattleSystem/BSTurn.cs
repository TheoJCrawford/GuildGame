using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
                    SelectPlayerTarget();
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
                    SelectPlayerTarget();
                    if (target != null)
                    {
                        if (Combatants.ElementAt(0).GetBaseStats(0).fullValue - target.GetBaseStats(2).fullValue < 0)
                        {
                           
                        }
                        Reset();
                    }
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
        public void SetPlayerAttack()
        {
            order = "Attack";
            //prompt the player to select a target
        }
        public void SetPlayerAbility()
        {
            order = "Ability";
        }
        public void SetPlayerItem()
        {
            order = "Item";
        }

         BSCombatant SelectPlayerTarget()
        {
            return gameObject.GetComponent<BSCombatant>();
        }
        void Reset()
        {
            Combatants.ElementAt(0).standardBar = 0;
            order = " ";
            target = null;

        }
    }
}
