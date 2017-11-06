using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GG.BattleSystem
{
    public partial class BSCore
    {
        /*Alright... now here is where we have a massive problem
         * Players have choice, creatures have AI... Do I know how to get their AI to work, no...
         * Players have a few options (might add flee as a native option depending upon difficulty)
         * A player character makes the decision of Attack, use an ability from one of the trees they have assigned, or use an item (considering on making a class just to make the added teedium of them having to KNOW how to use the actual items)
         * 
        */
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
            if (Input.GetAxis("Horizontal") < 0.4f || Input.GetAxis("Horizontal") > -0.4f)
            {

            }
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
