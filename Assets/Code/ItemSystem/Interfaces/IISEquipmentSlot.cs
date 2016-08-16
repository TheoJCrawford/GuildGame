using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISEquipmentSlot
    {
        string Name { get; set; }
        Sprite icon { get; set; }
    }
}
