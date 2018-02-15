using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using GG.BattleSystem.CreatureSystem;
namespace GG.BattleSystem
{
    public class EnemyParty : MonoBehaviour
    {
        public List<CSBaseCreature> party;

        public CSBaseCreature GetCreature(int index)
        {
            return party.ElementAt(index);
        }
    }
}