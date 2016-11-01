using UnityEngine;
using UnityEditor;
using System;
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
        private CSBaseCreature _theBeastie;
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
            _theBeastie = new CSBaseCreature();
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
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Create New Creature"))
            {
                _db.Add(_theBeastie);
                _theBeastie = new CSBaseCreature();
            }
            if (GUILayout.Button("Clear"))
            {
                _selectedCreature = -1;
                _theBeastie = new CSBaseCreature();
            }
            if (GUILayout.Button("Edit Creature"))
            {
                _db.Replace(_selectedCreature, _theBeastie);
            }
            if(GUILayout.Button("Delete Creature"))
            {
                if(_selectedCreature != -1)
                {
                    _db.Remove(_selectedCreature);
                }
            }
            GUILayout.Box("Creatures: " + _db.Count, GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();
        }
        void SideBar()
        {
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
                //name
                _theBeastie.name = GUILayout.TextField(_theBeastie.name);
                //Species
                GUILayout.BeginHorizontal();
                GUILayout.Label(_theBeastie.species.name, GUILayout.Width(150));
                GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.Height(200), GUILayout.Width(150));
                for (int i = 0; i < _speciesDb.Count; i++)
                {
                   if(GUILayout.Button(new GUIContent(_speciesDb.Get(i).name)))
                    {
                    _theBeastie.species = _speciesDb.Get(i);
                    }
                }
                GUILayout.EndScrollView();
                //Image
                if (_theBeastie.image)
                {
                    _appearance = _theBeastie.image.texture;
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
                _theBeastie.image = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                    Repaint();
                }
                GUILayout.EndHorizontal();
                //Stats
                GUILayout.Box("Stats");
                for(int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(Enum.GetName(typeof(StatNames), i).ToString(), GUILayout.Width(100));
                GUILayout.Box("Range: " + _theBeastie.coreStats(i).lowerVal.ToString() + " - "+ _theBeastie.coreStats(i).upperVal.ToString(), GUILayout.Width(100));
                GUILayout.Button("+", GUILayout.ExpandWidth(false));
                    GUILayout.Button("-", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();
            }
                //Attack and defence (Will be reworked later)

                //EXP
                GUILayout.BeginHorizontal();
                if(GUILayout.Button("+5", GUILayout.ExpandWidth(false)))
                {
                    _theBeastie.exp += 5;
                }
                if(GUILayout.Button("+1", GUILayout.ExpandWidth(false)))
                {
                _theBeastie.exp++;
                }
                GUILayout.Box("Exp: " + _theBeastie.exp.ToString());
                if(GUILayout.Button("-1", GUILayout.ExpandWidth(false)))
                {
                    if(_theBeastie.exp > 0)
                    {
                    _theBeastie.exp--;
                    }
                }
                if(GUILayout.Button("-5", GUILayout.ExpandWidth(false)))
                {
                    if (_theBeastie.exp > 0)
                    {
                        _theBeastie.exp -= 5;
                    }
                    if(_theBeastie.exp <= 0)
                    {
                    _theBeastie.exp = 0;
                    }
                }
                GUILayout.EndHorizontal();
                //Gold
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("+5", GUILayout.ExpandWidth(false)))
                {
                _theBeastie.money += 5;
                }
                if (GUILayout.Button("+1", GUILayout.ExpandWidth(false)))
                {
                _theBeastie.money++;
                }

                GUILayout.Box("Gold: " + _theBeastie.money.ToString());
                if (GUILayout.Button("-1", GUILayout.ExpandWidth(false)))
                {
                    if(_theBeastie.money >= 1)
                    _theBeastie.money--;
                }
                if (GUILayout.Button("-5", GUILayout.ExpandWidth(false)))
                {
                    if (_theBeastie.money >= 1)
                    {
                    _theBeastie.money -= 5;
                        if(_theBeastie.money < 0)
                        {
                            _theBeastie.money = 0;
                        }
                    }
                }
                GUILayout.EndHorizontal();
                //Ai(To be made later)
            
        }
    }
}