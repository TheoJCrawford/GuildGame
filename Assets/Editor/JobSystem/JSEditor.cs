using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CharacterSystem.Editor{
    public class JSEditor : EditorWindow
    {
        private JobsDatabase _jobDb;
        private int _selector;

        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_FILE_NAME = @"JobDatabase.asset";

        [MenuItem("Horizon Guild/Database/Class Database")]
        static void Init()
        {
            JSEditor window = EditorWindow.GetWindow<JSEditor>();
            window.titleContent = new GUIContent("Job Editor");
            window.Show();
            window.minSize = new Vector2(600, 600);
            window.maxSize = new Vector2(600, 600);
        }
        void OnEnable()
        {
            _jobDb = JobsDatabase.GetDatabase<JobsDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
        }
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 120, 600));
            SideBar();
            GUILayout.EndArea();
        }

        #region Non Unity Functions
       void SideBar()
        {
            GUILayout.BeginVertical();
            if(GUILayout.Button("Add Job"))
            {
                _jobDb.Add(new Job());
            }
            if(GUILayout.Button("Delete Job"))
            {
                _jobDb.Remove(_selector);
            }
            if (_jobDb.Count > 0)
            {
                for (int i = 0; i < _jobDb.Count; i++)
                {
                    if (GUILayout.Button(_jobDb.Get(i).name))
                    {
                        _jobDb.SetDirty();
                        _selector = i;
                    }
                }
            }
            GUILayout.EndVertical();
        }
        void KMajorEditor()
        {
            
        }
        #endregion
    }
}