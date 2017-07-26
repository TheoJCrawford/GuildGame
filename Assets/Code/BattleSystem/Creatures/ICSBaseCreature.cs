using GG.BattleSystem;
using UnityEngine;

namespace GG.BattleSystem.CreatureSystem
{
    public interface ICSBaseCreature
    {
        FSMSystem ai { get; set; }
        string descript { get; set; }
        int exp { get; set; }
        Sprite image { get; set; }
        int money { get; set; }
        string name { get; set; }
        CSSpecies species { get; set; }
        Vital vitals { get; set; }

        void ActivateStats();
    }
}