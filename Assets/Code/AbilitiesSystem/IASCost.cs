using UnityEngine;
using System.Collections;

namespace GG.AbilitySystem
{
    public interface IASCost
    {
        bool isHealth { get; set; }
        int baseCost { get; set; }
        float spellUpCost { get; set; }
        int fullCost { get; set; }
        void SetFullCost();
    }
}