using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.CharacterSystem.Editor{
    public class JSEditor : EditorWindow
    {
        private JobsDatabase _jobDb;

        [MenuItem("Horizon Guild/Database/Class Database")]
        static void Init()
        {
            JSEditor window = EditorWindow.GetWindow<JSEditor>();
            window.titleContent = new GUIContent("Job Editor");
            window.Show();
        }

        #region Non Unity Functions
       void SideBar()
        {

        }
        void KeyEditor()
        {

        }
        #endregion
    }
}