using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem
{
    public class CSCreatureEditor : EditorWindow
    {
        const string DATABASE_NAME = @"CSCreatureDatabase.asset";
        const string SPECIES_DATABASE = @"CSSpecies Database.asset";
        const string DATABASE_FOLDER = @"Database";

        private CSCreatureDatabase _db;
        private CSSpeciesDatabase _speciesDb;
        private int _selectedCreature;
        private Vector2 _scrollPos = Vector2.zero;

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
            EditorUtility.SetDirty(_db);
            _speciesDb = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER, SPECIES_DATABASE);
            if (_db.Count > 0)
            {
                _selectedCreature = 0;
            }
            else {
                _selectedCreature = -1;
            }

        }
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 800, 20));
            TopBar();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(0, 20, 150, 780));
            SideBar();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(150, 20, 650, 780));
            MainScreen();
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
                    if(GUILayout.Button(_db.Get(i).name, GUILayout.ExpandWidth(true)))
                    {
                        _selectedCreature = i;
                    }
                }
            }
        }
        void MainScreen()
        {
            if(_db.Count > 0)
            {
                //name
                _db.Get(_selectedCreature).name = GUILayout.TextArea(_db.Get(_selectedCreature).name);
                //Species
                GUILayout.BeginArea(new Rect(550, 20, 100, 400));
                GUILayout.Label(_db.Get(_selectedCreature).species.name);
                GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
                for (int i = 0; i < _speciesDb.Count; i++)
                {
                   if(GUILayout.Button(new GUIContent(_speciesDb.Get(i).name)))
                    {
                        _db.Get(_selectedCreature).species = _speciesDb.Get(i);
                    }
                }
                GUILayout.EndArea();
            }
            
        }
    }
}