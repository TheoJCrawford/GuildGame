using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISDestructable
    {
        //durability
        int Durability { get; }
        int MaxDurability { get; }
        void TakeDamage(int amount);
        void Repair();
        void Break();
        //damage taken
    }
}
