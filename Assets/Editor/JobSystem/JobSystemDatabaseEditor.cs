using UnityEngine;
using UnityEditor;
using System;

namespace GG.CharacterSystem.Editor
{
    public class JobSystemDatabaseEditor : EditorWindow
    {
        //variables
        private JobsDatabase _classDb;

        private Job _tempJob = new Job();
        //constants
        const string DATABASE_NAME = @"GGJobDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME;

        [MenuItem("Horizon Guild/Database/Classes Editor")]
        static void Init()
        {
            JobSystemDatabaseEditor window = EditorWindow.GetWindow<JobSystemDatabaseEditor>();
            window.titleContent = new GUIContent("Classes Editor");
            window.minSize = new Vector2(800, 800);
            window.maxSize = window.minSize;
        }
        void OnEnable()
        {
            _classDb = JobsDatabase.GetDatabase<JobsDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);

        }
        void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            _tempJob.name = GUILayout.TextField(_tempJob.name);
            GUILayout.EndHorizontal();
            for (int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(Enum.GetName(typeof(StatNameAbreviations), i).ToString());
                if (GUILayout.Button("-"))
                {
                    if(_tempJob.statEvolve[i] > 1)
                    {
                        _tempJob.statEvolve[i]--;
                    }
                }
                GUILayout.Label(_tempJob.statEvolve[i].ToString());
                if (GUILayout.Button("+"))
                {
                    if(_tempJob.statEvolve[i] < 10)
                    {
                        _tempJob.statEvolve[i]++;
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}