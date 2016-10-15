using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem.Editor
{
    public class CSSpeciesEditor : EditorWindow
    {
        private CSSpeciesDatabase _db;
        private float _scrollPos;

        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_NAME = "Species Database.asset";

        [MenuItem("Horizon Guild/Creature/Species Editor")]
        public static void Init()
        {
            CSSpeciesEditor window = EditorWindow.GetWindow<CSSpeciesEditor>();
            window.Show();
        }
        void OnEnable()
        {
            _db = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);
        }
        void OnGUI()
        {
            TopBar();
            SideBar();
            MainScreen();
        }

        void SideBar()
        {
            if (_db.Count > 0)
            {
                for (int i = 0; i > _db.Count; i++)
                {
                    GUILayout.Button(_db.Get(i).name);
                }
            }
        }
        void TopBar()
        {
            GUILayout.Button("New Species");
        }
        void MainScreen()
        {
            //name
            //image
            //Species selection
            //exp value
            //gold value
            //stats
            //Speed - will be replaced by advanced statistics
            //AI Handling
        }
    }
}