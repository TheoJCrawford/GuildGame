using UnityEngine;
using System.Collections;

namespace GG.AbilitySystem
{
    public class ASCoreSpell : ASBaseAbilty
    {
        private int _cost;              //how much it costs
        private bool _usesHealth;      //is ti blood magic?

        public ASCoreSpell()
        {
            _cost = 0;
            _usesHealth = false;
        }
    }
}