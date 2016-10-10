using UnityEngine;
using System.Collections;

namespace GG.CreatureSystem
{
    public interface ICSCreature
    {
        string name { set; get; }
        Sprite image { set; get; }
        string descript { set; get; }
        CSSpecies species { set; get; }
        int exp { set; get; }
        int money { set; get; }
        int speed { set; get; }
    }
}