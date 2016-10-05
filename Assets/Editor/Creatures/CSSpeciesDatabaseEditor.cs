using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem.Editor
{
    public class CSSpeciesDatabaseEditor : EditorWindow
    {
        private CSSpeciesDatabase _speciesDb;
        private int _selector;

        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_FILE_NAME = "GGSpeciesDatabase.asset";


        [MenuItem("Horizon Guild/Creatures/Species")]
        public static void Init()
        {
            CSSpeciesDatabaseEditor window = EditorWindow.GetWindow<CSSpeciesDatabaseEditor>();
            window.titleContent = new GUIContent("Species Database");
            window.minSize = new Vector2(650, 600);
            window.maxSize = new Vector2(650, 600);
        }
        public void OnEnable()
        {
            _speciesDb = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
            _speciesDb.SetDirty();
        }
        public void OnGUI()
        {
            GUILayout.BeginArea(new Rect(5, 5, 100, 600));
            SideBar();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(110, 5, 380, 600));
            DataEntry();
            GUILayout.EndArea();
        }
        public void SideBar()
        {
            GUILayout.BeginVertical();
            if(GUILayout.Button("Add Species"))
            {
                _speciesDb.Add(new CSSpecies());
            }
            if (_speciesDb.Count > 0)
            {
                for (int i = 0; i < _speciesDb.Count; i++)
                {
                    if (GUILayout.Button(_speciesDb.Get(i).name))
                    {
                        _selector = i;
                    }
                }
            }
            GUILayout.EndVertical();
        }
        public void DataEntry()
        {
            if(_selector > -1)
            {
                _speciesDb.Get(_selector).name = GUILayout.TextField(_speciesDb.Get(_selector).name);
            }
        }
    }
}