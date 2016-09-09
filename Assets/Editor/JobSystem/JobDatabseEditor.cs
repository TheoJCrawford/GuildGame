using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CharacterSystem.Editor
{
    public class JobDatabseEditor : EditorWindow
    {
        //variables
        private JobsDatabase _classDb;
        //constants
        const string DATABASE_NAME = @"GGJobDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME;

        [MenuItem("Horizon Guild/Database/Classes Editor")]
        static void Init()
        {
            JobDatabseEditor window = EditorWindow.GetWindow<JobDatabseEditor>();
            window.titleContent = new GUIContent("Classes Editor");
            window.minSize = new Vector2(800, 800);
        }
        void OnEnable()
        {
            _classDb = JobsDatabase.GetDatabase<JobsDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);

        }
        void onGUI()
        {
            if(_classDb == null)
            {
                Debug.LogError("You done fucked up, son");
            }
            GUILayout.Box("Everything", GUILayout.ExpandWidth(true));
            GUILayout.TextField("name:");

        }
    }
}