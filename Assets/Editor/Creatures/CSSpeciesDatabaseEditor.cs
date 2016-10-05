using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CreatureSystem.Editor
{
    public class CSSpeciesDatabaseEditor : EditorWindow
    {
        private CSSpeciesDatabase _speciesDb;
        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_FILE_NAME = "GGSpeciesDatabase.asset";


        [MenuItem("Horizon Guild/Creatures/Species")]
        public static void Init()
        {
            CSSpeciesDatabaseEditor window = EditorWindow.GetWindow<CSSpeciesDatabaseEditor>();
            window.titleContent = new GUIContent("Species Database");
            window.minSize = new Vector2(650, 600);
        }
        public void OnEnable()
        {
            _speciesDb = CSSpeciesDatabase.GetDatabase<CSSpeciesDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
        }
        public void onGUI()
        {

        }
    }
}