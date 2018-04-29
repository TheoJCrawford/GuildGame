using UnityEngine;
using UnityEditor;
using System;
using GG.BattleSystem;


namespace GG.BattleSystem.CreatureSystem.Editor
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
        private Texture2D _appearance;
        private BSCreature _theBeastie;
        private float _CreatureButtonSize = 300;
        [MenuItem("Horizon Guild/Creature/Creature Editor")]
        private static void Init()
        {
            CSCreatureEditor window = EditorWindow.GetWindow<CSCreatureEditor>();
            window.titleContent = new GUIContent("Creature Editor");
            window.Show();

            window.maxSize = new Vector2(1000, 1000);
            window.minSize = new Vector2(800, 800);
        }
        void OnEnable()
        {
            _db = CSCreatureDatabase.GetDatabase<CSCreatureDatabase>(DATABASE_FOLDER, DATABASE_NAME);
            EditorUtility.SetDirty(_db);
            _theBeastie = new BSCreature();
            _selectedCreature = -1;
            _speciesDb = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER, SPECIES_DATABASE);

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
            if (_selectedCreature > -1)
            {
                MainScreen();
            }
            GUILayout.EndArea();
        }
        #region Functions
        void TopBar()
        {
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("New Creature", GUILayout.ExpandWidth(false))){
                _db.Add(new BSCreature());
            }
            GUILayout.Button("Delete Selected Creature", GUILayout.ExpandWidth(false));
            GUILayout.Label("Creatures: " + _db.Count);
            GUILayout.EndHorizontal();
        }
        void SideBar()
        {
            GUILayout.BeginVertical();
            if (_db.Count > 0)
            {
                for (int i = 0; i < _db.Count; i++)
                {
                    if (GUILayout.Button(_db.Get(i).name))
                    {
                        _selectedCreature = i;
                    }
                }
            }
            GUILayout.EndVertical();
        }
        void MainScreen()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name: ", GUILayout.ExpandWidth(false));
            _db.Get(_selectedCreature).name = GUILayout.TextField(_db.Get(_selectedCreature).name);
            GUILayout.EndHorizontal();
            for(int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(Enum.GetName(typeof(StatNameAbreviations), i));
                GUILayout.Label(_db.Get(_selectedCreature).GetBaseStats(i).baseValue.ToString(), GUILayout.Width(50));
                if(GUILayout.Button("+5", GUILayout.ExpandWidth(false))){
                    _db.Get(_selectedCreature).GetBaseStats(i).baseValue+=5;
                }
                if(GUILayout.Button("+1", GUILayout.ExpandWidth(false))){
                    _db.Get(_selectedCreature).GetBaseStats(i).baseValue++;
                }
                if(GUILayout.Button("-1", GUILayout.ExpandWidth(false))){
                    if(_db.Get(_selectedCreature).GetBaseStats(i).baseValue > 0)
                    {
                        _db.Get(_selectedCreature).GetBaseStats(i).baseValue--;
                    }
                    
                }
                if(GUILayout.Button("-5", GUILayout.ExpandWidth(false))){
                    if (_db.Get(_selectedCreature).GetBaseStats(i).baseValue > 0)
                    {
                        _db.Get(_selectedCreature).GetBaseStats(i).baseValue -= 5;
                    }
                }
                GUILayout.EndHorizontal();
            }
            for(int i = 0; i < Enum.GetNames(typeof(VitalNames)).Length; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(Enum.GetName(typeof(VitalNameAbreviations), i), GUILayout.ExpandWidth(false));
                GUILayout.Label(_db.Get(_selectedCreature).GetVitals(i).baseValue.ToString());
                if(GUILayout.Button("+10", GUILayout.ExpandWidth(false))){
                    _db.Get(_selectedCreature).GetVitals(i).baseValue += 10;
                }
                if(GUILayout.Button("+5", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).GetVitals(i).baseValue += 5;
                }
                if(GUILayout.Button("+1", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).GetVitals(i).baseValue++;
                }
                if(GUILayout.Button("-1", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).GetVitals(i).baseValue--;
                }
                if(GUILayout.Button("-5", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).GetVitals(i).baseValue -= 5;
                }
                if(GUILayout.Button("-10", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).GetVitals(i).baseValue -= 10;
                }

                GUILayout.EndHorizontal();
            }
            GUILayout.BeginHorizontal();
            GUILayout.Label("Abilities: ");
            GUILayout.Button("Add ability", GUILayout.MaxWidth(150));
            GUILayout.EndHorizontal();

            GUILayout.Label("A.I. Type: ");
            GUILayout.BeginHorizontal();
            GUILayout.Label("Loot Table: ");
            GUILayout.Button("Add Item", GUILayout.MaxWidth(150));
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}
