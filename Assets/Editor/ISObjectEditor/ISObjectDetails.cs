using UnityEngine;
using System.Collections;


namespace GG.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {

        private ISWeaponDatabase _weaponDB;


        const string DATABASE_NAME = @"GGWeaponDatabase.asset";
        const string DATABASE_PATH = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;


        void ItemDetail()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Label("Details");
            if (GUILayout.Button("Create Weapon"))
            {
                Debug.Log("Create new weapon");
            }
            GUILayout.EndHorizontal();
        }
    }
}