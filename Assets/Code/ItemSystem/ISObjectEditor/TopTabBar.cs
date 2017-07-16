using UnityEngine;
using System.Collections;

namespace GG.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
       void TopTabbar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            WeaponTab();
            ArmourTab();
            ConsumablesTab();
            AboutTab();
            GUILayout.EndHorizontal();
        }
        void WeaponTab()
        {
            GUILayout.Button("Weapons");
        }
        void ArmourTab()
        {
            GUILayout.Button("Armour");
        }
        void ConsumablesTab()
        {
            GUILayout.Button("Consumables");
        }
        void AboutTab()
        {
            GUILayout.Button("About");
        }
    }
}