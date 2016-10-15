using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem
{
    public class CSCreatureEditor : EditorWindow
    {
        const string DATABASE_NAME = @"CSCreatureDatabase.asset";
        const string DATABASE_FOLDER = @"Database";

        private CSCreatureDatabase _db;

        [MenuItem("Horizon Guild/Creature/Creature Editor")]
        private static void Init()
        {
            CSCreatureEditor window = EditorWindow.GetWindow<CSCreatureEditor>();
            window.titleContent = new GUIContent("Creature Editor");
            window.Show();
            window.maxSize = new Vector2(800, 800);
            window.minSize = new Vector2(800, 800);
        }
        void OnEnable()
        {
            _db = CSCreatureDatabase.GetDatabase<CSCreatureDatabase>(DATABASE_FOLDER, DATABASE_NAME);
        }
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 800, 20));
            TopBar();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(0, 20, 150, 780));
            SideBar();
            GUILayout.EndArea();
        }

        void TopBar()
        {
            GUILayout.Box("Creatures: " + _db.Count, GUILayout.ExpandWidth(true));
        }
        void SideBar()
        {
            if(GUILayout.Button("Create New Creature"))
            {
                _db.Add(new CSBaseCreature());
            }
            if (_db.Count > 0)
            {
                for(int i = 0; i < _db.Count; i++)
                {
                    GUILayout.Button(_db.Get(i).name, GUILayout.ExpandWidth(true));
                }
            }
        }
        void MainScreen()
        {

        }
    }
}