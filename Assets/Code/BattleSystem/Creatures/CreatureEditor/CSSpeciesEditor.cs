using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.BattleSystem.CreatureSystem.Editor
{
    public class CSSpeciesEditor : EditorWindow
    {
        private CSSpeciesDatabase _db;
        private float _scrollPos;
        private int _selector;
        private Texture2D _selectedIcon;
        const float ICON_BUTTON_SIZE = 40;
        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_NAME = "CSSpecies Database.asset";
       

        [MenuItem("Horizon Guild/Creature/Species Editor")]
        public static void Init()
        {
            CSSpeciesEditor window = EditorWindow.GetWindow<CSSpeciesEditor>();
            window.Show();
            window.titleContent = new GUIContent("Species Editor");
        }
        void OnEnable()
        {
            _db = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);
            EditorUtility.SetDirty(_db);
            _selector = -1;
        }
        void OnGUI()
        {
            GUI.skin.textField.wordWrap = true;
            TopBar();
            SideBar();
            MainScreen();
        }

        void SideBar()
        {
            GUILayout.BeginArea(new Rect(0, 20, 100, 580));
            GUILayout.BeginVertical();
            if (_db.Count > 0)
            {
                for (int i = 0; i < _db.Count; i++)
                {
                    if (GUILayout.Button(_db.Get(i).name))
                    {
                        _selector = i;
                    }
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
        void TopBar()
        {
            GUILayout.BeginArea(new Rect(0, 0, 500, 20));
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("New Species", GUILayout.ExpandWidth(false)))
            {
                _db.Add(new CSSpecies());
                _selector++;
            }
            if(GUILayout.Button("Delete Species", GUILayout.ExpandWidth(false)))
            {
                _db.Remove(_selector);
                _selector = -1;
            }
            GUILayout.Box("Spiecies count: " + _db.Count, GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        void MainScreen()
        {
            if(_selector > -1)
            {
                GUILayout.BeginArea(new Rect(100, 20, 400, 480));
                GUILayout.BeginHorizontal();
                _db.Get(_selector).name = GUILayout.TextArea(_db.Get(_selector).name);
                //Icon
                if (_db.Get(_selector).icon)
                {
                    _selectedIcon = _db.Get(_selector).icon.texture;
                }
                else
                {
                    _selectedIcon = null;
                }

                if (GUILayout.Button(_selectedIcon, GUILayout.Width(ICON_BUTTON_SIZE), GUILayout.Height(ICON_BUTTON_SIZE)))
                {
                    int ControlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, ControlerID);
                }
                string commandName = Event.current.commandName;
                    if (commandName == "ObjectSelectorUpdated")
                    {
                        _db.Get(_selector).icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                        Repaint();
                    }
                GUILayout.EndHorizontal();
                //Description
                _db.Get(_selector).descript = GUILayout.TextField(_db.Get(_selector).descript, GUILayout.ExpandHeight(true));
                GUILayout.EndArea();
            }
        }
    }
}