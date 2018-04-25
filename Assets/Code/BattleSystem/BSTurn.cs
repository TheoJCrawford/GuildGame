using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private int targetEntity = 0;
        private string order = " ";
        private BSCombatant target;
        public void PlayerTurn()
        {
            
            
        }
        public void CreatureTurn()
        {
            Random randTarget = new Random();
            targetEntity = randTarget.Next(0, pParty.party.Count);
            pParty.partymember(targetEntity).DealDamage(Combatants.ElementAt(0).GetBaseStats(0).fullValue, false);
           
        }
        public void SetPlayerAttack()
        {
            SelectPlayerTarget();
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
            //Give the player the ability to select a target
            //if the target is downed, do not allow slection
            //There needs to be a clause in here for "revive" items/abilities
            //That being said, allow target selection,
            //get a confirmation of the "Fire" key
            return gameObject.GetComponent<BSCombatant>();
        }
        void Reset()
        {
            Combatants.ElementAt(0).standardBar = 0;
            order = " ";
            target = null;
            SortCombatants();   

        }
    }
}
