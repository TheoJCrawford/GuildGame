using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GG.CharacterSystem;

namespace GG.BattleSystem
{
    public class BSCore
    {
        /*
        Rules:
        1)When all members of a side are dead, the battle ends. If the player's characters are all dead, then it is a game over state (unless there are guild members that are in a position to act as the next leaders). If all creatures are dead or have fled, then it is the exp of those slain distributed to the party evenly.
        2)Turns take place in an a speed based system. The faster the character, the faster their time for a turn comes up.
        3)When the actor's turn does come up the player can choose multiple things
            a) Attack - selecting a target then - depletes their "gauge" to 0
            b) Ability - if it has a cast time, depletes the "gauge" then brings it back to full at the spell's speed. If it is an instant cast
            c) Item - currently toying around with the notion of using items without any form of learning how to use them...
            d) Attempting to flee - burns the gauge completely and RNG
        4)Once the turn is completed, their gauge is set to zero, thus placing them at the bottom of the list. That entity will continue to go up the list until it is the entity's turn based on how fast their guage replenishes. This, again, is based off speed
        */
        private List<BSCombatant> _combatants;

        void Awake()
        {
            /*
            populate the combatants list
            until one of the gauges is full, keep adding the speed
            Do some quick maths to put the
            */
            
        }
        void Update()
        {
            
            //Update the gauges to their respective points
            //Engauge the turn of the first person
                //Side note: if they have a spell they are channeling, engauge spell
            //Apply rules given to the action
            //put him at the bottom of the turn after his action has been forfilled
        }
    }
}
