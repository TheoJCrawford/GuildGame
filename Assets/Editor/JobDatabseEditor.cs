using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GG.Editor
{
    public class JobDatabseEditor : EditorWindow
    {
        [MenuItem("Horizon Guild/Database/Classes Editor")]
        static void Init()
        {
            JobDatabseEditor window = EditorWindow.GetWindow<JobDatabseEditor>();
            window.titleContent = new GUIContent("Classes Editor");
        }
    }
}