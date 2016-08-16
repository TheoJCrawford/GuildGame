using UnityEngine;
using System.Collections;

namespace GG.AbilitySystem
{
    public class ASBaseAbilty : ScriptableObject
    {
        private string _name;
        private string _descript;

        public ASBaseAbilty()
        {
            _name = string.Empty;
            _descript = string.Empty;
        }
    }
}