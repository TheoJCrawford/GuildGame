using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISWeapon
    {

        int MinDamage { set; get; }
        int Attack();
    }
}