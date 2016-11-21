using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace GG.CharacterSystem.Editor
{
    public class JSEditor : EditorWindow
    {
        private JobsDatabase _jobDb;
        private int _selector;
        private bool _preReqs;
        private string _preReqName;
        private int _preReqNum;
        private Texture2D _selectedTexture;
        private Vector2 _scrollPos;

        private const string DATABASE_FOLDER_NAME = @"Database";
        private const string DATABASE_FILE_NAME = @"JobDatabase.asset";

        [MenuItem("Horizon Guild/Database/Class Database")]
        static void Init()
        {
            JSEditor window = EditorWindow.GetWindow<JSEditor>();
            window.titleContent = new GUIContent("Job Editor");
            window.Show();
            window.minSize = new Vector2(600, 600);
            window.maxSize = new Vector2(800, 800);
        }
        void OnEnable()
        {
            _jobDb = JobsDatabase.GetDatabase<JobsDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
            EditorUtility.SetDirty(_jobDb);
            _selector = -1;
            _preReqName = string.Empty;
            _preReqNum = 2;
        }
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 120, 600));
            SideBar();
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(120, 0, 480, 600));
            KMajorEditor();
            GUILayout.EndArea();
        }
        #region Non Unity Functions
        void SideBar()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical();
            if (GUILayout.Button("Add Job"))
            {
                _jobDb.Add(new Job());
            }
            if (GUILayout.Button("Delete Job"))
            {
                _jobDb.Remove(_selector);
                _selector=-1;
            }
            GUILayout.Box(" ", GUILayout.MinHeight(.1f), GUILayout.MaxHeight(.1f), GUILayout.ExpandWidth(true));
            if (_jobDb.Count > 0)
            {
                for (int i = 0; i < _jobDb.Count; i++)
                {
                    if (GUILayout.Button(_jobDb.Get(i).name))
                    {
                        _jobDb.SetDirty();
                        _selector = i;
                        if (_jobDb.Get(_selector).unlockNames.Count > 0)
                        {
                            _preReqs = true;
                        }
                        else
                        {
                            _preReqs = false;
                        }
                    }
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }
        void KMajorEditor()
        {
            if (_selector > -1)
            {
                GUILayout.BeginHorizontal();
                //Naming
                _jobDb.Get(_selector).name = GUILayout.TextField(_jobDb.Get(_selector).name);
                //Icon selector Offline for maintaint
                GUILayout.EndHorizontal();
                //Stats                
                GUILayout.BeginVertical();
                for (int i = 0; i < Enum.GetNames(typeof(StatNames)).Length; i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(Enum.GetName(typeof(StatNames), i), GUILayout.Width(100));
                    if (GUILayout.Button("+"))
                    {
                        if (_jobDb.Get(_selector).statEvolve[i] < 9)
                        {
                            _jobDb.Get(_selector).statEvolve[i]++;
                        }
                    }
                    GUILayout.Label(_jobDb.Get(_selector).statEvolve[i].ToString());
                    if (GUILayout.Button("-"))
                    {
                        if (_jobDb.Get(_selector).statEvolve[i] > 0)
                        {
                            _jobDb.Get(_selector).statEvolve[i]--;
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
                //PreRequisite jobs
                _preReqs = GUILayout.Toggle(_preReqs, "Are there pre requisite jobs?");
                if (_preReqs)
                {
                    Prerequisites();
                }
                AbilityListEditor();
            }
        }
        void Prerequisites()
        {
            GUILayout.BeginHorizontal();
            _preReqName = GUILayout.TextField(_preReqName);
            if (GUILayout.Button("+", GUILayout.Width(30)))
            {
                _preReqNum++;
            }
            GUILayout.Label(_preReqNum.ToString(), GUILayout.Width(80));
            if (GUILayout.Button("-", GUILayout.Width(30)))
            {
                if (_preReqNum > 1)
                {
                    _preReqNum--;
                }
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Add Prequisite"))
            {
                _jobDb.Get(_selector).unlockNames.Add(_preReqName);
                _jobDb.Get(_selector).unlockLevels.Add(_preReqNum);
                _preReqName = string.Empty;
                _preReqNum = 2;
            }
            if(_jobDb.Get(_selector).unlockNames.Count > 0)
                for(int i = 0; i < _jobDb.Get(_selector).unlockNames.Count; i++)
            {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(_jobDb.Get(_selector).unlockNames.ElementAt(i));
                    GUILayout.Label(_jobDb.Get(_selector).unlockLevels.ElementAt(i).ToString(), GUILayout.Width(50));
                    if (GUILayout.Button("x", GUILayout.Width(25)))
                    {
                        _jobDb.Get(_selector).unlockNames.RemoveAt(i);
                        _jobDb.Get(_selector).unlockLevels.RemoveAt(i);
                    }
                    GUILayout.EndHorizontal();
                }
        }
        void AbilityListEditor()
        {

        }
        #endregion
    }
}