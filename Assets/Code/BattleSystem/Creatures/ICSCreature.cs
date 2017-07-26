using UnityEngine;
using GG;
using GG.BattleSystem;
using System.Collections;
namespace GG.BattleSystem.CreatureSystem
{
    public interface ICSCreature
    {
        string name { set; get; }
        Sprite image { set; get; }
        string descript { set; get; }
        CSSpecies species { set; get; }
        //CSCreatureStat[] coreStats {get; }
        Vital vitals { get; set; }
        FSMSystem ai { get; set; }
        int exp { set; get; }
        int money { set; get; }
        int speed { set; get; }
        //ArrayList loot {get; set;]
    }
}