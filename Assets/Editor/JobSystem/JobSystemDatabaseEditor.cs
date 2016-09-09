using UnityEngine;
using UnityEditor;
using System;

namespace GG.CharacterSystem.Editor
{
    public class JobSystemDatabaseEditor : EditorWindow
    {
        //variables
        private JobsDatabase _classDb;
        //Temp
        private Job _tempJob;
        private int _selector = 0;
        //constants
        const string DATABASE_NAME = @"GGJobDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME;

        [MenuItem("Horizon Guild/Database/Classes Editor")]
        #region Unity Functinos
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
            _tempJob = _classDb.Get(_selector);
            GUI.BeginGroup(new Rect(100, 0, 800,600)," ");
            GUI.Label(new Rect(0, 0, 70, 26), "Class name:");
            _tempJob.name = GUI.TextField(new Rect(80, 0, 100, 18), _tempJob.name);
            if (GUI.Button(new Rect(560, 0, 140, 20), "Create New Class"))
            {
                _tempJob = new Job();
                _classDb.Add(_tempJob);
            }
            if (GUI.Button(new Rect(560, 20, 140, 20), "Update Class"))
            {
                _classDb.Replace(_selector, _tempJob);
            }
            StatModifiers();
            GUI.EndGroup();
            GUILayout.BeginArea(new Rect(0, 0, 100, 600));
            JobList();
            GUILayout.EndArea();
        }
        #endregion
        #region Additional Functions
        void JobList()
        {
            if(_tempJob != null) {
                if (_classDb.Count > 0)
                {
                    for (int i = 0; i < _classDb.Count; i++)
                    {
                        if (GUILayout.Button(_classDb.Get(i).name))
                        {
                            _tempJob = _classDb.Get(i);
                            _selector = i;
                        }
                    }
                }
            }
        }
        void StatModifiers()
        {
            for(int i = 0; i < Enum.GetNames(typeof(StatNameAbreviations)).Length; i++)
            {
                GUI.Label(new Rect(5,20 + (20* i), 60, 20), Enum.GetName(typeof(StatNameAbreviations), i).ToString());
                if(GUI.Button(new Rect(70, 20 + (20 * i), 20, 20), "-")){
                    if(_tempJob.statEvolve[i] > 0)
                    {
                        _tempJob.statEvolve[i]--;
                    }
            }
                GUI.Label(new Rect(90, 20 + (20 * i), 20, 20),_tempJob.statEvolve[i].ToString());
                if(GUI.Button(new Rect(110, 20 + (20 * i), 20, 20), "+"))
                {
                    if (_tempJob.statEvolve[i] < 9)
                    {
                        _tempJob.statEvolve[i]++;
                    }
                }
            }
        }
        #endregion
    }
}