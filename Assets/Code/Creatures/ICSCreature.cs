using UnityEngine;
using GG;
using GG.CharacterSystem;

namespace GG.CreatureSystem
{
    public interface ICSCreature
    {
        string name { set; get; }
        Sprite image { set; get; }
        string descript { set; get; }
        CSSpecies species { set; get; }
        BaseStats[] coreStats { set; get; }
        Vital vitals { get; set; }
        FSMSystem ai { get; set; }
        int exp { set; get; }
        int money { set; get; }
        int speed { set; get; }
    }
}