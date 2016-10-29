using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using GG.CharacterSystem;

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
        private Texture2D _appearance;
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
                _db.SetDirty();
            }
            if (_db.Count > 0)
            {
                for(int i = 0; i < _db.Count; i++)
                {
                    if(GUILayout.Button(_db.Get(i).name, GUILayout.ExpandWidth(true)))
                    {
                        _selectedCreature = i;
                        EditorUtility.SetDirty(_db);
                    }
                }
            }
        }
        void MainScreen()
        {
            if(_selectedCreature > -1)
            {
                //name
                _db.Get(_selectedCreature).name = GUILayout.TextField(_db.Get(_selectedCreature).name);
                //Species
                GUILayout.BeginHorizontal();
                GUILayout.Label(_db.Get(_selectedCreature).species.name, GUILayout.Width(150));
                GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.Height(200), GUILayout.Width(150));
                for (int i = 0; i < _speciesDb.Count; i++)
                {
                   if(GUILayout.Button(new GUIContent(_speciesDb.Get(i).name)))
                    {
                        _db.Get(_selectedCreature).species = _speciesDb.Get(i);
                        EditorUtility.SetDirty(_db);
                    }
                }
                GUILayout.EndScrollView();
                //Image
                if (_db.Get(_selectedCreature).image)
                {
                    _appearance = _db.Get(_selectedCreature).image.texture;
                }
                else
                {
                    _appearance = null;
                }
                if(GUILayout.Button(_appearance, GUILayout.Height(_CreatureButtonSize), GUILayout.Width(_CreatureButtonSize)))
                {
                    int ControlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, ControlerID);
                }
                string commandName = Event.current.commandName;
                if (commandName == "ObjectSelectorUpdated")
                {
                    _db.Get(_selectedCreature).image = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                    Repaint();
                }
                GUILayout.EndHorizontal();
                //Stats
                GUILayout.BeginVertical();
                GUILayout.BeginHorizontal();
                for (int i = 0; i > Enum.GetNames(typeof(StatNames)).Length; i++){
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(Enum.GetName(typeof(StatNameAbreviations), i));
                    GUILayout.Label(_db.Get(_selectedCreature).coreStats[i].fullValue.ToString());
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
                //Attack and defence (Will be reworked later)

                //EXP
                GUILayout.BeginHorizontal();
                if(GUILayout.Button("+5", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).exp += 5;
                }
                if(GUILayout.Button("+1", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).exp++;
                }
                GUILayout.Box("Exp: " + _db.Get(_selectedCreature).exp.ToString());
                if(GUILayout.Button("-1", GUILayout.ExpandWidth(false)))
                {
                    if(_db.Get(_selectedCreature).exp > 0)
                    {
                        _db.Get(_selectedCreature).exp--;
                    }
                }
                if(GUILayout.Button("-5", GUILayout.ExpandWidth(false)))
                {
                    if (_db.Get(_selectedCreature).exp > 0)
                    {
                        _db.Get(_selectedCreature).exp -= 5;
                    }
                    if(_db.Get(_selectedCreature).exp <= 0)
                    {
                        _db.Get(_selectedCreature).exp = 0;
                    }
                }
                GUILayout.EndHorizontal();
                //Gold
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("+5", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).money += 5;
                }
                if (GUILayout.Button("+1", GUILayout.ExpandWidth(false)))
                {
                    _db.Get(_selectedCreature).money++;
                }

                GUILayout.Box("Gold: " + _db.Get(_selectedCreature).money.ToString());
                if (GUILayout.Button("-1", GUILayout.ExpandWidth(false)))
                {
                    if(_db.Get(_selectedCreature).money >= 1)
                    _db.Get(_selectedCreature).money--;
                }
                if (GUILayout.Button("-5", GUILayout.ExpandWidth(false)))
                {
                    if (_db.Get(_selectedCreature).money >= 1)
                    {
                        _db.Get(_selectedCreature).money -= 5;
                        if(_db.Get(_selectedCreature).money < 0)
                        {
                            _db.Get(_selectedCreature).money = 0;
                        }
                    }
                }
                GUILayout.EndHorizontal();
                //Ai(To be made later)
            }
            
        }
    }
}